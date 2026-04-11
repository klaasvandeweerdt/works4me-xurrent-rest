using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Calendar"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/calendars/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class CalendarClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Holiday"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public HolidaysClient Holidays { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="CalendarHour"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public HoursClient Hours { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceOffering"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public ServiceOfferingsClient ServiceOfferings { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Team"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public TeamsClient Teams { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarClient"/> class.
        /// </summary>
        internal CalendarClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "calendars/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Holidays = new HolidaysClient(this);
            Hours = new HoursClient(this);
            ServiceOfferings = new ServiceOfferingsClient(this);
            Teams = new TeamsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Calendar"/> using the specified <see cref="CalendarQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which calendars to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Calendar"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Calendar>> GetAsync(CalendarQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Calendar>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Calendar"/> items as an asynchronous stream using the specified <see cref="CalendarQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which calendars to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Calendar"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Calendar> StreamAsync(CalendarQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Calendar>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Calendar"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the calendar.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Calendar"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Calendar?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Calendar>(new CalendarQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Calendar"/>.
        /// </summary>
        /// <param name="calendar">The calendar to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Calendar"/>.</returns>
        public async Task<Calendar> CreateAsync(Calendar calendar, CancellationToken ct = default)
        {
            return await PostItemAsync(calendar, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Calendar"/>.
        /// </summary>
        /// <param name="calendar">The calendar to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Calendar"/>.</returns>
        public async Task<Calendar> UpdateAsync(Calendar calendar, CancellationToken ct = default)
        {
            return await PatchItemAsync(calendar, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly CalendarClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(CalendarClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified calendar using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long calendarId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(calendarId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified calendar using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Calendar calendar, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await GetAsync(calendar.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified calendar using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long calendarId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(calendarId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified calendar using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Calendar calendar, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return StreamAsync(calendar.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Holiday"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public sealed class HolidaysClient
        {
            private readonly CalendarClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="HolidaysClient"/> class.
            /// </summary>
            internal HolidaysClient(CalendarClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Holiday"/> records for the specified calendar using an <see cref="HolidayQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to retrieve the holidays.</param>
            /// <param name="query">The query that defines which holidays to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Holiday"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Holiday>> GetAsync(long calendarId, HolidayQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Holiday>(calendarId, "holidays", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Holiday"/> records for the specified calendar using an <see cref="HolidayQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to retrieve the holidays.</param>
            /// <param name="query">The query that defines which holidays to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Holiday"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Holiday>> GetAsync(Calendar calendar, HolidayQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await GetAsync(calendar.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Holiday"/> items as an asynchronous stream for the specified calendar using an <see cref="HolidayQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to enumerate the holidays.</param>
            /// <param name="query">The query that defines which holidays to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Holiday"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Holiday> StreamAsync(long calendarId, HolidayQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Holiday>(calendarId, "holidays", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Holiday"/> items as an asynchronous stream for the specified calendar using an <see cref="HolidayQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to enumerate the holidays.</param>
            /// <param name="query">The query that defines which holidays to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Holiday"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Holiday> StreamAsync(Calendar calendar, HolidayQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return StreamAsync(calendar.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Holiday"/> to a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="holidayId">The identifier of the holiday to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long calendarId, long holidayId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(calendarId, "holidays", holidayId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Holiday"/> to a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="holiday">The holiday to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long calendarId, Holiday holiday, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return await AddAsync(calendarId, holiday.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Holiday"/> to a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar from which the holiday is removed.</param>
            /// <param name="holiday">The holiday to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Calendar calendar, Holiday holiday, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return await AddAsync(calendar.Id, holiday.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Holiday"/> to a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar from which the holiday is removed.</param>
            /// <param name="holidayId">The identifier of the holiday to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Calendar calendar, long holidayId, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await AddAsync(calendar.Id, holidayId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Holiday"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="holidayId">The identifier of the holiday to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long calendarId, long holidayId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(calendarId, "holidays", holidayId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Holiday"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="holiday">The holiday to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long calendarId, Holiday holiday, CancellationToken ct = default)
            {
                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return await RemoveAsync(calendarId, holiday.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Holiday"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar from which the holiday is removed.</param>
            /// <param name="holiday">The holiday to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Calendar calendar, Holiday holiday, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                if (holiday is null)
                    throw new ArgumentNullException(nameof(holiday));

                return await RemoveAsync(calendar.Id, holiday.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Holiday"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar from which the holiday is removed.</param>
            /// <param name="holidayId">The identifier of the holiday to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Calendar calendar, long holidayId, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await RemoveAsync(calendar.Id, holidayId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all holidays associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long calendarId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(calendarId, "holidays", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all holidays associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar from which all holidays are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Calendar calendar, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await RemoveAllAsync(calendar.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="CalendarHour"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public sealed class HoursClient
        {
            private readonly CalendarClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="HoursClient"/> class.
            /// </summary>
            internal HoursClient(CalendarClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="CalendarHour"/> records for the specified calendar using an <see cref="CalendarHourQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to retrieve the hours.</param>
            /// <param name="query">The query that defines which hours to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="CalendarHour"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<CalendarHour>> GetAsync(long calendarId, CalendarHourQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<CalendarHour>(calendarId, "calendar_hours", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="CalendarHour"/> records for the specified calendar using an <see cref="CalendarHourQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to retrieve the hours.</param>
            /// <param name="query">The query that defines which hours to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="CalendarHour"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<CalendarHour>> GetAsync(Calendar calendar, CalendarHourQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await GetAsync(calendar.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="CalendarHour"/> items as an asynchronous stream for the specified calendar using an <see cref="CalendarHourQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to enumerate the hours.</param>
            /// <param name="query">The query that defines which hours to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="CalendarHour"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<CalendarHour> StreamAsync(long calendarId, CalendarHourQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<CalendarHour>(calendarId, "calendar_hours", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="CalendarHour"/> items as an asynchronous stream for the specified calendar using an <see cref="CalendarHourQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to enumerate the hours.</param>
            /// <param name="query">The query that defines which hours to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="CalendarHour"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<CalendarHour> StreamAsync(Calendar calendar, CalendarHourQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return StreamAsync(calendar.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="CalendarHour"/> by its unique identifier for the specified calendar.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar.</param>
            /// <param name="calendarHourId">The unique identifier of the calendar hour.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="CalendarHour"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<CalendarHour?> GetAsync(long calendarId, long calendarHourId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<CalendarHour>(calendarId, "calendar_hours", new CalendarHourQuery().WithId(calendarHourId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="CalendarHour"/> record for the specified calendar.
            /// </summary>
            /// <param name="calendar">The calendar for which to retrieve the calendar hour.</param>
            /// <param name="calendarHourId">The unique identifier of the calendar hour.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="CalendarHour"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<CalendarHour?> GetAsync(Calendar calendar, long calendarHourId, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await GetAsync(calendar.Id, calendarHourId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="CalendarHour"/> to a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="calendarHour">The calendar hour to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="CalendarHour"/>.</returns>
            public async Task<CalendarHour> CreateAsync(long calendarId, CalendarHour calendarHour, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(calendarId, "calendar_hours", calendarHour, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="CalendarHour"/> to a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar to which the calendar hour is added.</param>
            /// <param name="calendarHour">The calendar hour to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="CalendarHour"/>.</returns>
            public async Task<CalendarHour> CreateAsync(Calendar calendar, CalendarHour calendarHour, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await CreateAsync(calendar.Id, calendarHour, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="CalendarHour"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="calendarHour">The calendar hour to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="CalendarHour"/>.</returns>
            public async Task<CalendarHour> UpdateAsync(long calendarId, CalendarHour calendarHour, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(calendarId, "calendar_hours", calendarHour, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="CalendarHour"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar with which the calendar hour is associated.</param>
            /// <param name="calendarHour">The calendar hour to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="CalendarHour"/>.</returns>
            public async Task<CalendarHour> UpdateAsync(Calendar calendar, CalendarHour calendarHour, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await UpdateAsync(calendar.Id, calendarHour, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="CalendarHour"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="calendarHourId">The identifier of the calendar hour to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long calendarId, long calendarHourId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(calendarId, "calendar_hours", calendarHourId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="CalendarHour"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="calendarHour">The calendar hour to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long calendarId, CalendarHour calendarHour, CancellationToken ct = default)
            {
                if (calendarHour is null)
                    throw new ArgumentNullException(nameof(calendarHour));

                return await DeleteAsync(calendarId, calendarHour.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="CalendarHour"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar from which the calendar hour is removed.</param>
            /// <param name="calendarHour">The calendar hour to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Calendar calendar, CalendarHour calendarHour, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                if (calendarHour is null)
                    throw new ArgumentNullException(nameof(calendarHour));

                return await DeleteAsync(calendar.Id, calendarHour.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="CalendarHour"/> associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar from which the calendar hour is removed.</param>
            /// <param name="calendarHourId">The identifier of the calendar hour to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Calendar calendar, long calendarHourId, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await DeleteAsync(calendar.Id, calendarHourId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all calendar hours associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendarId">The identifier of the calendar.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long calendarId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(calendarId, "calendar_hours", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all calendar hours associated with a <see cref="Calendar"/>.
            /// </summary>
            /// <param name="calendar">The calendar from which all calendar hours are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Calendar calendar, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await DeleteAllAsync(calendar.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceOffering"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public sealed class ServiceOfferingsClient
        {
            private readonly CalendarClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceOfferingsClient"/> class.
            /// </summary>
            internal ServiceOfferingsClient(CalendarClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceOffering"/> records for the specified calendar using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to retrieve the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceOffering>> GetAsync(long calendarId, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceOffering>(calendarId, "service_offerings", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceOffering"/> records for the specified calendar using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to retrieve the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceOffering>> GetAsync(Calendar calendar, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await GetAsync(calendar.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceOffering"/> items as an asynchronous stream for the specified calendar using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to enumerate the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceOffering> StreamAsync(long calendarId, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceOffering>(calendarId, "service_offerings", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceOffering"/> items as an asynchronous stream for the specified calendar using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to enumerate the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceOffering> StreamAsync(Calendar calendar, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return StreamAsync(calendar.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Team"/> records related to an <see cref="Calendar"/>.
        /// </summary>
        public sealed class TeamsClient
        {
            private readonly CalendarClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TeamsClient"/> class.
            /// </summary>
            internal TeamsClient(CalendarClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Team"/> records for the specified calendar using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to retrieve the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Team"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Team>> GetAsync(long calendarId, TeamQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Team>(calendarId, "teams", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Team"/> records for the specified calendar using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to retrieve the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Team"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Team>> GetAsync(Calendar calendar, TeamQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return await GetAsync(calendar.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Team"/> items as an asynchronous stream for the specified calendar using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="calendarId">The unique identifier of the calendar for which to enumerate the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Team"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Team> StreamAsync(long calendarId, TeamQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Team>(calendarId, "teams", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Team"/> items as an asynchronous stream for the specified calendar using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="calendar">The calendar for which to enumerate the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Team"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Team> StreamAsync(Calendar calendar, TeamQuery query, CancellationToken ct = default)
            {
                if (calendar is null)
                    throw new ArgumentNullException(nameof(calendar));

                return StreamAsync(calendar.Id, query, ct);
            }
        }
    }
}
