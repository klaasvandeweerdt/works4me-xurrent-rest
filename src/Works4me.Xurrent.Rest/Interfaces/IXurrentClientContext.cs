using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;

namespace Works4me.Xurrent.Rest.Interfaces
{
    /// <summary>
    /// Provides access to shared infrastructure, configuration, and cached endpoint clients for a single Xurrent client instance.
    /// </summary>
    internal interface IXurrentClientContext : IXurrentClientProvider
    {
        /// <summary>
        /// Gets the primary <see cref="HttpClient"/> used for standard REST API requests.
        /// </summary>
        HttpClient HttpClient { get; }

        /// <summary>
        /// Gets the <see cref="HttpClient"/> used for bulk or high-throughput operations.
        /// </summary>
        HttpClient BulkHttpClient { get; }

        /// <summary>
        /// Gets the collection of authentication tokens used to authorize requests and perform OAuth token refresh operations.
        /// </summary>
        AuthenticationTokenCollection AuthenticationTokens { get; }

        /// <summary>
        /// Gets the semaphore used to synchronize OAuth token refresh operations across concurrent requests.
        /// </summary>
        SemaphoreSlim OAuthRefreshLock { get; }

        /// <summary>
        /// Gets the logger instance used for diagnostic and trace logging, or <see langword="null"/> if logging is not configured.
        /// </summary>
        ILogger<XurrentClient>? Logger { get; }

        /// <summary>
        /// Gets the base URI of the Xurrent REST API for the current client instance.
        /// </summary>
        Uri BaseUrl { get; }

        /// <summary>
        /// Gets or sets the account identifier used when executing requests against the Xurrent REST API.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the default number of items requested per paged API call.
        /// </summary>
        int DefaultItemsPerRequest { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of requests that may be issued when executing a single paged or streamed query.
        /// </summary>
        int MaximumRequestsPerQuery { get; set; }
    }
}
