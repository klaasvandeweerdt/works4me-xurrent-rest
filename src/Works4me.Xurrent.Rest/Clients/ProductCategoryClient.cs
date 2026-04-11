using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ProductCategory"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/product_categories/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ProductCategoryClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ProductCategory"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoryClient"/> class.
        /// </summary>
        internal ProductCategoryClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "product_categories/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ProductCategory"/> using the specified <see cref="ProductCategoryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which product categories to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ProductCategory"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ProductCategory>> GetAsync(ProductCategoryQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ProductCategory>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ProductCategory"/> items as an asynchronous stream using the specified <see cref="ProductCategoryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which product categories to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProductCategory"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ProductCategory> StreamAsync(ProductCategoryQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ProductCategory>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ProductCategory"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product category.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ProductCategory"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ProductCategory?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ProductCategory>(new ProductCategoryQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ProductCategory"/>.
        /// </summary>
        /// <param name="productCategory">The product category to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ProductCategory"/>.</returns>
        public async Task<ProductCategory> CreateAsync(ProductCategory productCategory, CancellationToken ct = default)
        {
            return await PostItemAsync(productCategory, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ProductCategory"/>.
        /// </summary>
        /// <param name="productCategory">The product category to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ProductCategory"/>.</returns>
        public async Task<ProductCategory> UpdateAsync(ProductCategory productCategory, CancellationToken ct = default)
        {
            return await PatchItemAsync(productCategory, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ProductCategory"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ProductCategoryClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ProductCategoryClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified product category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productCategoryId">The unique identifier of the product category for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long productCategoryId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(productCategoryId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified product category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productCategory">The product category for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ProductCategory productCategory, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (productCategory is null)
                    throw new ArgumentNullException(nameof(productCategory));

                return await GetAsync(productCategory.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified product category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productCategoryId">The unique identifier of the product category for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long productCategoryId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(productCategoryId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified product category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productCategory">The product category for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ProductCategory productCategory, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (productCategory is null)
                    throw new ArgumentNullException(nameof(productCategory));

                return StreamAsync(productCategory.Id, query, ct);
            }
        }
    }
}
