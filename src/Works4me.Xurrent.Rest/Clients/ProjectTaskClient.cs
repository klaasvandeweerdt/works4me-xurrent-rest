using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ProjectTask"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/project_tasks/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ProjectTaskClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="ProjectTaskAssignment"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public AssignmentsClient Assignments { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Note"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public NotesClient Notes { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ProjectTask"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public PredecessorsClient Predecessors { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public SprintBacklogItemsClient SprintBacklogItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ProjectTask"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public SuccessorsClient Successors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTaskClient"/> class.
        /// </summary>
        internal ProjectTaskClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "project_tasks/"))
        {
            Assignments = new AssignmentsClient(this);
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
            Notes = new NotesClient(this);
            Predecessors = new PredecessorsClient(this);
            SprintBacklogItems = new SprintBacklogItemsClient(this);
            Successors = new SuccessorsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ProjectTask"/> using the specified <see cref="ProjectTaskQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which project tasks to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ProjectTask"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ProjectTask>> GetAsync(ProjectTaskQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ProjectTask>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ProjectTask"/> items as an asynchronous stream using the specified <see cref="ProjectTaskQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which project tasks to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTask"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ProjectTask> StreamAsync(ProjectTaskQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ProjectTask>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ProjectTask"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project task.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ProjectTask"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ProjectTask?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ProjectTask>(new ProjectTaskQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ProjectTask"/>.
        /// </summary>
        /// <param name="projectTask">The project task to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ProjectTask"/>.</returns>
        public async Task<ProjectTask> CreateAsync(ProjectTask projectTask, CancellationToken ct = default)
        {
            return await PostItemAsync(projectTask, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ProjectTask"/>.
        /// </summary>
        /// <param name="projectTask">The project task to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ProjectTask"/>.</returns>
        public async Task<ProjectTask> UpdateAsync(ProjectTask projectTask, CancellationToken ct = default)
        {
            return await PatchItemAsync(projectTask, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ProjectTaskAssignment"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public sealed class AssignmentsClient
        {
            private readonly ProjectTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AssignmentsClient"/> class.
            /// </summary>
            internal AssignmentsClient(ProjectTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTaskAssignment"/> records for the specified project task using an <see cref="ProjectTaskAssignmentQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to retrieve the assignments.</param>
            /// <param name="query">The query that defines which assignments to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTaskAssignment"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTaskAssignment>> GetAsync(long projectTaskId, ProjectTaskAssignmentQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ProjectTaskAssignment>(projectTaskId, "assignments", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTaskAssignment"/> records for the specified project task using an <see cref="ProjectTaskAssignmentQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to retrieve the assignments.</param>
            /// <param name="query">The query that defines which assignments to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTaskAssignment"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTaskAssignment>> GetAsync(ProjectTask projectTask, ProjectTaskAssignmentQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await GetAsync(projectTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTaskAssignment"/> items as an asynchronous stream for the specified project task using an <see cref="ProjectTaskAssignmentQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to enumerate the assignments.</param>
            /// <param name="query">The query that defines which assignments to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTaskAssignment"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTaskAssignment> StreamAsync(long projectTaskId, ProjectTaskAssignmentQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ProjectTaskAssignment>(projectTaskId, "assignments", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTaskAssignment"/> items as an asynchronous stream for the specified project task using an <see cref="ProjectTaskAssignmentQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to enumerate the assignments.</param>
            /// <param name="query">The query that defines which assignments to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTaskAssignment"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTaskAssignment> StreamAsync(ProjectTask projectTask, ProjectTaskAssignmentQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return StreamAsync(projectTask.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="ProjectTaskAssignment"/> by its unique identifier for the specified project task.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task.</param>
            /// <param name="projectTaskAssignmentId">The unique identifier of the project task assignment.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="ProjectTaskAssignment"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<ProjectTaskAssignment?> GetAsync(long projectTaskId, long projectTaskAssignmentId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<ProjectTaskAssignment>(projectTaskId, "assignments", new ProjectTaskAssignmentQuery().WithId(projectTaskAssignmentId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="ProjectTaskAssignment"/> record for the specified project task.
            /// </summary>
            /// <param name="projectTask">The project task for which to retrieve the project task assignment.</param>
            /// <param name="projectTaskAssignmentId">The unique identifier of the project task assignment.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="ProjectTaskAssignment"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<ProjectTaskAssignment?> GetAsync(ProjectTask projectTask, long projectTaskAssignmentId, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await GetAsync(projectTask.Id, projectTaskAssignmentId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="ProjectTaskAssignment"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTaskId">The identifier of the project task.</param>
            /// <param name="projectTaskAssignment">The project task assignment to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectTaskAssignment"/>.</returns>
            public async Task<ProjectTaskAssignment> CreateAsync(long projectTaskId, ProjectTaskAssignment projectTaskAssignment, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectTaskId, "assignments", projectTaskAssignment, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="ProjectTaskAssignment"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTask">The project task to which the project task assignment is added.</param>
            /// <param name="projectTaskAssignment">The project task assignment to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectTaskAssignment"/>.</returns>
            public async Task<ProjectTaskAssignment> CreateAsync(ProjectTask projectTask, ProjectTaskAssignment projectTaskAssignment, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await CreateAsync(projectTask.Id, projectTaskAssignment, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="ProjectTaskAssignment"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTaskId">The identifier of the project task.</param>
            /// <param name="projectTaskAssignment">The project task assignment to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectTaskAssignment"/>.</returns>
            public async Task<ProjectTaskAssignment> UpdateAsync(long projectTaskId, ProjectTaskAssignment projectTaskAssignment, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(projectTaskId, "assignments", projectTaskAssignment, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="ProjectTaskAssignment"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTask">The project task with which the project task assignment is associated.</param>
            /// <param name="projectTaskAssignment">The project task assignment to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectTaskAssignment"/>.</returns>
            public async Task<ProjectTaskAssignment> UpdateAsync(ProjectTask projectTask, ProjectTaskAssignment projectTaskAssignment, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await UpdateAsync(projectTask.Id, projectTaskAssignment, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectTaskAssignment"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTaskId">The identifier of the project task.</param>
            /// <param name="projectTaskAssignmentId">The identifier of the project task assignment to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long projectTaskId, long projectTaskAssignmentId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(projectTaskId, "assignments", projectTaskAssignmentId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectTaskAssignment"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTaskId">The identifier of the project task.</param>
            /// <param name="projectTaskAssignment">The project task assignment to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long projectTaskId, ProjectTaskAssignment projectTaskAssignment, CancellationToken ct = default)
            {
                if (projectTaskAssignment is null)
                    throw new ArgumentNullException(nameof(projectTaskAssignment));

                return await DeleteAsync(projectTaskId, projectTaskAssignment.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectTaskAssignment"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTask">The project task from which the project task assignment is removed.</param>
            /// <param name="projectTaskAssignment">The project task assignment to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ProjectTask projectTask, ProjectTaskAssignment projectTaskAssignment, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                if (projectTaskAssignment is null)
                    throw new ArgumentNullException(nameof(projectTaskAssignment));

                return await DeleteAsync(projectTask.Id, projectTaskAssignment.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectTaskAssignment"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTask">The project task from which the project task assignment is removed.</param>
            /// <param name="projectTaskAssignmentId">The identifier of the project task assignment to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ProjectTask projectTask, long projectTaskAssignmentId, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await DeleteAsync(projectTask.Id, projectTaskAssignmentId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all assignments associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTaskId">The identifier of the project task.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long projectTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectTaskId, "assignments", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all assignments associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTask">The project task from which all assignments are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(ProjectTask projectTask, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await DeleteAllAsync(projectTask.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ProjectTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ProjectTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project task using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long projectTaskId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(projectTaskId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project task using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ProjectTask projectTask, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await GetAsync(projectTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project task using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long projectTaskId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(projectTaskId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project task using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ProjectTask projectTask, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return StreamAsync(projectTask.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly ProjectTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(ProjectTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified project task using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long projectTaskId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(projectTaskId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified project task using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(ProjectTask projectTask, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await GetAsync(projectTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified project task using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long projectTaskId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(projectTaskId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified project task using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(ProjectTask projectTask, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return StreamAsync(projectTask.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Note"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public sealed class NotesClient
        {
            private readonly ProjectTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotesClient"/> class.
            /// </summary>
            internal NotesClient(ProjectTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified project task using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(long projectTaskId, NoteQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Note>(projectTaskId, "notes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified project task using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(ProjectTask projectTask, NoteQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await GetAsync(projectTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified project task using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(long projectTaskId, NoteQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Note>(projectTaskId, "notes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified project task using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(ProjectTask projectTask, NoteQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return StreamAsync(projectTask.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTaskId">The identifier of the project task.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(long projectTaskId, NoteCreate noteCreate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectTaskId, "notes", noteCreate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTask">The project task to which the note create is added.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(ProjectTask projectTask, NoteCreate noteCreate, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await CreateAsync(projectTask.Id, noteCreate, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ProjectTask"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public sealed class PredecessorsClient
        {
            private readonly ProjectTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PredecessorsClient"/> class.
            /// </summary>
            internal PredecessorsClient(ProjectTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTask"/> records for the specified project task using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to retrieve the predecessors.</param>
            /// <param name="query">The query that defines which predecessors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTask>> GetAsync(long projectTaskId, ProjectTaskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ProjectTask>(projectTaskId, "predecessors", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTask"/> records for the specified project task using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to retrieve the predecessors.</param>
            /// <param name="query">The query that defines which predecessors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTask>> GetAsync(ProjectTask projectTask, ProjectTaskQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await GetAsync(projectTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTask"/> items as an asynchronous stream for the specified project task using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to enumerate the predecessors.</param>
            /// <param name="query">The query that defines which predecessors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTask> StreamAsync(long projectTaskId, ProjectTaskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ProjectTask>(projectTaskId, "predecessors", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTask"/> items as an asynchronous stream for the specified project task using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to enumerate the predecessors.</param>
            /// <param name="query">The query that defines which predecessors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTask> StreamAsync(ProjectTask projectTask, ProjectTaskQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return StreamAsync(projectTask.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ProjectTask"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTaskId">The identifier of the project task.</param>
            /// <param name="projectTaskId">The identifier of the project task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long parentProjectTaskId, long projectTaskId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(parentProjectTaskId, "predecessors", projectTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ProjectTask"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTaskId">The identifier of the project task.</param>
            /// <param name="projectTask">The project task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long parentProjectTaskId, ProjectTask projectTask, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await AddAsync(parentProjectTaskId, projectTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ProjectTask"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTask">The project task from which the project task is removed.</param>
            /// <param name="projectTask">The project task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ProjectTask parentProjectTask, ProjectTask projectTask, CancellationToken ct = default)
            {
                if (parentProjectTask is null)
                    throw new ArgumentNullException(nameof(parentProjectTask));

                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await AddAsync(parentProjectTask.Id, projectTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ProjectTask"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTask">The project task from which the project task is removed.</param>
            /// <param name="projectTaskId">The identifier of the project task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ProjectTask parentProjectTask, long projectTaskId, CancellationToken ct = default)
            {
                if (parentProjectTask is null)
                    throw new ArgumentNullException(nameof(parentProjectTask));

                return await AddAsync(parentProjectTask.Id, projectTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTask"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTaskId">The identifier of the project task.</param>
            /// <param name="projectTaskId">The identifier of the project task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long parentProjectTaskId, long projectTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(parentProjectTaskId, "predecessors", projectTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTask"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTaskId">The identifier of the project task.</param>
            /// <param name="projectTask">The project task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long parentProjectTaskId, ProjectTask projectTask, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await RemoveAsync(parentProjectTaskId, projectTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTask"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTask">The project task from which the project task is removed.</param>
            /// <param name="projectTask">The project task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ProjectTask parentProjectTask, ProjectTask projectTask, CancellationToken ct = default)
            {
                if (parentProjectTask is null)
                    throw new ArgumentNullException(nameof(parentProjectTask));

                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await RemoveAsync(parentProjectTask.Id, projectTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTask"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTask">The project task from which the project task is removed.</param>
            /// <param name="projectTaskId">The identifier of the project task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ProjectTask parentProjectTask, long projectTaskId, CancellationToken ct = default)
            {
                if (parentProjectTask is null)
                    throw new ArgumentNullException(nameof(parentProjectTask));

                return await RemoveAsync(parentProjectTask.Id, projectTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all predecessors associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTaskId">The identifier of the project task.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long projectTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectTaskId, "predecessors", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all predecessors associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTask">The project task from which all predecessors are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ProjectTask projectTask, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await RemoveAllAsync(projectTask.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public sealed class SprintBacklogItemsClient
        {
            private readonly ProjectTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SprintBacklogItemsClient"/> class.
            /// </summary>
            internal SprintBacklogItemsClient(ProjectTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified project task using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to retrieve the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(long projectTaskId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SprintBacklogItem>(projectTaskId, "sprint_backlog_items", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified project task using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to retrieve the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(ProjectTask projectTask, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await GetAsync(projectTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified project task using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to enumerate the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(long projectTaskId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SprintBacklogItem>(projectTaskId, "sprint_backlog_items", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified project task using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to enumerate the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(ProjectTask projectTask, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return StreamAsync(projectTask.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ProjectTask"/> records related to an <see cref="ProjectTask"/>.
        /// </summary>
        public sealed class SuccessorsClient
        {
            private readonly ProjectTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SuccessorsClient"/> class.
            /// </summary>
            internal SuccessorsClient(ProjectTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTask"/> records for the specified project task using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to retrieve the successors.</param>
            /// <param name="query">The query that defines which successors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTask>> GetAsync(long projectTaskId, ProjectTaskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ProjectTask>(projectTaskId, "successors", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTask"/> records for the specified project task using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to retrieve the successors.</param>
            /// <param name="query">The query that defines which successors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTask>> GetAsync(ProjectTask projectTask, ProjectTaskQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await GetAsync(projectTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTask"/> items as an asynchronous stream for the specified project task using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectTaskId">The unique identifier of the project task for which to enumerate the successors.</param>
            /// <param name="query">The query that defines which successors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTask> StreamAsync(long projectTaskId, ProjectTaskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ProjectTask>(projectTaskId, "successors", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTask"/> items as an asynchronous stream for the specified project task using an <see cref="ProjectTaskQuery"/>.
            /// </summary>
            /// <param name="projectTask">The project task for which to enumerate the successors.</param>
            /// <param name="query">The query that defines which successors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTask> StreamAsync(ProjectTask projectTask, ProjectTaskQuery query, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return StreamAsync(projectTask.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ProjectTask"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTaskId">The identifier of the project task.</param>
            /// <param name="projectTaskId">The identifier of the project task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long parentProjectTaskId, long projectTaskId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(parentProjectTaskId, "successors", projectTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ProjectTask"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTaskId">The identifier of the project task.</param>
            /// <param name="projectTask">The project task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long parentProjectTaskId, ProjectTask projectTask, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await AddAsync(parentProjectTaskId, projectTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ProjectTask"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTask">The project task from which the project task is removed.</param>
            /// <param name="projectTask">The project task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ProjectTask parentProjectTask, ProjectTask projectTask, CancellationToken ct = default)
            {
                if (parentProjectTask is null)
                    throw new ArgumentNullException(nameof(parentProjectTask));

                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await AddAsync(parentProjectTask.Id, projectTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ProjectTask"/> to a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTask">The project task from which the project task is removed.</param>
            /// <param name="projectTaskId">The identifier of the project task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ProjectTask parentProjectTask, long projectTaskId, CancellationToken ct = default)
            {
                if (parentProjectTask is null)
                    throw new ArgumentNullException(nameof(parentProjectTask));

                return await AddAsync(parentProjectTask.Id, projectTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTask"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTaskId">The identifier of the project task.</param>
            /// <param name="projectTaskId">The identifier of the project task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long parentProjectTaskId, long projectTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(parentProjectTaskId, "successors", projectTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTask"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTaskId">The identifier of the project task.</param>
            /// <param name="projectTask">The project task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long parentProjectTaskId, ProjectTask projectTask, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await RemoveAsync(parentProjectTaskId, projectTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTask"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTask">The project task from which the project task is removed.</param>
            /// <param name="projectTask">The project task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ProjectTask parentProjectTask, ProjectTask projectTask, CancellationToken ct = default)
            {
                if (parentProjectTask is null)
                    throw new ArgumentNullException(nameof(parentProjectTask));

                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await RemoveAsync(parentProjectTask.Id, projectTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTask"/> associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="parentProjectTask">The project task from which the project task is removed.</param>
            /// <param name="projectTaskId">The identifier of the project task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ProjectTask parentProjectTask, long projectTaskId, CancellationToken ct = default)
            {
                if (parentProjectTask is null)
                    throw new ArgumentNullException(nameof(parentProjectTask));

                return await RemoveAsync(parentProjectTask.Id, projectTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all successors associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTaskId">The identifier of the project task.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long projectTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectTaskId, "successors", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all successors associated with a <see cref="ProjectTask"/>.
            /// </summary>
            /// <param name="projectTask">The project task from which all successors are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ProjectTask projectTask, CancellationToken ct = default)
            {
                if (projectTask is null)
                    throw new ArgumentNullException(nameof(projectTask));

                return await RemoveAllAsync(projectTask.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
