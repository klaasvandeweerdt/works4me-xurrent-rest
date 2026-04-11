using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ShopArticle"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/shop_articles/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ShopArticleClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ShopArticle"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceOffering"/> records related to an <see cref="ShopArticle"/>.
        /// </summary>
        public ServiceOfferingsClient ServiceOfferings { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopArticleClient"/> class.
        /// </summary>
        internal ShopArticleClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "shop_articles/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            ServiceOfferings = new ServiceOfferingsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ShopArticle"/> using the specified <see cref="ShopArticleQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which shop articles to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ShopArticle"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ShopArticle>> GetAsync(ShopArticleQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ShopArticle>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ShopArticle"/> items as an asynchronous stream using the specified <see cref="ShopArticleQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which shop articles to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ShopArticle"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ShopArticle> StreamAsync(ShopArticleQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ShopArticle>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ShopArticle"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the shop article.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ShopArticle"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ShopArticle?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ShopArticle>(new ShopArticleQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ShopArticle"/>.
        /// </summary>
        /// <param name="shopArticle">The shop article to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ShopArticle"/>.</returns>
        public async Task<ShopArticle> CreateAsync(ShopArticle shopArticle, CancellationToken ct = default)
        {
            return await PostItemAsync(shopArticle, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ShopArticle"/>.
        /// </summary>
        /// <param name="shopArticle">The shop article to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ShopArticle"/>.</returns>
        public async Task<ShopArticle> UpdateAsync(ShopArticle shopArticle, CancellationToken ct = default)
        {
            return await PatchItemAsync(shopArticle, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ShopArticle"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ShopArticleClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ShopArticleClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified shop article using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopArticleId">The unique identifier of the shop article for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long shopArticleId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(shopArticleId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified shop article using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopArticle">The shop article for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ShopArticle shopArticle, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (shopArticle is null)
                    throw new ArgumentNullException(nameof(shopArticle));

                return await GetAsync(shopArticle.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified shop article using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopArticleId">The unique identifier of the shop article for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long shopArticleId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(shopArticleId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified shop article using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopArticle">The shop article for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ShopArticle shopArticle, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (shopArticle is null)
                    throw new ArgumentNullException(nameof(shopArticle));

                return StreamAsync(shopArticle.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceOffering"/> records related to an <see cref="ShopArticle"/>.
        /// </summary>
        public sealed class ServiceOfferingsClient
        {
            private readonly ShopArticleClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceOfferingsClient"/> class.
            /// </summary>
            internal ServiceOfferingsClient(ShopArticleClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceOffering"/> records for the specified shop article using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="shopArticleId">The unique identifier of the shop article for which to retrieve the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceOffering>> GetAsync(long shopArticleId, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceOffering>(shopArticleId, "service_offerings", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceOffering"/> records for the specified shop article using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="shopArticle">The shop article for which to retrieve the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceOffering>> GetAsync(ShopArticle shopArticle, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                if (shopArticle is null)
                    throw new ArgumentNullException(nameof(shopArticle));

                return await GetAsync(shopArticle.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceOffering"/> items as an asynchronous stream for the specified shop article using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="shopArticleId">The unique identifier of the shop article for which to enumerate the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceOffering> StreamAsync(long shopArticleId, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceOffering>(shopArticleId, "service_offerings", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceOffering"/> items as an asynchronous stream for the specified shop article using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="shopArticle">The shop article for which to enumerate the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceOffering> StreamAsync(ShopArticle shopArticle, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                if (shopArticle is null)
                    throw new ArgumentNullException(nameof(shopArticle));

                return StreamAsync(shopArticle.Id, query, ct);
            }
        }
    }
}
