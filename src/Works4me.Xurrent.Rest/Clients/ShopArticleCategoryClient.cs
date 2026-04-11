using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ShopArticleCategory"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/shop_article_categories/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ShopArticleCategoryClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ShopArticleCategory"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopArticleCategoryClient"/> class.
        /// </summary>
        internal ShopArticleCategoryClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "shop_article_categories/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ShopArticleCategory"/> using the specified <see cref="ShopArticleCategoryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which shop article categories to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ShopArticleCategory"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ShopArticleCategory>> GetAsync(ShopArticleCategoryQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ShopArticleCategory>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ShopArticleCategory"/> items as an asynchronous stream using the specified <see cref="ShopArticleCategoryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which shop article categories to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ShopArticleCategory"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ShopArticleCategory> StreamAsync(ShopArticleCategoryQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ShopArticleCategory>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ShopArticleCategory"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the shop article category.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ShopArticleCategory"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ShopArticleCategory?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ShopArticleCategory>(new ShopArticleCategoryQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ShopArticleCategory"/>.
        /// </summary>
        /// <param name="shopArticleCategory">The shop article category to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ShopArticleCategory"/>.</returns>
        public async Task<ShopArticleCategory> CreateAsync(ShopArticleCategory shopArticleCategory, CancellationToken ct = default)
        {
            return await PostItemAsync(shopArticleCategory, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ShopArticleCategory"/>.
        /// </summary>
        /// <param name="shopArticleCategory">The shop article category to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ShopArticleCategory"/>.</returns>
        public async Task<ShopArticleCategory> UpdateAsync(ShopArticleCategory shopArticleCategory, CancellationToken ct = default)
        {
            return await PatchItemAsync(shopArticleCategory, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ShopArticleCategory"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ShopArticleCategoryClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ShopArticleCategoryClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified shop article category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopArticleCategoryId">The unique identifier of the shop article category for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long shopArticleCategoryId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(shopArticleCategoryId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified shop article category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopArticleCategory">The shop article category for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ShopArticleCategory shopArticleCategory, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (shopArticleCategory is null)
                    throw new ArgumentNullException(nameof(shopArticleCategory));

                return await GetAsync(shopArticleCategory.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified shop article category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopArticleCategoryId">The unique identifier of the shop article category for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long shopArticleCategoryId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(shopArticleCategoryId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified shop article category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopArticleCategory">The shop article category for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ShopArticleCategory shopArticleCategory, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (shopArticleCategory is null)
                    throw new ArgumentNullException(nameof(shopArticleCategory));

                return StreamAsync(shopArticleCategory.Id, query, ct);
            }
        }
    }
}
