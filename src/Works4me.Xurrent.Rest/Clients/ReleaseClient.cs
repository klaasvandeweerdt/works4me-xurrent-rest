using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Release"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/releases/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ReleaseClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Release"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Note"/> records related to an <see cref="Release"/>.
        /// </summary>
        public NotesClient Notes { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Workflow"/> records related to an <see cref="Release"/>.
        /// </summary>
        public WorkflowsClient Workflows { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReleaseClient"/> class.
        /// </summary>
        internal ReleaseClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "releases/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Notes = new NotesClient(this);
            Workflows = new WorkflowsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Release"/> using the specified <see cref="ReleaseQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which releases to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Release"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Release>> GetAsync(ReleaseQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Release>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Release"/> items as an asynchronous stream using the specified <see cref="ReleaseQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which releases to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Release"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Release> StreamAsync(ReleaseQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Release>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Release"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the release.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Release"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Release?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Release>(new ReleaseQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Archive a <see cref="Release"/>.<br />
        /// The release must be disabled.
        /// </summary>
        /// <param name="release">The release to archive.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The archived <see cref="Release"/>.</returns>
        public async Task<Release> ArchiveAsync(Release release, CancellationToken ct = default)
        {
            return await PostItemAsync(release, "archive", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Release"/>.
        /// </summary>
        /// <param name="release">The release to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Release"/>.</returns>
        public async Task<Release> CreateAsync(Release release, CancellationToken ct = default)
        {
            return await PostItemAsync(release, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Release"/>.
        /// </summary>
        /// <param name="releaseId">The identifier of the release to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Release"/>.</returns>
        public async Task<Release> RestoreAsync(long releaseId, CancellationToken ct = default)
        {
            return await PostItemAsync(new Release(releaseId), "restore", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Release"/>.
        /// </summary>
        /// <param name="reference">The reference to the release to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Release"/>.</returns>
        public async Task<Release> RestoreAsync(ResourceReference reference, CancellationToken ct = default)
        {
            if (reference is null)
                throw new ArgumentNullException(nameof(reference));

            if (!reference.Id.HasValue)
                throw new ArgumentException("The archive reference must have a valid identifier.", nameof(reference));

            return await RestoreAsync(reference.Id.Value, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Trash a <see cref="Release"/>.<br />
        /// The release must be disabled.
        /// </summary>
        /// <param name="release">The release to trash.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The trashed <see cref="Release"/>.</returns>
        public async Task<Release> TrashAsync(Release release, CancellationToken ct = default)
        {
            return await PostItemAsync(release, "trash", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Release"/>.
        /// </summary>
        /// <param name="release">The release to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Release"/>.</returns>
        public async Task<Release> UpdateAsync(Release release, CancellationToken ct = default)
        {
            return await PatchItemAsync(release, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Release"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ReleaseClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ReleaseClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified release using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="releaseId">The unique identifier of the release for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long releaseId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(releaseId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified release using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="release">The release for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Release release, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return await GetAsync(release.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified release using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="releaseId">The unique identifier of the release for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long releaseId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(releaseId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified release using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="release">The release for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Release release, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return StreamAsync(release.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Note"/> records related to an <see cref="Release"/>.
        /// </summary>
        public sealed class NotesClient
        {
            private readonly ReleaseClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotesClient"/> class.
            /// </summary>
            internal NotesClient(ReleaseClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified release using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="releaseId">The unique identifier of the release for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(long releaseId, NoteQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Note>(releaseId, "notes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified release using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="release">The release for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(Release release, NoteQuery query, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return await GetAsync(release.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified release using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="releaseId">The unique identifier of the release for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(long releaseId, NoteQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Note>(releaseId, "notes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified release using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="release">The release for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(Release release, NoteQuery query, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return StreamAsync(release.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Release"/>.
            /// </summary>
            /// <param name="releaseId">The identifier of the release.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(long releaseId, NoteCreate noteCreate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(releaseId, "notes", noteCreate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Release"/>.
            /// </summary>
            /// <param name="release">The release to which the note create is added.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(Release release, NoteCreate noteCreate, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return await CreateAsync(release.Id, noteCreate, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Workflow"/> records related to an <see cref="Release"/>.
        /// </summary>
        public sealed class WorkflowsClient
        {
            private readonly ReleaseClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="WorkflowsClient"/> class.
            /// </summary>
            internal WorkflowsClient(ReleaseClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Workflow"/> records for the specified release using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="releaseId">The unique identifier of the release for which to retrieve the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Workflow"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Workflow>> GetAsync(long releaseId, WorkflowQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Workflow>(releaseId, "workflows", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Workflow"/> records for the specified release using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="release">The release for which to retrieve the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Workflow"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Workflow>> GetAsync(Release release, WorkflowQuery query, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return await GetAsync(release.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Workflow"/> items as an asynchronous stream for the specified release using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="releaseId">The unique identifier of the release for which to enumerate the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Workflow"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Workflow> StreamAsync(long releaseId, WorkflowQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Workflow>(releaseId, "workflows", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Workflow"/> items as an asynchronous stream for the specified release using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="release">The release for which to enumerate the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Workflow"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Workflow> StreamAsync(Release release, WorkflowQuery query, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return StreamAsync(release.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Workflow"/> to a <see cref="Release"/>.
            /// </summary>
            /// <param name="releaseId">The identifier of the release.</param>
            /// <param name="workflowId">The identifier of the workflow to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long releaseId, long workflowId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(releaseId, "workflows", workflowId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Workflow"/> to a <see cref="Release"/>.
            /// </summary>
            /// <param name="releaseId">The identifier of the release.</param>
            /// <param name="workflow">The workflow to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long releaseId, Workflow workflow, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await AddAsync(releaseId, workflow.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Workflow"/> to a <see cref="Release"/>.
            /// </summary>
            /// <param name="release">The release from which the workflow is removed.</param>
            /// <param name="workflow">The workflow to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Release release, Workflow workflow, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await AddAsync(release.Id, workflow.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Workflow"/> to a <see cref="Release"/>.
            /// </summary>
            /// <param name="release">The release from which the workflow is removed.</param>
            /// <param name="workflowId">The identifier of the workflow to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Release release, long workflowId, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return await AddAsync(release.Id, workflowId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Workflow"/> associated with a <see cref="Release"/>.
            /// </summary>
            /// <param name="releaseId">The identifier of the release.</param>
            /// <param name="workflowId">The identifier of the workflow to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long releaseId, long workflowId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(releaseId, "workflows", workflowId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Workflow"/> associated with a <see cref="Release"/>.
            /// </summary>
            /// <param name="releaseId">The identifier of the release.</param>
            /// <param name="workflow">The workflow to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long releaseId, Workflow workflow, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await RemoveAsync(releaseId, workflow.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Workflow"/> associated with a <see cref="Release"/>.
            /// </summary>
            /// <param name="release">The release from which the workflow is removed.</param>
            /// <param name="workflow">The workflow to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Release release, Workflow workflow, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await RemoveAsync(release.Id, workflow.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Workflow"/> associated with a <see cref="Release"/>.
            /// </summary>
            /// <param name="release">The release from which the workflow is removed.</param>
            /// <param name="workflowId">The identifier of the workflow to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Release release, long workflowId, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return await RemoveAsync(release.Id, workflowId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all workflows associated with a <see cref="Release"/>.
            /// </summary>
            /// <param name="releaseId">The identifier of the release.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long releaseId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(releaseId, "workflows", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all workflows associated with a <see cref="Release"/>.
            /// </summary>
            /// <param name="release">The release from which all workflows are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Release release, CancellationToken ct = default)
            {
                if (release is null)
                    throw new ArgumentNullException(nameof(release));

                return await RemoveAllAsync(release.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
