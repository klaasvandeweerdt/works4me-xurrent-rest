using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ReservationOffering"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/reservation_offerings/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ReservationOfferingClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ReservationOffering"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="ReservationOffering"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="RequestTemplate"/> records related to an <see cref="ReservationOffering"/>.
        /// </summary>
        public RequestTemplatesClient RequestTemplates { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationOfferingClient"/> class.
        /// </summary>
        internal ReservationOfferingClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "reservation_offerings/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
            RequestTemplates = new RequestTemplatesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ReservationOffering"/> using the specified <see cref="ReservationOfferingQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which reservation offerings to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ReservationOffering"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ReservationOffering>> GetAsync(ReservationOfferingQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ReservationOffering>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ReservationOffering"/> items as an asynchronous stream using the specified <see cref="ReservationOfferingQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which reservation offerings to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ReservationOffering"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ReservationOffering> StreamAsync(ReservationOfferingQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ReservationOffering>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ReservationOffering"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the reservation offering.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ReservationOffering"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ReservationOffering?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ReservationOffering>(new ReservationOfferingQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ReservationOffering"/>.
        /// </summary>
        /// <param name="reservationOffering">The reservation offering to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ReservationOffering"/>.</returns>
        public async Task<ReservationOffering> CreateAsync(ReservationOffering reservationOffering, CancellationToken ct = default)
        {
            return await PostItemAsync(reservationOffering, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ReservationOffering"/>.
        /// </summary>
        /// <param name="reservationOffering">The reservation offering to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ReservationOffering"/>.</returns>
        public async Task<ReservationOffering> UpdateAsync(ReservationOffering reservationOffering, CancellationToken ct = default)
        {
            return await PatchItemAsync(reservationOffering, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ReservationOffering"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ReservationOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ReservationOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified reservation offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="reservationOfferingId">The unique identifier of the reservation offering for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long reservationOfferingId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(reservationOfferingId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified reservation offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="reservationOffering">The reservation offering for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ReservationOffering reservationOffering, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (reservationOffering is null)
                    throw new ArgumentNullException(nameof(reservationOffering));

                return await GetAsync(reservationOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified reservation offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="reservationOfferingId">The unique identifier of the reservation offering for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long reservationOfferingId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(reservationOfferingId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified reservation offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="reservationOffering">The reservation offering for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ReservationOffering reservationOffering, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (reservationOffering is null)
                    throw new ArgumentNullException(nameof(reservationOffering));

                return StreamAsync(reservationOffering.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="ReservationOffering"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly ReservationOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(ReservationOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified reservation offering using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="reservationOfferingId">The unique identifier of the reservation offering for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long reservationOfferingId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(reservationOfferingId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified reservation offering using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="reservationOffering">The reservation offering for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(ReservationOffering reservationOffering, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (reservationOffering is null)
                    throw new ArgumentNullException(nameof(reservationOffering));

                return await GetAsync(reservationOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified reservation offering using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="reservationOfferingId">The unique identifier of the reservation offering for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long reservationOfferingId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(reservationOfferingId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified reservation offering using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="reservationOffering">The reservation offering for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(ReservationOffering reservationOffering, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (reservationOffering is null)
                    throw new ArgumentNullException(nameof(reservationOffering));

                return StreamAsync(reservationOffering.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="RequestTemplate"/> records related to an <see cref="ReservationOffering"/>.
        /// </summary>
        public sealed class RequestTemplatesClient
        {
            private readonly ReservationOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RequestTemplatesClient"/> class.
            /// </summary>
            internal RequestTemplatesClient(ReservationOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="RequestTemplate"/> records for the specified reservation offering using an <see cref="RequestTemplateQuery"/>.
            /// </summary>
            /// <param name="reservationOfferingId">The unique identifier of the reservation offering for which to retrieve the request templates.</param>
            /// <param name="query">The query that defines which request templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="RequestTemplate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<RequestTemplate>> GetAsync(long reservationOfferingId, RequestTemplateQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<RequestTemplate>(reservationOfferingId, "request_templates", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="RequestTemplate"/> records for the specified reservation offering using an <see cref="RequestTemplateQuery"/>.
            /// </summary>
            /// <param name="reservationOffering">The reservation offering for which to retrieve the request templates.</param>
            /// <param name="query">The query that defines which request templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="RequestTemplate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<RequestTemplate>> GetAsync(ReservationOffering reservationOffering, RequestTemplateQuery query, CancellationToken ct = default)
            {
                if (reservationOffering is null)
                    throw new ArgumentNullException(nameof(reservationOffering));

                return await GetAsync(reservationOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="RequestTemplate"/> items as an asynchronous stream for the specified reservation offering using an <see cref="RequestTemplateQuery"/>.
            /// </summary>
            /// <param name="reservationOfferingId">The unique identifier of the reservation offering for which to enumerate the request templates.</param>
            /// <param name="query">The query that defines which request templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RequestTemplate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<RequestTemplate> StreamAsync(long reservationOfferingId, RequestTemplateQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<RequestTemplate>(reservationOfferingId, "request_templates", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="RequestTemplate"/> items as an asynchronous stream for the specified reservation offering using an <see cref="RequestTemplateQuery"/>.
            /// </summary>
            /// <param name="reservationOffering">The reservation offering for which to enumerate the request templates.</param>
            /// <param name="query">The query that defines which request templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RequestTemplate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<RequestTemplate> StreamAsync(ReservationOffering reservationOffering, RequestTemplateQuery query, CancellationToken ct = default)
            {
                if (reservationOffering is null)
                    throw new ArgumentNullException(nameof(reservationOffering));

                return StreamAsync(reservationOffering.Id, query, ct);
            }
        }
    }
}
