using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ShortUrl"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/short_urls/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ShortUrlClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ShortUrl"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortUrlClient"/> class.
        /// </summary>
        internal ShortUrlClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "short_urls/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ShortUrl"/> using the specified <see cref="ShortUrlQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which short urls to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ShortUrl"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ShortUrl>> GetAsync(ShortUrlQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ShortUrl>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ShortUrl"/> items as an asynchronous stream using the specified <see cref="ShortUrlQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which short urls to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ShortUrl"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ShortUrl> StreamAsync(ShortUrlQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ShortUrl>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ShortUrl"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the short url.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ShortUrl"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ShortUrl?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ShortUrl>(new ShortUrlQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ShortUrl"/>.
        /// </summary>
        /// <param name="shortUrl">The short url to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ShortUrl"/>.</returns>
        public async Task<ShortUrl> CreateAsync(ShortUrl shortUrl, CancellationToken ct = default)
        {
            return await PostItemAsync(shortUrl, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ShortUrl"/>.
        /// </summary>
        /// <param name="shortUrl">The short url to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ShortUrl"/>.</returns>
        public async Task<ShortUrl> UpdateAsync(ShortUrl shortUrl, CancellationToken ct = default)
        {
            return await PatchItemAsync(shortUrl, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ShortUrl"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ShortUrlClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ShortUrlClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified short url using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shortUrlId">The unique identifier of the short url for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long shortUrlId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(shortUrlId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified short url using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shortUrl">The short url for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ShortUrl shortUrl, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (shortUrl is null)
                    throw new ArgumentNullException(nameof(shortUrl));

                return await GetAsync(shortUrl.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified short url using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shortUrlId">The unique identifier of the short url for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long shortUrlId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(shortUrlId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified short url using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shortUrl">The short url for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ShortUrl shortUrl, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (shortUrl is null)
                    throw new ArgumentNullException(nameof(shortUrl));

                return StreamAsync(shortUrl.Id, query, ct);
            }
        }
    }
}
