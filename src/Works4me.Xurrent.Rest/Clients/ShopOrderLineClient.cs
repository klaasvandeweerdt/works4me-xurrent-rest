using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ShopOrderLine"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/shop_order_lines/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ShopOrderLineClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ShopOrderLine"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopOrderLineClient"/> class.
        /// </summary>
        internal ShopOrderLineClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "shop_order_lines/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ShopOrderLine"/> using the specified <see cref="ShopOrderLineQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which shop order lines to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ShopOrderLine"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ShopOrderLine>> GetAsync(ShopOrderLineQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ShopOrderLine>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ShopOrderLine"/> items as an asynchronous stream using the specified <see cref="ShopOrderLineQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which shop order lines to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ShopOrderLine"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ShopOrderLine> StreamAsync(ShopOrderLineQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ShopOrderLine>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ShopOrderLine"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the shop order line.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ShopOrderLine"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ShopOrderLine?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ShopOrderLine>(new ShopOrderLineQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ShopOrderLine"/>.
        /// </summary>
        /// <param name="shopOrderLine">The shop order line to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ShopOrderLine"/>.</returns>
        public async Task<ShopOrderLine> CreateAsync(ShopOrderLine shopOrderLine, CancellationToken ct = default)
        {
            return await PostItemAsync(shopOrderLine, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ShopOrderLine"/>.
        /// </summary>
        /// <param name="shopOrderLine">The shop order line to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ShopOrderLine"/>.</returns>
        public async Task<ShopOrderLine> UpdateAsync(ShopOrderLine shopOrderLine, CancellationToken ct = default)
        {
            return await PatchItemAsync(shopOrderLine, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ShopOrderLine"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ShopOrderLineClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ShopOrderLineClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified shop order line using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopOrderLineId">The unique identifier of the shop order line for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long shopOrderLineId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(shopOrderLineId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified shop order line using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopOrderLine">The shop order line for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ShopOrderLine shopOrderLine, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (shopOrderLine is null)
                    throw new ArgumentNullException(nameof(shopOrderLine));

                return await GetAsync(shopOrderLine.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified shop order line using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopOrderLineId">The unique identifier of the shop order line for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long shopOrderLineId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(shopOrderLineId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified shop order line using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="shopOrderLine">The shop order line for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ShopOrderLine shopOrderLine, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (shopOrderLine is null)
                    throw new ArgumentNullException(nameof(shopOrderLine));

                return StreamAsync(shopOrderLine.Id, query, ct);
            }
        }
    }
}
