using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Project"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/projects/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ProjectClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Project"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Note"/> records related to an <see cref="Project"/>.
        /// </summary>
        public NotesClient Notes { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ProjectPhase"/> records related to an <see cref="Project"/>.
        /// </summary>
        public PhasesClient Phases { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Problem"/> records related to an <see cref="Project"/>.
        /// </summary>
        public ProblemsClient Problems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Request"/> records related to an <see cref="Project"/>.
        /// </summary>
        public RequestsClient Requests { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Risk"/> records related to an <see cref="Project"/>.
        /// </summary>
        public RisksClient Risks { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ProjectTask"/> records related to an <see cref="Project"/>.
        /// </summary>
        public TasksClient Tasks { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Workflow"/> records related to an <see cref="Project"/>.
        /// </summary>
        public WorkflowsClient Workflows { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectClient"/> class.
        /// </summary>
        internal ProjectClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "projects/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Notes = new NotesClient(this);
            Phases = new PhasesClient(this);
            Problems = new ProblemsClient(this);
            Requests = new RequestsClient(this);
            Risks = new RisksClient(this);
            Tasks = new TasksClient(this);
            Workflows = new WorkflowsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Project"/> using the specified <see cref="ProjectQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which projects to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Project"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Project>> GetAsync(ProjectQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Project>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Project"/> items as an asynchronous stream using the specified <see cref="ProjectQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which projects to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Project"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Project> StreamAsync(ProjectQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Project>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Project"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Project"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Project?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Project>(new ProjectQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Archive a <see cref="Project"/>.<br />
        /// The project must be disabled.
        /// </summary>
        /// <param name="project">The project to archive.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The archived <see cref="Project"/>.</returns>
        public async Task<Project> ArchiveAsync(Project project, CancellationToken ct = default)
        {
            return await PostItemAsync(project, "archive", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Project"/>.
        /// </summary>
        /// <param name="project">The project to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Project"/>.</returns>
        public async Task<Project> CreateAsync(Project project, CancellationToken ct = default)
        {
            return await PostItemAsync(project, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Project"/>.
        /// </summary>
        /// <param name="projectId">The identifier of the project to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Project"/>.</returns>
        public async Task<Project> RestoreAsync(long projectId, CancellationToken ct = default)
        {
            return await PostItemAsync(new Project(projectId), "restore", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Project"/>.
        /// </summary>
        /// <param name="reference">The reference to the project to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Project"/>.</returns>
        public async Task<Project> RestoreAsync(ResourceReference reference, CancellationToken ct = default)
        {
            if (reference is null)
                throw new ArgumentNullException(nameof(reference));

            if (!reference.Id.HasValue)
                throw new ArgumentException("The archive reference must have a valid identifier.", nameof(reference));

            return await RestoreAsync(reference.Id.Value, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Trash a <see cref="Project"/>.<br />
        /// The project must be disabled.
        /// </summary>
        /// <param name="project">The project to trash.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The trashed <see cref="Project"/>.</returns>
        public async Task<Project> TrashAsync(Project project, CancellationToken ct = default)
        {
            return await PostItemAsync(project, "trash", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Project"/>.
        /// </summary>
        /// <param name="project">The project to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Project"/>.</returns>
        public async Task<Project> UpdateAsync(Project project, CancellationToken ct = default)
        {
            return await PatchItemAsync(project, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Project"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ProjectClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ProjectClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long projectId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(projectId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Project project, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await GetAsync(project.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long projectId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(projectId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Project project, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return StreamAsync(project.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Note"/> records related to an <see cref="Project"/>.
        /// </summary>
        public sealed class NotesClient
        {
            private readonly ProjectClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotesClient"/> class.
            /// </summary>
            internal NotesClient(ProjectClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified project using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(long projectId, NoteQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Note>(projectId, "notes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified project using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(Project project, NoteQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await GetAsync(project.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified project using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(long projectId, NoteQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Note>(projectId, "notes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified project using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(Project project, NoteQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return StreamAsync(project.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(long projectId, NoteCreate noteCreate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectId, "notes", noteCreate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project to which the note create is added.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(Project project, NoteCreate noteCreate, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await CreateAsync(project.Id, noteCreate, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ProjectPhase"/> records related to an <see cref="Project"/>.
        /// </summary>
        public sealed class PhasesClient
        {
            private readonly ProjectClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PhasesClient"/> class.
            /// </summary>
            internal PhasesClient(ProjectClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectPhase"/> records for the specified project using an <see cref="ProjectPhaseQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to retrieve the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectPhase"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectPhase>> GetAsync(long projectId, ProjectPhaseQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ProjectPhase>(projectId, "phases", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectPhase"/> records for the specified project using an <see cref="ProjectPhaseQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to retrieve the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectPhase"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectPhase>> GetAsync(Project project, ProjectPhaseQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await GetAsync(project.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectPhase"/> items as an asynchronous stream for the specified project using an <see cref="ProjectPhaseQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to enumerate the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectPhase"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectPhase> StreamAsync(long projectId, ProjectPhaseQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ProjectPhase>(projectId, "phases", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectPhase"/> items as an asynchronous stream for the specified project using an <see cref="ProjectPhaseQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to enumerate the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectPhase"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectPhase> StreamAsync(Project project, ProjectPhaseQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return StreamAsync(project.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="ProjectPhase"/> by its unique identifier for the specified project.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project.</param>
            /// <param name="projectPhaseId">The unique identifier of the project phase.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="ProjectPhase"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<ProjectPhase?> GetAsync(long projectId, long projectPhaseId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<ProjectPhase>(projectId, "phases", new ProjectPhaseQuery().WithId(projectPhaseId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="ProjectPhase"/> record for the specified project.
            /// </summary>
            /// <param name="project">The project for which to retrieve the project phase.</param>
            /// <param name="projectPhaseId">The unique identifier of the project phase.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="ProjectPhase"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<ProjectPhase?> GetAsync(Project project, long projectPhaseId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await GetAsync(project.Id, projectPhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="ProjectPhase"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="projectPhase">The project phase to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectPhase"/>.</returns>
            public async Task<ProjectPhase> CreateAsync(long projectId, ProjectPhase projectPhase, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectId, "phases", projectPhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="ProjectPhase"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project to which the project phase is added.</param>
            /// <param name="projectPhase">The project phase to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectPhase"/>.</returns>
            public async Task<ProjectPhase> CreateAsync(Project project, ProjectPhase projectPhase, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await CreateAsync(project.Id, projectPhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="ProjectPhase"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="projectPhase">The project phase to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectPhase"/>.</returns>
            public async Task<ProjectPhase> UpdateAsync(long projectId, ProjectPhase projectPhase, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(projectId, "phases", projectPhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="ProjectPhase"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project with which the project phase is associated.</param>
            /// <param name="projectPhase">The project phase to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectPhase"/>.</returns>
            public async Task<ProjectPhase> UpdateAsync(Project project, ProjectPhase projectPhase, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await UpdateAsync(project.Id, projectPhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectPhase"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="projectPhaseId">The identifier of the project phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long projectId, long projectPhaseId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(projectId, "phases", projectPhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectPhase"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="projectPhase">The project phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long projectId, ProjectPhase projectPhase, CancellationToken ct = default)
            {
                if (projectPhase is null)
                    throw new ArgumentNullException(nameof(projectPhase));

                return await DeleteAsync(projectId, projectPhase.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectPhase"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the project phase is removed.</param>
            /// <param name="projectPhase">The project phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Project project, ProjectPhase projectPhase, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                if (projectPhase is null)
                    throw new ArgumentNullException(nameof(projectPhase));

                return await DeleteAsync(project.Id, projectPhase.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectPhase"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the project phase is removed.</param>
            /// <param name="projectPhaseId">The identifier of the project phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Project project, long projectPhaseId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await DeleteAsync(project.Id, projectPhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all phases associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long projectId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectId, "phases", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all phases associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which all phases are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Project project, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await DeleteAllAsync(project.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Problem"/> records related to an <see cref="Project"/>.
        /// </summary>
        public sealed class ProblemsClient
        {
            private readonly ProjectClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ProblemsClient"/> class.
            /// </summary>
            internal ProblemsClient(ProjectClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Problem"/> records for the specified project using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to retrieve the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Problem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Problem>> GetAsync(long projectId, ProblemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Problem>(projectId, "problems", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Problem"/> records for the specified project using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to retrieve the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Problem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Problem>> GetAsync(Project project, ProblemQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await GetAsync(project.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Problem"/> items as an asynchronous stream for the specified project using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to enumerate the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Problem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Problem> StreamAsync(long projectId, ProblemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Problem>(projectId, "problems", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Problem"/> items as an asynchronous stream for the specified project using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to enumerate the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Problem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Problem> StreamAsync(Project project, ProblemQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return StreamAsync(project.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Problem"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="problemId">The identifier of the problem to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectId, long problemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectId, "problems", problemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Problem"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="problem">The problem to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectId, Problem problem, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await AddAsync(projectId, problem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Problem"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the problem is removed.</param>
            /// <param name="problem">The problem to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Project project, Problem problem, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await AddAsync(project.Id, problem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Problem"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the problem is removed.</param>
            /// <param name="problemId">The identifier of the problem to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Project project, long problemId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await AddAsync(project.Id, problemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Problem"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="problemId">The identifier of the problem to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectId, long problemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(projectId, "problems", problemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Problem"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="problem">The problem to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectId, Problem problem, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAsync(projectId, problem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Problem"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the problem is removed.</param>
            /// <param name="problem">The problem to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Project project, Problem problem, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAsync(project.Id, problem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Problem"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the problem is removed.</param>
            /// <param name="problemId">The identifier of the problem to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Project project, long problemId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAsync(project.Id, problemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all problems associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long projectId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectId, "problems", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all problems associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which all problems are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Project project, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAllAsync(project.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Request"/> records related to an <see cref="Project"/>.
        /// </summary>
        public sealed class RequestsClient
        {
            private readonly ProjectClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RequestsClient"/> class.
            /// </summary>
            internal RequestsClient(ProjectClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified project using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(long projectId, RequestQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Request>(projectId, "requests", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified project using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(Project project, RequestQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await GetAsync(project.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified project using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(long projectId, RequestQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Request>(projectId, "requests", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified project using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(Project project, RequestQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return StreamAsync(project.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="requestId">The identifier of the request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectId, long requestId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectId, "requests", requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="request">The request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectId, Request request, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await AddAsync(projectId, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the request is removed.</param>
            /// <param name="request">The request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Project project, Request request, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await AddAsync(project.Id, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the request is removed.</param>
            /// <param name="requestId">The identifier of the request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Project project, long requestId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await AddAsync(project.Id, requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="requestId">The identifier of the request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectId, long requestId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(projectId, "requests", requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="request">The request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectId, Request request, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await RemoveAsync(projectId, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the request is removed.</param>
            /// <param name="request">The request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Project project, Request request, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await RemoveAsync(project.Id, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the request is removed.</param>
            /// <param name="requestId">The identifier of the request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Project project, long requestId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAsync(project.Id, requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all requests associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long projectId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectId, "requests", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all requests associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which all requests are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Project project, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAllAsync(project.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Risk"/> records related to an <see cref="Project"/>.
        /// </summary>
        public sealed class RisksClient
        {
            private readonly ProjectClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RisksClient"/> class.
            /// </summary>
            internal RisksClient(ProjectClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Risk"/> records for the specified project using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to retrieve the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Risk"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Risk>> GetAsync(long projectId, RiskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Risk>(projectId, "risks", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Risk"/> records for the specified project using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to retrieve the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Risk"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Risk>> GetAsync(Project project, RiskQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await GetAsync(project.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Risk"/> items as an asynchronous stream for the specified project using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to enumerate the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Risk"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Risk> StreamAsync(long projectId, RiskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Risk>(projectId, "risks", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Risk"/> items as an asynchronous stream for the specified project using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to enumerate the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Risk"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Risk> StreamAsync(Project project, RiskQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return StreamAsync(project.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Risk"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="riskId">The identifier of the risk to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectId, long riskId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectId, "risks", riskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Risk"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="risk">The risk to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectId, Risk risk, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await AddAsync(projectId, risk.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Risk"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the risk is removed.</param>
            /// <param name="risk">The risk to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Project project, Risk risk, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await AddAsync(project.Id, risk.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Risk"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the risk is removed.</param>
            /// <param name="riskId">The identifier of the risk to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Project project, long riskId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await AddAsync(project.Id, riskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Risk"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="riskId">The identifier of the risk to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectId, long riskId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(projectId, "risks", riskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Risk"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="risk">The risk to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectId, Risk risk, CancellationToken ct = default)
            {
                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await RemoveAsync(projectId, risk.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Risk"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the risk is removed.</param>
            /// <param name="risk">The risk to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Project project, Risk risk, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                if (risk is null)
                    throw new ArgumentNullException(nameof(risk));

                return await RemoveAsync(project.Id, risk.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Risk"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the risk is removed.</param>
            /// <param name="riskId">The identifier of the risk to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Project project, long riskId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAsync(project.Id, riskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all risks associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long projectId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectId, "risks", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all risks associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which all risks are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Project project, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAllAsync(project.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ProjectTask"/> records related to an <see cref="Project"/>.
        /// </summary>
        public sealed class TasksClient
        {
            private readonly ProjectClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TasksClient"/> class.
            /// </summary>
            internal TasksClient(ProjectClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTask"/> records for the specified project using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to retrieve the tasks.</param>
            /// <param name="query">The query that defines which tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTask>> GetAsync(long projectId, ProjectTaskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ProjectTask>(projectId, "tasks", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTask"/> records for the specified project using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to retrieve the tasks.</param>
            /// <param name="query">The query that defines which tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTask>> GetAsync(Project project, ProjectTaskQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await GetAsync(project.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTask"/> items as an asynchronous stream for the specified project using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to enumerate the tasks.</param>
            /// <param name="query">The query that defines which tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTask> StreamAsync(long projectId, ProjectTaskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ProjectTask>(projectId, "tasks", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTask"/> items as an asynchronous stream for the specified project using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to enumerate the tasks.</param>
            /// <param name="query">The query that defines which tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTask> StreamAsync(Project project, ProjectTaskQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return StreamAsync(project.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Workflow"/> records related to an <see cref="Project"/>.
        /// </summary>
        public sealed class WorkflowsClient
        {
            private readonly ProjectClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="WorkflowsClient"/> class.
            /// </summary>
            internal WorkflowsClient(ProjectClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Workflow"/> records for the specified project using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to retrieve the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Workflow"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Workflow>> GetAsync(long projectId, WorkflowQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Workflow>(projectId, "workflows", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Workflow"/> records for the specified project using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to retrieve the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Workflow"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Workflow>> GetAsync(Project project, WorkflowQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await GetAsync(project.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Workflow"/> items as an asynchronous stream for the specified project using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="projectId">The unique identifier of the project for which to enumerate the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Workflow"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Workflow> StreamAsync(long projectId, WorkflowQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Workflow>(projectId, "workflows", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Workflow"/> items as an asynchronous stream for the specified project using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="project">The project for which to enumerate the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Workflow"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Workflow> StreamAsync(Project project, WorkflowQuery query, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return StreamAsync(project.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Workflow"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="workflowId">The identifier of the workflow to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectId, long workflowId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectId, "workflows", workflowId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Workflow"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="workflow">The workflow to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectId, Workflow workflow, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await AddAsync(projectId, workflow.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Workflow"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the workflow is removed.</param>
            /// <param name="workflow">The workflow to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Project project, Workflow workflow, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await AddAsync(project.Id, workflow.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Workflow"/> to a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the workflow is removed.</param>
            /// <param name="workflowId">The identifier of the workflow to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Project project, long workflowId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await AddAsync(project.Id, workflowId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Workflow"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="workflowId">The identifier of the workflow to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectId, long workflowId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(projectId, "workflows", workflowId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Workflow"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="workflow">The workflow to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectId, Workflow workflow, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await RemoveAsync(projectId, workflow.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Workflow"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the workflow is removed.</param>
            /// <param name="workflow">The workflow to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Project project, Workflow workflow, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await RemoveAsync(project.Id, workflow.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Workflow"/> associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which the workflow is removed.</param>
            /// <param name="workflowId">The identifier of the workflow to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Project project, long workflowId, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAsync(project.Id, workflowId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all workflows associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="projectId">The identifier of the project.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long projectId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectId, "workflows", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all workflows associated with a <see cref="Project"/>.
            /// </summary>
            /// <param name="project">The project from which all workflows are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Project project, CancellationToken ct = default)
            {
                if (project is null)
                    throw new ArgumentNullException(nameof(project));

                return await RemoveAllAsync(project.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
