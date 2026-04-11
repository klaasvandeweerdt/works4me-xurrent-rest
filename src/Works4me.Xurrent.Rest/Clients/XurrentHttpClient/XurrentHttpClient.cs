using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Works4me.Xurrent.Rest.Extensions;
using Works4me.Xurrent.Rest.Interfaces;
using Works4me.Xurrent.Rest.Serialization;
using Works4me.Xurrent.Rest.Utilities;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Internal HTTP client implementation for the Xurrent REST API. <br />
    /// Handles query execution, mutations, OAuth token refresh, rate limiting, pagination, and streaming.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class XurrentHttpClient
    {
        private readonly IXurrentClientContext _context;

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly AuthenticationTokenCollection _authenticationTokens;
        private readonly RateLimiter _rateLimiter;
        private readonly SemaphoreSlim _oauthRefreshLock;

        private readonly object _urlLock = new();
        private readonly HttpMethod HttpPatch = new("PATCH");

        private readonly Uri _endPointUrl;
        private readonly Uri _oauth2Url;

        internal IXurrentClientContext Context
        {
            get => _context;
        }

        /// <summary>
        /// Gets the account identifier used when executing requests against the Xurrent REST API.
        /// </summary>
        internal protected string AccountId
        {
            get => _context.AccountId;
        }

        /// <summary>
        /// Gets the default number of items requested per paged API call.
        /// </summary>
        internal protected int DefaultItemsPerRequest
        {
            get => _context.DefaultItemsPerRequest;
        }

        /// <summary>
        /// Gets the maximum number of requests that may be issued when executing a single paged or streamed query.
        /// </summary>
        internal protected int MaximumRequestsPerQuery
        {
            get => _context.MaximumRequestsPerQuery;
        }

        /// <summary>
        /// Gets the base endpoint URL.
        /// </summary>
        internal protected Uri EndpointUrl
        {
            get
            {
                lock (_urlLock)
                {
                    return _endPointUrl;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentHttpClient"/> class.
        /// </summary>
        /// <param name="context">The shared client context.</param>
        /// <param name="endpointUrl">The base REST API endpoint URL for this endpoint client.</param>
        /// <exception cref="ArgumentNullException">Thrown when a required dependency is null.</exception>
        internal XurrentHttpClient(IXurrentClientContext context, Uri endpointUrl)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            _httpClient = context.HttpClient ?? throw new ArgumentException($"{nameof(context.HttpClient)} must not be null.", nameof(context));
            _jsonOptions = SerializationConfiguration.CreateJsonOptions();
            _rateLimiter = RateLimiter.Instance;

            _endPointUrl = endpointUrl ?? throw new ArgumentNullException(nameof(endpointUrl));
            _oauth2Url = EndpointUrlBuilder.GetOAuth2Url(endpointUrl);

            _authenticationTokens = context.AuthenticationTokens ?? throw new ArgumentException($"{nameof(context.AuthenticationTokens)} must not be null.", nameof(context));
            _oauthRefreshLock = context.OAuthRefreshLock ?? throw new ArgumentException($"{nameof(context.OAuthRefreshLock)} must not be null.", nameof(context));
            _logger = context.Logger;
        }

        /// <summary>
        /// Creates and initializes an <see cref="HttpRequestMessage"/> with authentication and account headers.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="uri">The request URI.</param>
        /// <param name="accountId">The account identifier header value.</param>
        /// <param name="token">The authentication token.</param>
        /// <returns>A configured <see cref="HttpRequestMessage"/>.</returns>
        private static HttpRequestMessage CreateHttpRequest(HttpMethod method, Uri uri, string accountId, AuthenticationToken token)
        {
            HttpRequestMessage retval = new(method, uri);
            retval.Headers.Authorization = new AuthenticationHeaderValue(token.TokenType, token.Token);
            retval.Headers.Add(Constants.AccountHeader, accountId);
            return retval;
        }

        /// <summary>
        /// Sends an HTTP request with rate limiting, retry handling, and response validation.
        /// </summary>
        /// <param name="requestMessage">The request to send.</param>
        /// <param name="content">The serialized request body.</param>
        /// <param name="token">The authentication token.</param>
        /// <param name="allowRetry">Indicates whether a retry is allowed after a 429 response.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The HTTP response message.</returns>
        private async Task<HttpResponseMessage> SendHttpRequestAsync(HttpRequestMessage requestMessage, string? content, AuthenticationToken token, bool allowRetry, CancellationToken ct)
        {
            if (!string.IsNullOrWhiteSpace(content))
                requestMessage.Content = new StringContent(content, Encoding.UTF8, Constants.ApplicationJsonMediaType);

            Guid logId = Guid.NewGuid();
            WriteDebug(logId, requestMessage, content);

            await _rateLimiter.WaitForToken(token, ct).ConfigureAwait(false);

            Stopwatch stopwatch = Stopwatch.StartNew();

            HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage, ct).ConfigureAwait(false);

            stopwatch.Stop();
            WriteDebug(logId, requestMessage, null, stopwatch.Elapsed, responseMessage);

            if ((int)responseMessage.StatusCode == 429)
            {
                token.UpdateRetryAfter(responseMessage.Headers);

                if (allowRetry)
                {
                    responseMessage.Dispose();

                    using (HttpRequestMessage newRequestMessage = new(requestMessage.Method, requestMessage.RequestUri))
                    {
                        foreach (KeyValuePair<string, IEnumerable<string>> header in requestMessage.Headers)
                            newRequestMessage.Headers.Add(header.Key, header.Value);

                        if (!string.IsNullOrWhiteSpace(content))
                            newRequestMessage.Content = new StringContent(content, Encoding.UTF8, Constants.ApplicationJsonMediaType);

                        return await SendHttpRequestAsync(newRequestMessage, content, token, false, ct).ConfigureAwait(false);
                    }
                }
            }

            token.UpdateLimitsFromHeaders(responseMessage.Headers);
            await responseMessage.ThrowIfInvalidResponse().ConfigureAwait(false);
            return responseMessage;
        }

        /// <summary>
        /// Retrieves a valid authentication token, refreshing it if it has expired.
        /// </summary>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>A valid <see cref="AuthenticationToken"/>.</returns>
        private async Task<AuthenticationToken> GetAuthenticationTokenAsync(CancellationToken ct)
        {
            AuthenticationToken token = _authenticationTokens.Get();

            if (token.IsTokenExpired())
            {
                await _oauthRefreshLock.WaitAsync(ct).ConfigureAwait(false);

                try
                {
                    if (token.IsTokenExpired())
                    {
                        using (HttpRequestMessage requestMessage = new(HttpMethod.Post, _oauth2Url))
                        {
                            requestMessage.Content = new FormUrlEncodedContent(new Dictionary<string, string?>()
                            {
                                { "grant_type", "client_credentials" },
                                { "client_id", token.ClientId },
                                { "client_secret", token.ClientSecret }
                            });

                            Guid logId = Guid.NewGuid();
                            WriteDebug(logId, requestMessage, "***");

                            await _rateLimiter.WaitForToken(token, ct).ConfigureAwait(false);

                            Stopwatch stopwatch = Stopwatch.StartNew();
                            using (HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage, ct).ConfigureAwait(false))
                            {
                                stopwatch.Stop();
                                WriteDebug(logId, requestMessage, null, stopwatch.Elapsed, responseMessage);

                                await responseMessage.ThrowIfInvalidResponse().ConfigureAwait(false);

#if NET5_0_OR_GREATER
                                using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync(ct).ConfigureAwait(false))
#else
                                using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
#endif
                                {
                                    AuthenticationOAuth2Response? oauthResponse = await JsonSerializer.DeserializeAsync<AuthenticationOAuth2Response>(responseStream, _jsonOptions, ct).ConfigureAwait(false);
                                    if (oauthResponse is not null)
                                    {
                                        token.SetToken(oauthResponse.AccessToken, oauthResponse.TokenType, oauthResponse.ExpiresIn);
                                    }
                                    else
                                    {
                                        throw new XurrentException("Invalid authentication response.");
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    _oauthRefreshLock.Release();
                }
            }

            return token;
        }
    }
}
