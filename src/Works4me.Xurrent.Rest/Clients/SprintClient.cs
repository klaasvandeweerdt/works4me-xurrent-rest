using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Sprint"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/sprints/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class SprintClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Sprint"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="Sprint"/>.
        /// </summary>
        public BacklogItemsClient BacklogItems { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SprintClient"/> class.
        /// </summary>
        internal SprintClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "sprints/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            BacklogItems = new BacklogItemsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Sprint"/> using the specified <see cref="SprintQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which sprints to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Sprint"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Sprint>> GetAsync(SprintQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Sprint>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Sprint"/> items as an asynchronous stream using the specified <see cref="SprintQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which sprints to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Sprint"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Sprint> StreamAsync(SprintQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Sprint>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Sprint"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sprint.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Sprint"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Sprint?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Sprint>(new SprintQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Sprint"/>.
        /// </summary>
        /// <param name="sprint">The sprint to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Sprint"/>.</returns>
        public async Task<Sprint> CreateAsync(Sprint sprint, CancellationToken ct = default)
        {
            return await PostItemAsync(sprint, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Sprint"/>.
        /// </summary>
        /// <param name="sprint">The sprint to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Sprint"/>.</returns>
        public async Task<Sprint> UpdateAsync(Sprint sprint, CancellationToken ct = default)
        {
            return await PatchItemAsync(sprint, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Sprint"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly SprintClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(SprintClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified sprint using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="sprintId">The unique identifier of the sprint for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long sprintId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(sprintId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified sprint using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="sprint">The sprint for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Sprint sprint, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (sprint is null)
                    throw new ArgumentNullException(nameof(sprint));

                return await GetAsync(sprint.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified sprint using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="sprintId">The unique identifier of the sprint for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long sprintId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(sprintId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified sprint using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="sprint">The sprint for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Sprint sprint, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (sprint is null)
                    throw new ArgumentNullException(nameof(sprint));

                return StreamAsync(sprint.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="Sprint"/>.
        /// </summary>
        public sealed class BacklogItemsClient
        {
            private readonly SprintClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="BacklogItemsClient"/> class.
            /// </summary>
            internal BacklogItemsClient(SprintClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified sprint using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="sprintId">The unique identifier of the sprint for which to retrieve the backlog items.</param>
            /// <param name="query">The query that defines which backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(long sprintId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SprintBacklogItem>(sprintId, "sprint_backlog_items", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified sprint using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="sprint">The sprint for which to retrieve the backlog items.</param>
            /// <param name="query">The query that defines which backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(Sprint sprint, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (sprint is null)
                    throw new ArgumentNullException(nameof(sprint));

                return await GetAsync(sprint.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified sprint using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="sprintId">The unique identifier of the sprint for which to enumerate the backlog items.</param>
            /// <param name="query">The query that defines which backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(long sprintId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SprintBacklogItem>(sprintId, "sprint_backlog_items", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified sprint using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="sprint">The sprint for which to enumerate the backlog items.</param>
            /// <param name="query">The query that defines which backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(Sprint sprint, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (sprint is null)
                    throw new ArgumentNullException(nameof(sprint));

                return StreamAsync(sprint.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="SprintBacklogItem"/> by its unique identifier for the specified sprint.
            /// </summary>
            /// <param name="sprintId">The unique identifier of the sprint.</param>
            /// <param name="sprintBacklogItemId">The unique identifier of the sprint backlog item.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="SprintBacklogItem"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<SprintBacklogItem?> GetAsync(long sprintId, long sprintBacklogItemId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<SprintBacklogItem>(sprintId, "sprint_backlog_items", new SprintBacklogItemQuery().WithId(sprintBacklogItemId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="SprintBacklogItem"/> record for the specified sprint.
            /// </summary>
            /// <param name="sprint">The sprint for which to retrieve the sprint backlog item.</param>
            /// <param name="sprintBacklogItemId">The unique identifier of the sprint backlog item.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="SprintBacklogItem"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<SprintBacklogItem?> GetAsync(Sprint sprint, long sprintBacklogItemId, CancellationToken ct = default)
            {
                if (sprint is null)
                    throw new ArgumentNullException(nameof(sprint));

                return await GetAsync(sprint.Id, sprintBacklogItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="SprintBacklogItem"/> associated with a <see cref="Sprint"/>.
            /// </summary>
            /// <param name="sprintId">The identifier of the sprint.</param>
            /// <param name="sprintBacklogItem">The sprint backlog item to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SprintBacklogItem"/>.</returns>
            public async Task<SprintBacklogItem> UpdateAsync(long sprintId, SprintBacklogItem sprintBacklogItem, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(sprintId, "sprint_backlog_items", sprintBacklogItem, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="SprintBacklogItem"/> associated with a <see cref="Sprint"/>.
            /// </summary>
            /// <param name="sprint">The sprint with which the sprint backlog item is associated.</param>
            /// <param name="sprintBacklogItem">The sprint backlog item to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SprintBacklogItem"/>.</returns>
            public async Task<SprintBacklogItem> UpdateAsync(Sprint sprint, SprintBacklogItem sprintBacklogItem, CancellationToken ct = default)
            {
                if (sprint is null)
                    throw new ArgumentNullException(nameof(sprint));

                return await UpdateAsync(sprint.Id, sprintBacklogItem, ct).ConfigureAwait(false);
            }
        }
    }
}
