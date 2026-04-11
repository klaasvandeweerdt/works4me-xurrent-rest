using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="TimesheetSetting"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/timesheet_settings/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class TimesheetSettingClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimesheetSettingClient"/> class.
        /// </summary>
        internal TimesheetSettingClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "timesheet_settings/"))
        {
        }

        /// <summary>
        /// Retrieves a collection of <see cref="TimesheetSetting"/> using the specified <see cref="TimesheetSettingQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which timesheet settings to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="TimesheetSetting"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<TimesheetSetting>> GetAsync(TimesheetSettingQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<TimesheetSetting>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="TimesheetSetting"/> items as an asynchronous stream using the specified <see cref="TimesheetSettingQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which timesheet settings to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="TimesheetSetting"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<TimesheetSetting> StreamAsync(TimesheetSettingQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<TimesheetSetting>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="TimesheetSetting"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the timesheet setting.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="TimesheetSetting"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<TimesheetSetting?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<TimesheetSetting>(new TimesheetSettingQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="TimesheetSetting"/>.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet setting to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="TimesheetSetting"/>.</returns>
        public async Task<TimesheetSetting> CreateAsync(TimesheetSetting timesheetSetting, CancellationToken ct = default)
        {
            return await PostItemAsync(timesheetSetting, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="TimesheetSetting"/>.
        /// </summary>
        /// <param name="timesheetSetting">The timesheet setting to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="TimesheetSetting"/>.</returns>
        public async Task<TimesheetSetting> UpdateAsync(TimesheetSetting timesheetSetting, CancellationToken ct = default)
        {
            return await PatchItemAsync(timesheetSetting, ct).ConfigureAwait(false);
        }
    }
}
