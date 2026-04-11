using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class TimesheetClient
    {
        /// <summary>
        /// Retrieves a collection of <see cref="Timesheet"/> records for the specified organization and month.
        /// </summary>
        /// <param name="organization">The organization for which to retrieve timesheets.</param>
        /// <param name="month">A date within the month for which to retrieve timesheets.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Timesheet"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Timesheet>> GetAsync(Organization organization, DateTime month, CancellationToken ct = default)
        {
            if (organization is null)
                throw new ArgumentNullException(nameof(organization));

            TimesheetQuery query = new TimesheetQuery()
                .Where(Timesheet.FilterField.OrganizationId, FilterOperator.Equality, organization.Id)
                .Where(Timesheet.FilterField.MonthOf, FilterOperator.Equality, month.Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return await GetListAsync<Timesheet>(query, ct).ConfigureAwait(false);
        }

#if (NET6_0_OR_GREATER)
        /// <summary>
        /// Retrieves a collection of <see cref="Timesheet"/> records for the specified organization and month.
        /// </summary>
        /// <param name="organization">The organization for which to retrieve timesheets.</param>
        /// <param name="month">A date within the month for which to retrieve timesheets.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Timesheet"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Timesheet>> GetAsync(Organization organization, DateOnly month, CancellationToken ct = default)
        {
            return await GetAsync(organization, month.ToDateTime(TimeOnly.MinValue), ct).ConfigureAwait(false);
        }
#endif
        /// <summary>
        /// Retrieves a collection of <see cref="Timesheet"/> records for the specified person and month.
        /// </summary>
        /// <param name="person">The person for which to retrieve timesheets.</param>
        /// <param name="month">A date within the month for which to retrieve timesheets.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Timesheet"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Timesheet>> GetAsync(Person person, DateTime month, CancellationToken ct = default)
        {
            if (person is null)
                throw new ArgumentNullException(nameof(person));

            TimesheetQuery query = new TimesheetQuery()
                .Where(Timesheet.FilterField.PersonId, FilterOperator.Equality, person.Id)
                .Where(Timesheet.FilterField.MonthOf, FilterOperator.Equality, month.Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return await GetListAsync<Timesheet>(query, ct).ConfigureAwait(false);
        }

#if (NET6_0_OR_GREATER)
        /// <summary>
        /// Retrieves a collection of <see cref="Timesheet"/> records for the specified person and month.
        /// </summary>
        /// <param name="person">The person for which to retrieve timesheets.</param>
        /// <param name="month">A date within the month for which to retrieve timesheets.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Timesheet"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Timesheet>> GetAsync(Person person, DateOnly month, CancellationToken ct = default)
        {
            return await GetAsync(person, month.ToDateTime(TimeOnly.MinValue), ct).ConfigureAwait(false);
        }
#endif
        /// <summary>
        /// Retrieves a collection of <see cref="Timesheet"/> records for the specified person, organization, and month.
        /// </summary>
        /// <param name="person">The person for which to retrieve timesheets.</param>
        /// <param name="organization">The organization for which to retrieve timesheets.</param>
        /// <param name="month">A date within the month for which to retrieve timesheets.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Timesheet"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Timesheet>> GetAsync(Person person, Organization organization, DateTime month, CancellationToken ct = default)
        {
            if (person is null)
                throw new ArgumentNullException(nameof(person));

            if (organization is null)
                throw new ArgumentNullException(nameof(organization));

            TimesheetQuery query = new TimesheetQuery()
                .Where(Timesheet.FilterField.PersonId, FilterOperator.Equality, person.Id)
                .Where(Timesheet.FilterField.OrganizationId, FilterOperator.Equality, organization.Id)
                .Where(Timesheet.FilterField.MonthOf, FilterOperator.Equality, month.Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return await GetListAsync<Timesheet>(query, ct).ConfigureAwait(false);
        }

#if (NET6_0_OR_GREATER)
        /// <summary>
        /// Retrieves a collection of <see cref="Timesheet"/> records for the specified person, organization, and month.
        /// </summary>
        /// <param name="person">The person for which to retrieve timesheets.</param>
        /// <param name="organization">The organization for which to retrieve timesheets.</param>
        /// <param name="month">A date within the month for which to retrieve timesheets.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Timesheet"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Timesheet>> GetAsync(Person person, Organization organization, DateOnly month, CancellationToken ct = default)
        {
            return await GetAsync(person, organization, month.ToDateTime(TimeOnly.MinValue), ct).ConfigureAwait(false);
        }
#endif

        /// <summary>
        /// Retrieves a read-only dictionary containing the person's total time spent for the selected period.
        /// </summary>
        /// <param name="person">The person for which to retrieve time totals.</param>
        /// <param name="date">The date used to select the day, week, or month for which to retrieve totals.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only dictionary containing the retrieved totals.</returns>
        public async Task<ReadOnlyDictionary<DateTime, int>> GetTimeTotalsAsync(Person person, DateTime date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            return await GetTotalsAsync(person, null, date, timePeriod, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a read-only dictionary containing the person's total time spent for the selected period within the specified organization.
        /// </summary>
        /// <param name="person">The person for which to retrieve time totals.</param>
        /// <param name="organization">The organization for which to retrieve time totals.</param>
        /// <param name="date">The date used to select the day, week, or month for which to retrieve totals.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only dictionary containing the retrieved totals.</returns>
        public async Task<ReadOnlyDictionary<DateTime, int>> GetTimeTotalsAsync(Person person, Organization organization, DateTime date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            if (organization is null)
                throw new ArgumentNullException(nameof(organization));

            return await GetTotalsAsync(person, organization, date, timePeriod, ct).ConfigureAwait(false);
        }

#if (NET6_0_OR_GREATER)
        /// <summary>
        /// Retrieves a read-only dictionary containing the person's total time spent for the selected period.
        /// </summary>
        /// <param name="person">The person for which to retrieve time totals.</param>
        /// <param name="date">The date used to select the day, week, or month for which to retrieve totals.</param>
        /// <param name="aggregation">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only dictionary containing the retrieved totals.</returns>
        public async Task<ReadOnlyDictionary<DateTime, int>> GetTimeTotalsAsync(Person person, DateOnly date, TimePeriodSelector aggregation, CancellationToken ct = default)
        {
            return await GetTotalsAsync(person, null, date.ToDateTime(TimeOnly.MinValue), aggregation, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a read-only dictionary containing the person's total time spent for the selected period within the specified organization.
        /// </summary>
        /// <param name="person">The person for which to retrieve time totals.</param>
        /// <param name="organization">The organization for which to retrieve time totals.</param>
        /// <param name="date">The date used to select the day, week, or month for which to retrieve totals.</param>
        /// <param name="aggregation">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only dictionary containing the retrieved totals.</returns>
        public async Task<ReadOnlyDictionary<DateTime, int>> GetTimeTotalsAsync(Person person, Organization organization, DateOnly date, TimePeriodSelector aggregation, CancellationToken ct = default)
        {
            if (organization is null)
                throw new ArgumentNullException(nameof(organization));

            return await GetTotalsAsync(person, organization, date.ToDateTime(TimeOnly.MinValue), aggregation, ct).ConfigureAwait(false);
        }
#endif

        /// <summary>
        /// Locks timesheets for the selected period for the specified person.
        /// </summary>
        /// <param name="person">The person for which to lock timesheets.</param>
        /// <param name="date">The date used to select the day, week, or month to lock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        public async Task<bool> LockAsync(Person person, DateTime date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            return await LockTimesheetsAsync(person, null, date, timePeriod, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Locks timesheets for the selected period for the specified person within the specified organization.
        /// </summary>
        /// <param name="person">The person for which to lock timesheets.</param>
        /// <param name="organization">The organization for which to lock timesheets.</param>
        /// <param name="date">The date used to select the day, week, or month to lock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        public async Task<bool> LockAsync(Person person, Organization organization, DateTime date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            if (organization is null)
                throw new ArgumentNullException(nameof(organization));

            return await LockTimesheetsAsync(person, organization, date, timePeriod, ct).ConfigureAwait(false);
        }

#if (NET6_0_OR_GREATER)
        /// <summary>
        /// Locks timesheets for the selected period for the specified person.
        /// </summary>
        /// <param name="person">The person for which to lock timesheets.</param>
        /// <param name="date">The date used to select the day, week, or month to lock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        public async Task<bool> LockAsync(Person person, DateOnly date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            return await LockTimesheetsAsync(person, null, date.ToDateTime(TimeOnly.MinValue), timePeriod, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Locks timesheets for the selected period for the specified person within the specified organization.
        /// </summary>
        /// <param name="person">The person for which to lock timesheets.</param>
        /// <param name="organization">The organization for which to lock timesheets.</param>
        /// <param name="date">The date used to select the day, week, or month to lock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        public async Task<bool> LockAsync(Person person, Organization organization, DateOnly date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            if (organization is null)
                throw new ArgumentNullException(nameof(organization));

            return await LockTimesheetsAsync(person, organization, date.ToDateTime(TimeOnly.MinValue), timePeriod, ct).ConfigureAwait(false);
        }
#endif

        /// <summary>
        /// Unlocks timesheets for the selected period for the specified person.
        /// </summary>
        /// <param name="person">The person for which to unlock timesheets.</param>
        /// <param name="date">The date used to select the day, week, or month to unlock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        public async Task<bool> UnlockAsync(Person person, DateTime date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            return await UnlockTimesheetsAsync(person, null, date, timePeriod, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Unlocks timesheets for the selected period for the specified person within the specified organization.
        /// </summary>
        /// <param name="person">The person for which to unlock timesheets.</param>
        /// <param name="organization">The organization for which to unlock timesheets.</param>
        /// <param name="date">The date used to select the day, week, or month to unlock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        public async Task<bool> UnlockAsync(Person person, Organization organization, DateTime date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            if (organization is null)
                throw new ArgumentNullException(nameof(organization));

            return await UnlockTimesheetsAsync(person, organization, date, timePeriod, ct).ConfigureAwait(false);
        }

#if (NET6_0_OR_GREATER)
        /// <summary>
        /// Unlocks timesheets for the selected period for the specified person.
        /// </summary>
        /// <param name="person">The person for which to unlock timesheets.</param>
        /// <param name="date">The date used to select the day, week, or month to unlock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        public async Task<bool> UnlockAsync(Person person, DateOnly date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            return await UnlockTimesheetsAsync(person, null, date.ToDateTime(TimeOnly.MinValue), timePeriod, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Unlocks timesheets for the selected period for the specified person within the specified organization.
        /// </summary>
        /// <param name="person">The person for which to unlock timesheets.</param>
        /// <param name="organization">The organization for which to unlock timesheets.</param>
        /// <param name="date">The date used to select the day, week, or month to unlock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        public async Task<bool> UnlockAsync(Person person, Organization organization, DateOnly date, TimePeriodSelector timePeriod, CancellationToken ct = default)
        {
            if (organization is null)
                throw new ArgumentNullException(nameof(organization));

            return await UnlockTimesheetsAsync(person, organization, date.ToDateTime(TimeOnly.MinValue), timePeriod, ct).ConfigureAwait(false);
        }
#endif

        /// <summary>
        /// Retrieves a read-only dictionary containing the person's total time spent for the selected period, optionally scoped to an organization.
        /// </summary>
        /// <param name="person">The person for which to retrieve time totals.</param>
        /// <param name="organization">The organization for which to retrieve time totals, or <see langword="null"/> to retrieve totals across all organizations.</param>
        /// <param name="date">The date used to select the day, week, or month for which to retrieve totals.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A read-only dictionary containing the retrieved totals.</returns>
        private async Task<ReadOnlyDictionary<DateTime, int>> GetTotalsAsync(Person person, Organization? organization, DateTime date, TimePeriodSelector timePeriod, CancellationToken ct)
        {
            if (person is null)
                throw new ArgumentNullException(nameof(person));

            Dictionary<string, string> parameters = new()
            {
                { "person_id", person.Id.ToString(CultureInfo.InvariantCulture) }
            };

            if (organization is not null)
                parameters.Add("organization_id", organization.Id.ToString(CultureInfo.InvariantCulture));

            switch (timePeriod)
            {
                case TimePeriodSelector.Day:
                    parameters.Add("date", date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
                    break;

                case TimePeriodSelector.Week:
                    parameters.Add("week_of", date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
                    break;

                case TimePeriodSelector.Month:
                    parameters.Add("month_of", date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
                    break;
            }

            using (JsonDocument document = await GetJsonDocumentAsync("day_totals", parameters, ct).ConfigureAwait(false))
            {
                JsonElement root = document.RootElement;

                if (root.ValueKind != JsonValueKind.Object)
                    throw new XurrentException("Expected a JSON object containing time totals.");

                Dictionary<DateTime, int> result = new();

                foreach (JsonProperty property in root.EnumerateObject())
                {
                    if (!DateTime.TryParseExact(property.Name, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime key))
                        throw new JsonException("Invalid date key: " + property.Name);

                    if (property.Value.ValueKind != JsonValueKind.Number || !property.Value.TryGetInt32(out int value))
                        throw new JsonException("Invalid value for date '" + property.Name + "'. Expected integer.");

                    result.Add(key, value);
                }

                return new ReadOnlyDictionary<DateTime, int>(result);
            }
        }

        /// <summary>
        /// Locks timesheets for the selected period, optionally scoped to an organization.
        /// </summary>
        /// <param name="person">The person for which to lock timesheets.</param>
        /// <param name="organization">The organization for which to lock timesheets, or <see langword="null"/> to lock timesheets across all organizations.</param>
        /// <param name="date">The date used to select the day, week, or month to lock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        private async Task<bool> LockTimesheetsAsync(Person person, Organization? organization, DateTime date, TimePeriodSelector timePeriod, CancellationToken ct)
        {
            if (person is null)
                throw new ArgumentNullException(nameof(person));

            Dictionary<string, string> parameters = new()
            {
                { "person_id", person.Id.ToString(CultureInfo.InvariantCulture) }
            };

            if (organization is not null)
                parameters.Add("organization_id", organization.Id.ToString(CultureInfo.InvariantCulture));

            switch (timePeriod)
            {
                case TimePeriodSelector.Day:
                    parameters.Add("date", date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
                    break;

                case TimePeriodSelector.Week:
                    parameters.Add("week_of", date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
                    break;

                case TimePeriodSelector.Month:
                    parameters.Add("month_of", date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
                    break;
            }

            return await PostItemAsync("lock", parameters, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Unlocks timesheets for the selected period, optionally scoped to an organization.
        /// </summary>
        /// <param name="person">The person for which to unlock timesheets.</param>
        /// <param name="organization">The organization for which to unlock timesheets, or <see langword="null"/> to unlock timesheets across all organizations.</param>
        /// <param name="date">The date used to select the day, week, or month to unlock.</param>
        /// <param name="timePeriod">Specifies how the provided date is used to select the time period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns><see langword="true"/> if the operation succeeds.</returns>
        private async Task<bool> UnlockTimesheetsAsync(Person person, Organization? organization, DateTime date, TimePeriodSelector timePeriod, CancellationToken ct)
        {
            if (person is null)
                throw new ArgumentNullException(nameof(person));

            Dictionary<string, string> parameters = new()
            {
                { "person_id", person.Id.ToString(CultureInfo.InvariantCulture) }
            };

            if (organization is not null)
                parameters.Add("organization_id", organization.Id.ToString(CultureInfo.InvariantCulture));

            switch (timePeriod)
            {
                case TimePeriodSelector.Day:
                    parameters.Add("date", date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
                    break;

                case TimePeriodSelector.Week:
                    parameters.Add("week_of", date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
                    break;

                case TimePeriodSelector.Month:
                    parameters.Add("month_of", date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
                    break;
            }

            return await DeleteItemAsync("lock", parameters, ct).ConfigureAwait(false);
        }
    }
}
