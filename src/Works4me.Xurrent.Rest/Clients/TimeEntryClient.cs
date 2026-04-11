using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="TimeEntry"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/time_entries/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class TimeEntryClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeEntryClient"/> class.
        /// </summary>
        internal TimeEntryClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "time_entries/"))
        {
        }

        /// <summary>
        /// Retrieves a collection of <see cref="TimeEntry"/> using the specified <see cref="TimeEntryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which time entries to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="TimeEntry"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<TimeEntry>> GetAsync(TimeEntryQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<TimeEntry>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="TimeEntry"/> items as an asynchronous stream using the specified <see cref="TimeEntryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which time entries to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="TimeEntry"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<TimeEntry> StreamAsync(TimeEntryQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<TimeEntry>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="TimeEntry"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the time entry.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="TimeEntry"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<TimeEntry?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<TimeEntry>(new TimeEntryQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="TimeEntry"/>.
        /// </summary>
        /// <param name="timeEntry">The time entry to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="TimeEntry"/>.</returns>
        public async Task<TimeEntry> CreateAsync(TimeEntry timeEntry, CancellationToken ct = default)
        {
            return await PostItemAsync(timeEntry, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Archive a <see cref="TimeEntry"/>.<br />
        /// The time entry must be disabled.
        /// </summary>
        /// <param name="timeEntry">The time entry to archive.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The archived <see cref="TimeEntry"/>.</returns>
        public async Task<TimeEntry> ArchiveAsync(TimeEntry timeEntry, CancellationToken ct = default)
        {
            return await PostItemAsync(timeEntry, "archive", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="TimeEntry"/>.
        /// </summary>
        /// <param name="timeEntryId">The identifier of the time entry to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="TimeEntry"/>.</returns>
        public async Task<TimeEntry> RestoreAsync(long timeEntryId, CancellationToken ct = default)
        {
            return await PostItemAsync(new TimeEntry(timeEntryId), "restore", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="TimeEntry"/>.
        /// </summary>
        /// <param name="reference">The reference to the time entry to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="TimeEntry"/>.</returns>
        public async Task<TimeEntry> RestoreAsync(ResourceReference reference, CancellationToken ct = default)
        {
            if (reference is null)
                throw new ArgumentNullException(nameof(reference));

            if (!reference.Id.HasValue)
                throw new ArgumentException("The archive reference must have a valid identifier.", nameof(reference));

            return await RestoreAsync(reference.Id.Value, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Trash a <see cref="TimeEntry"/>.<br />
        /// The time entry must be disabled.
        /// </summary>
        /// <param name="timeEntry">The time entry to trash.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The trashed <see cref="TimeEntry"/>.</returns>
        public async Task<TimeEntry> TrashAsync(TimeEntry timeEntry, CancellationToken ct = default)
        {
            return await PostItemAsync(timeEntry, "trash", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="TimeEntry"/>.
        /// </summary>
        /// <param name="timeEntry">The time entry to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="TimeEntry"/>.</returns>
        public async Task<TimeEntry> UpdateAsync(TimeEntry timeEntry, CancellationToken ct = default)
        {
            return await PatchItemAsync(timeEntry, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a <see cref="TimeEntry"/>.
        /// </summary>
            /// <param name="timeEntryId">The identifier of the time entry to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long timeEntryId, CancellationToken ct = default)
            {
                return await DeleteItemAsync(timeEntryId, ct).ConfigureAwait(false);
            }

        /// <summary>
        /// Delete a <see cref="TimeEntry"/>.
        /// </summary>
        /// <param name="timeEntry">The time entry to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="TimeEntry"/>.</returns>
        public async Task<bool> DeleteAsync(TimeEntry timeEntry, CancellationToken ct = default)
        {
            if (timeEntry is null)
                throw new ArgumentNullException(nameof(timeEntry));

            return await DeleteAsync(timeEntry.Id, ct).ConfigureAwait(false);
        }
    }
}
