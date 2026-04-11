using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Reservation"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/reservations/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ReservationClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Reservation"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationClient"/> class.
        /// </summary>
        internal ReservationClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "reservations/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Reservation"/> using the specified <see cref="ReservationQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which reservations to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Reservation"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Reservation>> GetAsync(ReservationQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Reservation>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Reservation"/> items as an asynchronous stream using the specified <see cref="ReservationQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which reservations to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Reservation"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Reservation> StreamAsync(ReservationQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Reservation>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Reservation"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the reservation.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Reservation"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Reservation?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Reservation>(new ReservationQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Reservation"/>.
        /// </summary>
        /// <param name="reservation">The reservation to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Reservation"/>.</returns>
        public async Task<Reservation> CreateAsync(Reservation reservation, CancellationToken ct = default)
        {
            return await PostItemAsync(reservation, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Reservation"/>.
        /// </summary>
        /// <param name="reservation">The reservation to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Reservation"/>.</returns>
        public async Task<Reservation> UpdateAsync(Reservation reservation, CancellationToken ct = default)
        {
            return await PatchItemAsync(reservation, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Reservation"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ReservationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ReservationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified reservation using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="reservationId">The unique identifier of the reservation for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long reservationId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(reservationId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified reservation using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="reservation">The reservation for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Reservation reservation, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (reservation is null)
                    throw new ArgumentNullException(nameof(reservation));

                return await GetAsync(reservation.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified reservation using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="reservationId">The unique identifier of the reservation for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long reservationId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(reservationId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified reservation using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="reservation">The reservation for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Reservation reservation, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (reservation is null)
                    throw new ArgumentNullException(nameof(reservation));

                return StreamAsync(reservation.Id, query, ct);
            }
        }
    }
}
