using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ProductBacklog"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/product_backlogs/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ProductBacklogClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ProductBacklog"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ProductBacklogItem"/> records related to an <see cref="ProductBacklog"/>.
        /// </summary>
        public ItemsClient Items { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBacklogClient"/> class.
        /// </summary>
        internal ProductBacklogClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "product_backlogs/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Items = new ItemsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ProductBacklog"/> using the specified <see cref="ProductBacklogQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which product backlogs to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ProductBacklog"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ProductBacklog>> GetAsync(ProductBacklogQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ProductBacklog>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ProductBacklog"/> items as an asynchronous stream using the specified <see cref="ProductBacklogQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which product backlogs to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProductBacklog"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ProductBacklog> StreamAsync(ProductBacklogQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ProductBacklog>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ProductBacklog"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product backlog.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ProductBacklog"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ProductBacklog?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ProductBacklog>(new ProductBacklogQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ProductBacklog"/>.
        /// </summary>
        /// <param name="productBacklog">The product backlog to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ProductBacklog"/>.</returns>
        public async Task<ProductBacklog> CreateAsync(ProductBacklog productBacklog, CancellationToken ct = default)
        {
            return await PostItemAsync(productBacklog, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ProductBacklog"/>.
        /// </summary>
        /// <param name="productBacklog">The product backlog to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ProductBacklog"/>.</returns>
        public async Task<ProductBacklog> UpdateAsync(ProductBacklog productBacklog, CancellationToken ct = default)
        {
            return await PatchItemAsync(productBacklog, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ProductBacklog"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ProductBacklogClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ProductBacklogClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified product backlog using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productBacklogId">The unique identifier of the product backlog for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long productBacklogId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(productBacklogId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified product backlog using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productBacklog">The product backlog for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ProductBacklog productBacklog, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (productBacklog is null)
                    throw new ArgumentNullException(nameof(productBacklog));

                return await GetAsync(productBacklog.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified product backlog using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productBacklogId">The unique identifier of the product backlog for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long productBacklogId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(productBacklogId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified product backlog using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productBacklog">The product backlog for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ProductBacklog productBacklog, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (productBacklog is null)
                    throw new ArgumentNullException(nameof(productBacklog));

                return StreamAsync(productBacklog.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ProductBacklogItem"/> records related to an <see cref="ProductBacklog"/>.
        /// </summary>
        public sealed class ItemsClient
        {
            private readonly ProductBacklogClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ItemsClient"/> class.
            /// </summary>
            internal ItemsClient(ProductBacklogClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ProductBacklogItem"/> records for the specified product backlog using an <see cref="ProductBacklogItemQuery"/>.
            /// </summary>
            /// <param name="productBacklogId">The unique identifier of the product backlog for which to retrieve the items.</param>
            /// <param name="query">The query that defines which items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProductBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProductBacklogItem>> GetAsync(long productBacklogId, ProductBacklogItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ProductBacklogItem>(productBacklogId, "product_backlog_items", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ProductBacklogItem"/> records for the specified product backlog using an <see cref="ProductBacklogItemQuery"/>.
            /// </summary>
            /// <param name="productBacklog">The product backlog for which to retrieve the items.</param>
            /// <param name="query">The query that defines which items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProductBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProductBacklogItem>> GetAsync(ProductBacklog productBacklog, ProductBacklogItemQuery query, CancellationToken ct = default)
            {
                if (productBacklog is null)
                    throw new ArgumentNullException(nameof(productBacklog));

                return await GetAsync(productBacklog.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ProductBacklogItem"/> items as an asynchronous stream for the specified product backlog using an <see cref="ProductBacklogItemQuery"/>.
            /// </summary>
            /// <param name="productBacklogId">The unique identifier of the product backlog for which to enumerate the items.</param>
            /// <param name="query">The query that defines which items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProductBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProductBacklogItem> StreamAsync(long productBacklogId, ProductBacklogItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ProductBacklogItem>(productBacklogId, "product_backlog_items", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ProductBacklogItem"/> items as an asynchronous stream for the specified product backlog using an <see cref="ProductBacklogItemQuery"/>.
            /// </summary>
            /// <param name="productBacklog">The product backlog for which to enumerate the items.</param>
            /// <param name="query">The query that defines which items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProductBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProductBacklogItem> StreamAsync(ProductBacklog productBacklog, ProductBacklogItemQuery query, CancellationToken ct = default)
            {
                if (productBacklog is null)
                    throw new ArgumentNullException(nameof(productBacklog));

                return StreamAsync(productBacklog.Id, query, ct);
            }
        }
    }
}
