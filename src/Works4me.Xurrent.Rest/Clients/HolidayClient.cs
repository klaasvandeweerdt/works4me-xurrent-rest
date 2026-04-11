using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Holiday"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/holidays/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class HolidayClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Holiday"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Calendar"/> records related to an <see cref="Holiday"/>.
        /// </summary>
        public CalendarsClient Calendars { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HolidayClient"/> class.
        /// </summary>
        internal HolidayClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "holidays/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Calendars = new CalendarsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Holiday"/> using the specified <see cref="HolidayQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which holidays to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Holiday"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Holiday>> GetAsync(HolidayQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Holiday>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Holiday"/> items as an asynchronous stream using the specified <see cref="HolidayQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which holidays to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Holiday"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Holiday> StreamAsync(HolidayQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Holiday>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Holiday"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the holiday.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Holiday"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Holiday?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Holiday>(new HolidayQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Holiday"/>.
        /// </summary>
        /// <param name="holiday">The holiday to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Holiday"/>.</returns>
        public async Task<Holiday> CreateAsync(Holiday holiday, CancellationToken ct = default)
        {
            return await PostItemAsync(holiday, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Holiday"/>.
        /// </summary>
        /// <param name="holiday">The holiday to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Holiday"/>.</returns>
        public async Task<Holiday> UpdateAsync(Holiday holiday, CancellationToken ct = default)
        {
            return await PatchItemAsync(holiday, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Holiday"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly HolidayClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(HolidayClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified holiday using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="holidayId">The unique identifier of the holiday for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long holidayId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(holidayId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified holiday using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="holiday">The holiday for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Holiday holiday, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return await GetAsync(holiday.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified holiday using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="holidayId">The unique identifier of the holiday for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long holidayId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(holidayId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified holiday using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="holiday">The holiday for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Holiday holiday, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return StreamAsync(holiday.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Calendar"/> records related to an <see cref="Holiday"/>.
        /// </summary>
        public sealed class CalendarsClient
        {
            private readonly HolidayClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="CalendarsClient"/> class.
            /// </summary>
            internal CalendarsClient(HolidayClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Calendar"/> records for the specified holiday using an <see cref="CalendarQuery"/>.
            /// </summary>
            /// <param name="holidayId">The unique identifier of the holiday for which to retrieve the calendars.</param>
            /// <param name="query">The query that defines which calendars to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Calendar"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Calendar>> GetAsync(long holidayId, CalendarQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Calendar>(holidayId, "calendars", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Calendar"/> records for the specified holiday using an <see cref="CalendarQuery"/>.
            /// </summary>
            /// <param name="holiday">The holiday for which to retrieve the calendars.</param>
            /// <param name="query">The query that defines which calendars to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Calendar"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Calendar>> GetAsync(Holiday holiday, CalendarQuery query, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return await GetAsync(holiday.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Calendar"/> items as an asynchronous stream for the specified holiday using an <see cref="CalendarQuery"/>.
            /// </summary>
            /// <param name="holidayId">The unique identifier of the holiday for which to enumerate the calendars.</param>
            /// <param name="query">The query that defines which calendars to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Calendar"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Calendar> StreamAsync(long holidayId, CalendarQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Calendar>(holidayId, "calendars", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Calendar"/> items as an asynchronous stream for the specified holiday using an <see cref="CalendarQuery"/>.
            /// </summary>
            /// <param name="holiday">The holiday for which to enumerate the calendars.</param>
            /// <param name="query">The query that defines which calendars to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Calendar"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Calendar> StreamAsync(Holiday holiday, CalendarQuery query, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return StreamAsync(holiday.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Calendar"/> to a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holidayId">The identifier of the holiday.</param>
            /// <param name="calendarId">The identifier of the calendar to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long holidayId, long calendarId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(holidayId, "calendars", calendarId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Calendar"/> to a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holidayId">The identifier of the holiday.</param>
            /// <param name="calendar">The calendar to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long holidayId, Calendar calendar, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await AddAsync(holidayId, calendar.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Calendar"/> to a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holiday">The holiday from which the calendar is removed.</param>
            /// <param name="calendar">The calendar to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Holiday holiday, Calendar calendar, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await AddAsync(holiday.Id, calendar.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Calendar"/> to a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holiday">The holiday from which the calendar is removed.</param>
            /// <param name="calendarId">The identifier of the calendar to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Holiday holiday, long calendarId, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return await AddAsync(holiday.Id, calendarId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Calendar"/> associated with a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holidayId">The identifier of the holiday.</param>
            /// <param name="calendarId">The identifier of the calendar to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long holidayId, long calendarId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(holidayId, "calendars", calendarId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Calendar"/> associated with a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holidayId">The identifier of the holiday.</param>
            /// <param name="calendar">The calendar to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long holidayId, Calendar calendar, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await RemoveAsync(holidayId, calendar.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Calendar"/> associated with a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holiday">The holiday from which the calendar is removed.</param>
            /// <param name="calendar">The calendar to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Holiday holiday, Calendar calendar, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await RemoveAsync(holiday.Id, calendar.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Calendar"/> associated with a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holiday">The holiday from which the calendar is removed.</param>
            /// <param name="calendarId">The identifier of the calendar to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Holiday holiday, long calendarId, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return await RemoveAsync(holiday.Id, calendarId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all calendars associated with a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holidayId">The identifier of the holiday.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long holidayId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(holidayId, "calendars", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all calendars associated with a <see cref="Holiday"/>.
            /// </summary>
            /// <param name="holiday">The holiday from which all calendars are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Holiday holiday, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return await RemoveAllAsync(holiday.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
