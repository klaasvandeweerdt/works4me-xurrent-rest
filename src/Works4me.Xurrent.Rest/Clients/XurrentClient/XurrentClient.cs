using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using Works4me.Xurrent.Rest.Interfaces;
using Works4me.Xurrent.Rest.Utilities;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Root client for interacting with the Xurrent REST API. <br />
    /// Manages shared configuration, authentication tokens, and cached HTTP clients per resource or usage context.
    /// </summary>
    public sealed partial class XurrentClient : IDisposable, IXurrentClient, IXurrentClientContext
    {
        private readonly ConcurrentDictionary<Type, Lazy<object>> _clients;
        private readonly ILogger<XurrentClient>? _logger;

        private readonly AuthenticationTokenCollection _authenticationTokens;
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpBulkClient;
        private readonly Uri _baseUrl;
        private readonly SemaphoreSlim _oauthRefreshLock = new(1, 1);
        private readonly object _settingsLock = new();
        private readonly object _disposeLock = new();
        private readonly bool _disposeAuthenticationTokens;

        private string _accountId;
        private int _defaultItemsPerRequest = 100;
        private int _maxRequestsPerQuery = 1000;
        private bool _disposedValue;

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentHttpClient"/> using a single <see cref="AuthenticationToken"/>.
        /// </summary>
        /// <param name="authenticationToken">The authentication token to use for requests.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="environment">The environment (e.g., production, staging) to target.</param>
        /// <param name="environmentRegion">The region of the environment (e.g., EU, US) to target.</param>
        /// <param name="logger">The logger instance to use for diagnostic and trace output, or <see langword="null"/> to disable logging.</param>
        public XurrentClient(AuthenticationToken authenticationToken, string accountId, EnvironmentType environment, EnvironmentRegion environmentRegion, ILogger<XurrentClient>? logger = null)
            : this(new AuthenticationTokenCollection(authenticationToken), accountId, EndpointUrlBuilder.GetBaseUrl(environmentRegion, environment), logger)
        {
            _disposeAuthenticationTokens = true;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentHttpClient"/> using a single <see cref="AuthenticationToken"/> and domain name.
        /// </summary>
        /// <param name="authenticationToken">The authentication token to use for requests.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="domainName">The domain name of the Xurrent API endpoint.</param>
        /// <param name="logger">The logger instance to use for diagnostic and trace output, or <see langword="null"/> to disable logging.</param>
        public XurrentClient(AuthenticationToken authenticationToken, string accountId, string domainName, ILogger<XurrentClient>? logger = null)
            : this(new AuthenticationTokenCollection(authenticationToken), accountId, domainName, logger)
        {
            _disposeAuthenticationTokens = true;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentHttpClient"/> using a collection of authentication tokens.
        /// </summary>
        /// <param name="authenticationTokens">The collection of authentication tokens to use.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="environment">The environment (e.g., production, staging) to target.</param>
        /// <param name="environmentRegion">The region of the environment (e.g., EU, US) to target.</param>
        /// <param name="logger">The logger instance to use for diagnostic and trace output, or <see langword="null"/> to disable logging.</param>
        public XurrentClient(AuthenticationTokenCollection authenticationTokens, string accountId, EnvironmentType environment, EnvironmentRegion environmentRegion, ILogger<XurrentClient>? logger = null)
            : this(authenticationTokens, accountId, EndpointUrlBuilder.GetBaseUrl(environmentRegion, environment), logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="XurrentClient"/> using a collection of authentication tokens and domain name.
        /// </summary>
        /// <param name="authenticationTokens">The collection of authentication tokens to use.</param>
        /// <param name="accountId">The account ID associated with this client.</param>
        /// <param name="domainName">The domain name of the Xurrent API endpoint.</param>
        /// <param name="logger">The logger instance to use for diagnostic and trace output, or <see langword="null"/> to disable logging.</param>
        public XurrentClient(AuthenticationTokenCollection authenticationTokens, string accountId, string domainName, ILogger<XurrentClient>? logger = null)
        {
            if (string.IsNullOrWhiteSpace(accountId))
                throw new ArgumentException($"'{nameof(accountId)}' cannot be null or empty.", nameof(accountId));

            if (string.IsNullOrWhiteSpace(domainName))
                throw new ArgumentException($"'{nameof(domainName)}' cannot be null or empty.", nameof(domainName));

            if (authenticationTokens is null || !authenticationTokens.Any())
                throw new ArgumentException($"'{nameof(authenticationTokens)}' cannot be null or empty.", nameof(authenticationTokens));

            _accountId = accountId;
            _authenticationTokens = authenticationTokens;
            _baseUrl = EndpointUrlBuilder.Get(domainName);
            _clients = new ConcurrentDictionary<Type, Lazy<object>>();

#if NET5_0_OR_GREATER
            _httpClient = new HttpClient(new SocketsHttpHandler() { PooledConnectionLifetime = TimeSpan.FromMinutes(5) }, disposeHandler: true);
#else
            _httpClient = new HttpClient(new ServicePointLifetimeHandler(TimeSpan.FromMinutes(5), new HttpClientHandler()), disposeHandler: true);
#endif
            _httpBulkClient = new HttpClient();

            _logger = logger;
        }

        /// <inheritdoc/>
        HttpClient IXurrentClientContext.HttpClient
        {
            get => _httpClient;
        }

        /// <inheritdoc/>
        HttpClient IXurrentClientContext.BulkHttpClient
        {
            get => _httpBulkClient;
        }

        /// <inheritdoc/>
        AuthenticationTokenCollection IXurrentClientContext.AuthenticationTokens
        {
            get => _authenticationTokens;
        }

        /// <inheritdoc/>
        SemaphoreSlim IXurrentClientContext.OAuthRefreshLock
        {
            get => _oauthRefreshLock;
        }

        /// <inheritdoc/>
        ILogger<XurrentClient>? IXurrentClientContext.Logger
        {
            get => _logger;
        }

        /// <inheritdoc/>
        Uri IXurrentClientContext.BaseUrl
        {
            get => _baseUrl;
        }

        /// <inheritdoc/>
        public string AccountId
        {
            get
            {
                lock (_settingsLock)
                {
                    return _accountId;
                }
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));

                lock (_settingsLock)
                {
                    _accountId = value;
                }
            }
        }

        /// <inheritdoc/>
        public int MaximumRequestsPerQuery
        {
            get
            {
                lock (_settingsLock)
                {
                    return _maxRequestsPerQuery;
                }
            }
            set
            {
                if (value < 1 || value > 1000)
                    throw new XurrentQueryException($"Invalid maximum requests: {value}. {nameof(MaximumRequestsPerQuery)} must be between 1 and 1000, inclusive.");

                lock (_settingsLock)
                {
                    _maxRequestsPerQuery = value;
                }
            }
        }

        /// <inheritdoc/>
        public int DefaultItemsPerRequest
        {
            get
            {
                lock (_settingsLock)
                {
                    return _defaultItemsPerRequest;
                }
            }
            set
            {
                if (value < 1 || value > 100)
                    throw new XurrentQueryException($"Invalid item per request: {value}. {nameof(DefaultItemsPerRequest)} must be between 1 and 100, inclusive.");

                lock (_settingsLock)
                {
                    _defaultItemsPerRequest = value;
                }
            }
        }

        /// <summary>
        /// Returns a typed client instance from the internal client cache.
        /// </summary>
        /// <typeparam name="TClient">The client type to retrieve.</typeparam>
        /// <returns>
        /// A cached instance of <typeparamref name="TClient"/>, created on first access.
        /// </returns>
        internal TClient GetInternalClient<TClient>() where TClient : class
        {
            return ((IXurrentClientProvider)this).GetClient<TClient>();
        }

        /// <summary>
        /// Gets a cached instance of the requested client type, creating it if it does not already exist.
        /// </summary>
        /// <typeparam name="TClient">The client type to retrieve.</typeparam>
        /// <returns> A singleton instance of <typeparamref name="TClient"/> for this <see cref="XurrentClient"/> context.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the requested client type cannot be constructed by <see cref="CreateClient(Type)"/>.</exception>
        TClient IXurrentClientProvider.GetClient<TClient>() where TClient : class
        {
            Type clientType = typeof(TClient);
            Lazy<object> lazyClient = _clients.GetOrAdd(clientType, type => new Lazy<object>(() => CreateClient(type), LazyThreadSafetyMode.ExecutionAndPublication));
            return (TClient)lazyClient.Value;
        }

        /// <summary>
        /// Creates a client instance of the specified type using reflection.
        /// </summary>
        /// <param name="clientType">The concrete client type to instantiate.</param>
        /// <returns>An instance of <paramref name="clientType"/>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the client instance cannot be created, typically because the expected constructor is missing.</exception>
        private object CreateClient(Type clientType)
        {
            object? instance = Activator.CreateInstance(clientType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, binder: null, args: new object[] { this }, culture: CultureInfo.InvariantCulture);

            return instance is null
                ? throw new InvalidOperationException($"Unable to create client instance for type '{clientType.FullName}'. Ensure it has a constructor that accepts {nameof(IXurrentClientContext)}.")
                : instance;
        }

        /// <summary>
        /// Releases the unmanaged and managed resources used by this client.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> if called from <see cref="Dispose()"/>; otherwise, <see langword="false"/>.</param>
        private void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                if (_disposedValue)
                    throw new ObjectDisposedException(nameof(XurrentClient));

                if (!_disposedValue)
                {
                    if (disposing)
                    {
                        _httpClient?.Dispose();
                        _httpBulkClient?.Dispose();
                        if (_disposeAuthenticationTokens)
                            _authenticationTokens?.Dispose();
                        _oauthRefreshLock?.Dispose();
                    }
                    _disposedValue = true;
                }
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
