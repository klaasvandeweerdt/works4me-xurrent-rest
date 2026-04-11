using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Product"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/products/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ProductClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Product"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Product"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductClient"/> class.
        /// </summary>
        internal ProductClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "products/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Product"/> using the specified <see cref="ProductQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which products to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Product"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Product>> GetAsync(ProductQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Product>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Product"/> items as an asynchronous stream using the specified <see cref="ProductQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which products to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Product"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Product> StreamAsync(ProductQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Product>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Product"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Product"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Product?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Product>(new ProductQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Product"/>.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Product"/>.</returns>
        public async Task<Product> CreateAsync(Product product, CancellationToken ct = default)
        {
            return await PostItemAsync(product, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Product"/>.
        /// </summary>
        /// <param name="product">The product to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Product"/>.</returns>
        public async Task<Product> UpdateAsync(Product product, CancellationToken ct = default)
        {
            return await PatchItemAsync(product, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Product"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ProductClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ProductClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified product using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productId">The unique identifier of the product for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long productId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(productId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified product using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="product">The product for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Product product, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (product is null)
                    throw new ArgumentNullException(nameof(product));

                return await GetAsync(product.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified product using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="productId">The unique identifier of the product for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long productId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(productId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified product using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="product">The product for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Product product, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (product is null)
                    throw new ArgumentNullException(nameof(product));

                return StreamAsync(product.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Product"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly ProductClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(ProductClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified product using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="productId">The unique identifier of the product for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long productId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(productId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified product using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="product">The product for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(Product product, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (product is null)
                    throw new ArgumentNullException(nameof(product));

                return await GetAsync(product.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified product using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="productId">The unique identifier of the product for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long productId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(productId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified product using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="product">The product for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(Product product, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (product is null)
                    throw new ArgumentNullException(nameof(product));

                return StreamAsync(product.Id, query, ct);
            }
        }
    }
}
