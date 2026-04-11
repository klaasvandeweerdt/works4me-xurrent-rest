using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Invoice"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/invoices/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class InvoiceClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Invoice"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Invoice"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceClient"/> class.
        /// </summary>
        internal InvoiceClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "invoices/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Invoice"/> using the specified <see cref="InvoiceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which invoices to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Invoice"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Invoice>> GetAsync(InvoiceQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Invoice>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Invoice"/> items as an asynchronous stream using the specified <see cref="InvoiceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which invoices to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Invoice"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Invoice> StreamAsync(InvoiceQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Invoice>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Invoice"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Invoice"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Invoice?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Invoice>(new InvoiceQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Invoice"/>.
        /// </summary>
        /// <param name="invoice">The invoice to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Invoice"/>.</returns>
        public async Task<Invoice> CreateAsync(Invoice invoice, CancellationToken ct = default)
        {
            return await PostItemAsync(invoice, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="Invoice"/>.
        /// </summary>
        /// <param name="invoice">The invoice to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Invoice"/>.</returns>
        public async Task<Invoice> UpdateAsync(Invoice invoice, CancellationToken ct = default)
        {
            return await PatchItemAsync(invoice, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Invoice"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly InvoiceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(InvoiceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified invoice using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="invoiceId">The unique identifier of the invoice for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long invoiceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(invoiceId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified invoice using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="invoice">The invoice for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Invoice invoice, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (invoice is null)
                    throw new ArgumentNullException(nameof(invoice));

                return await GetAsync(invoice.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified invoice using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="invoiceId">The unique identifier of the invoice for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long invoiceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(invoiceId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified invoice using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="invoice">The invoice for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Invoice invoice, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (invoice is null)
                    throw new ArgumentNullException(nameof(invoice));

                return StreamAsync(invoice.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Invoice"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly InvoiceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(InvoiceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified invoice using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="invoiceId">The unique identifier of the invoice for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long invoiceId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(invoiceId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified invoice using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="invoice">The invoice for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(Invoice invoice, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (invoice is null)
                    throw new ArgumentNullException(nameof(invoice));

                return await GetAsync(invoice.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified invoice using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="invoiceId">The unique identifier of the invoice for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long invoiceId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(invoiceId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified invoice using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="invoice">The invoice for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(Invoice invoice, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (invoice is null)
                    throw new ArgumentNullException(nameof(invoice));

                return StreamAsync(invoice.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to an <see cref="Invoice"/>.
            /// </summary>
            /// <param name="invoiceId">The identifier of the invoice.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long invoiceId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(invoiceId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to an <see cref="Invoice"/>.
            /// </summary>
            /// <param name="invoiceId">The identifier of the invoice.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long invoiceId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(invoiceId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to an <see cref="Invoice"/>.
            /// </summary>
            /// <param name="invoice">The invoice from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Invoice invoice, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (invoice is null)
                    throw new ArgumentNullException(nameof(invoice));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(invoice.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to an <see cref="Invoice"/>.
            /// </summary>
            /// <param name="invoice">The invoice from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Invoice invoice, long configurationItemId, CancellationToken ct = default)
            {
                if (invoice is null)
                    throw new ArgumentNullException(nameof(invoice));

                return await AddAsync(invoice.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with an <see cref="Invoice"/>.
            /// </summary>
            /// <param name="invoiceId">The identifier of the invoice.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long invoiceId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(invoiceId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with an <see cref="Invoice"/>.
            /// </summary>
            /// <param name="invoiceId">The identifier of the invoice.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long invoiceId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(invoiceId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with an <see cref="Invoice"/>.
            /// </summary>
            /// <param name="invoice">The invoice from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Invoice invoice, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (invoice is null)
                    throw new ArgumentNullException(nameof(invoice));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(invoice.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with an <see cref="Invoice"/>.
            /// </summary>
            /// <param name="invoice">The invoice from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Invoice invoice, long configurationItemId, CancellationToken ct = default)
            {
                if (invoice is null)
                    throw new ArgumentNullException(nameof(invoice));

                return await RemoveAsync(invoice.Id, configurationItemId, ct).ConfigureAwait(false);
            }
        }
    }
}
