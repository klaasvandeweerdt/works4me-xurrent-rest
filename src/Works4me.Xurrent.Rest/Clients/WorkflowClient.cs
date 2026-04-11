using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Workflow"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/workflows/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class WorkflowClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Note"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public NotesClient Notes { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowPhase"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public PhasesClient Phases { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Problem"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public ProblemsClient Problems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Request"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public RequestsClient Requests { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTask"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public TasksClient Tasks { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowClient"/> class.
        /// </summary>
        internal WorkflowClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "workflows/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
            Notes = new NotesClient(this);
            Phases = new PhasesClient(this);
            Problems = new ProblemsClient(this);
            Requests = new RequestsClient(this);
            Tasks = new TasksClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Workflow"/> using the specified <see cref="WorkflowQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflows to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Workflow"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Workflow>> GetAsync(WorkflowQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Workflow>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Workflow"/> items as an asynchronous stream using the specified <see cref="WorkflowQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflows to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Workflow"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Workflow> StreamAsync(WorkflowQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Workflow>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Workflow"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Workflow"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Workflow?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Workflow>(new WorkflowQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Archive a <see cref="Workflow"/>.<br />
        /// The workflow must be disabled.
        /// </summary>
        /// <param name="workflow">The workflow to archive.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The archived <see cref="Workflow"/>.</returns>
        public async Task<Workflow> ArchiveAsync(Workflow workflow, CancellationToken ct = default)
        {
            return await PostItemAsync(workflow, "archive", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Workflow"/>.
        /// </summary>
        /// <param name="workflow">The workflow to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Workflow"/>.</returns>
        public async Task<Workflow> CreateAsync(Workflow workflow, CancellationToken ct = default)
        {
            return await PostItemAsync(workflow, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Workflow"/>.
        /// </summary>
        /// <param name="workflowId">The identifier of the workflow to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Workflow"/>.</returns>
        public async Task<Workflow> RestoreAsync(long workflowId, CancellationToken ct = default)
        {
            return await PostItemAsync(new Workflow(workflowId), "restore", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Workflow"/>.
        /// </summary>
        /// <param name="reference">The reference to the workflow to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Workflow"/>.</returns>
        public async Task<Workflow> RestoreAsync(ResourceReference reference, CancellationToken ct = default)
        {
            if (reference is null)
                throw new ArgumentNullException(nameof(reference));

            if (!reference.Id.HasValue)
                throw new ArgumentException("The archive reference must have a valid identifier.", nameof(reference));

            return await RestoreAsync(reference.Id.Value, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Trash a <see cref="Workflow"/>.<br />
        /// The workflow must be disabled.
        /// </summary>
        /// <param name="workflow">The workflow to trash.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The trashed <see cref="Workflow"/>.</returns>
        public async Task<Workflow> TrashAsync(Workflow workflow, CancellationToken ct = default)
        {
            return await PostItemAsync(workflow, "trash", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Workflow"/>.
        /// </summary>
        /// <param name="workflow">The workflow to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Workflow"/>.</returns>
        public async Task<Workflow> UpdateAsync(Workflow workflow, CancellationToken ct = default)
        {
            return await PatchItemAsync(workflow, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly WorkflowClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(WorkflowClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long workflowId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(workflowId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Workflow workflow, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await GetAsync(workflow.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long workflowId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(workflowId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Workflow workflow, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return StreamAsync(workflow.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly WorkflowClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(WorkflowClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long workflowId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(workflowId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(Workflow workflow, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await GetAsync(workflow.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long workflowId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(workflowId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(Workflow workflow, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return StreamAsync(workflow.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Note"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public sealed class NotesClient
        {
            private readonly WorkflowClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotesClient"/> class.
            /// </summary>
            internal NotesClient(WorkflowClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified workflow using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(long workflowId, NoteQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Note>(workflowId, "notes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified workflow using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(Workflow workflow, NoteQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await GetAsync(workflow.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified workflow using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(long workflowId, NoteQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Note>(workflowId, "notes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified workflow using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(Workflow workflow, NoteQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return StreamAsync(workflow.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(long workflowId, NoteCreate noteCreate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowId, "notes", noteCreate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow to which the note create is added.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(Workflow workflow, NoteCreate noteCreate, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await CreateAsync(workflow.Id, noteCreate, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowPhase"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public sealed class PhasesClient
        {
            private readonly WorkflowClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PhasesClient"/> class.
            /// </summary>
            internal PhasesClient(WorkflowClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowPhase"/> records for the specified workflow using an <see cref="WorkflowPhaseQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to retrieve the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowPhase"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowPhase>> GetAsync(long workflowId, WorkflowPhaseQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowPhase>(workflowId, "phases", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowPhase"/> records for the specified workflow using an <see cref="WorkflowPhaseQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to retrieve the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowPhase"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowPhase>> GetAsync(Workflow workflow, WorkflowPhaseQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await GetAsync(workflow.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowPhase"/> items as an asynchronous stream for the specified workflow using an <see cref="WorkflowPhaseQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to enumerate the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowPhase"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowPhase> StreamAsync(long workflowId, WorkflowPhaseQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowPhase>(workflowId, "phases", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowPhase"/> items as an asynchronous stream for the specified workflow using an <see cref="WorkflowPhaseQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to enumerate the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowPhase"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowPhase> StreamAsync(Workflow workflow, WorkflowPhaseQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return StreamAsync(workflow.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowPhase"/> by its unique identifier for the specified workflow.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow.</param>
            /// <param name="workflowPhaseId">The unique identifier of the workflow phase.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowPhase"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowPhase?> GetAsync(long workflowId, long workflowPhaseId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<WorkflowPhase>(workflowId, "phases", new WorkflowPhaseQuery().WithId(workflowPhaseId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowPhase"/> record for the specified workflow.
            /// </summary>
            /// <param name="workflow">The workflow for which to retrieve the workflow phase.</param>
            /// <param name="workflowPhaseId">The unique identifier of the workflow phase.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowPhase"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowPhase?> GetAsync(Workflow workflow, long workflowPhaseId, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await GetAsync(workflow.Id, workflowPhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowPhase"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="workflowPhase">The workflow phase to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowPhase"/>.</returns>
            public async Task<WorkflowPhase> CreateAsync(long workflowId, WorkflowPhase workflowPhase, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowId, "phases", workflowPhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowPhase"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow to which the workflow phase is added.</param>
            /// <param name="workflowPhase">The workflow phase to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowPhase"/>.</returns>
            public async Task<WorkflowPhase> CreateAsync(Workflow workflow, WorkflowPhase workflowPhase, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await CreateAsync(workflow.Id, workflowPhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowPhase"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="workflowPhase">The workflow phase to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowPhase"/>.</returns>
            public async Task<WorkflowPhase> UpdateAsync(long workflowId, WorkflowPhase workflowPhase, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(workflowId, "phases", workflowPhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowPhase"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow with which the workflow phase is associated.</param>
            /// <param name="workflowPhase">The workflow phase to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowPhase"/>.</returns>
            public async Task<WorkflowPhase> UpdateAsync(Workflow workflow, WorkflowPhase workflowPhase, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await UpdateAsync(workflow.Id, workflowPhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowPhase"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="workflowPhaseId">The identifier of the workflow phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowId, long workflowPhaseId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowId, "phases", workflowPhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowPhase"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="workflowPhase">The workflow phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowId, WorkflowPhase workflowPhase, CancellationToken ct = default)
            {
                if (workflowPhase is null)
                    throw new ArgumentNullException(nameof(workflowPhase));

                return await DeleteAsync(workflowId, workflowPhase.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowPhase"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the workflow phase is removed.</param>
            /// <param name="workflowPhase">The workflow phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Workflow workflow, WorkflowPhase workflowPhase, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                if (workflowPhase is null)
                    throw new ArgumentNullException(nameof(workflowPhase));

                return await DeleteAsync(workflow.Id, workflowPhase.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowPhase"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the workflow phase is removed.</param>
            /// <param name="workflowPhaseId">The identifier of the workflow phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Workflow workflow, long workflowPhaseId, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await DeleteAsync(workflow.Id, workflowPhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all phases associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long workflowId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowId, "phases", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all phases associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which all phases are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Workflow workflow, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await DeleteAllAsync(workflow.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Problem"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public sealed class ProblemsClient
        {
            private readonly WorkflowClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ProblemsClient"/> class.
            /// </summary>
            internal ProblemsClient(WorkflowClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Problem"/> records for the specified workflow using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to retrieve the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Problem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Problem>> GetAsync(long workflowId, ProblemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Problem>(workflowId, "problems", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Problem"/> records for the specified workflow using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to retrieve the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Problem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Problem>> GetAsync(Workflow workflow, ProblemQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await GetAsync(workflow.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Problem"/> items as an asynchronous stream for the specified workflow using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to enumerate the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Problem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Problem> StreamAsync(long workflowId, ProblemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Problem>(workflowId, "problems", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Problem"/> items as an asynchronous stream for the specified workflow using an <see cref="ProblemQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to enumerate the problems.</param>
            /// <param name="query">The query that defines which problems to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Problem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Problem> StreamAsync(Workflow workflow, ProblemQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return StreamAsync(workflow.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Problem"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="problemId">The identifier of the problem to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowId, long problemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowId, "problems", problemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Problem"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="problem">The problem to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowId, Problem problem, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await AddAsync(workflowId, problem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Problem"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the problem is removed.</param>
            /// <param name="problem">The problem to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Workflow workflow, Problem problem, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await AddAsync(workflow.Id, problem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Problem"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the problem is removed.</param>
            /// <param name="problemId">The identifier of the problem to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Workflow workflow, long problemId, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await AddAsync(workflow.Id, problemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Problem"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="problemId">The identifier of the problem to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowId, long problemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowId, "problems", problemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Problem"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="problem">The problem to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowId, Problem problem, CancellationToken ct = default)
            {
                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAsync(workflowId, problem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Problem"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the problem is removed.</param>
            /// <param name="problem">The problem to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Workflow workflow, Problem problem, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                if (problem is null)
                    throw new ArgumentNullException(nameof(problem));

                return await RemoveAsync(workflow.Id, problem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Problem"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the problem is removed.</param>
            /// <param name="problemId">The identifier of the problem to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Workflow workflow, long problemId, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await RemoveAsync(workflow.Id, problemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all problems associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long workflowId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowId, "problems", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all problems associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which all problems are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Workflow workflow, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await RemoveAllAsync(workflow.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Request"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public sealed class RequestsClient
        {
            private readonly WorkflowClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RequestsClient"/> class.
            /// </summary>
            internal RequestsClient(WorkflowClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified workflow using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(long workflowId, RequestQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Request>(workflowId, "requests", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified workflow using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(Workflow workflow, RequestQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await GetAsync(workflow.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified workflow using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(long workflowId, RequestQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Request>(workflowId, "requests", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified workflow using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(Workflow workflow, RequestQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return StreamAsync(workflow.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="requestId">The identifier of the request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowId, long requestId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowId, "requests", requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="request">The request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowId, Request request, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await AddAsync(workflowId, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the request is removed.</param>
            /// <param name="request">The request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Workflow workflow, Request request, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await AddAsync(workflow.Id, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Request"/> to a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the request is removed.</param>
            /// <param name="requestId">The identifier of the request to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Workflow workflow, long requestId, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await AddAsync(workflow.Id, requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="requestId">The identifier of the request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowId, long requestId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowId, "requests", requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="request">The request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowId, Request request, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await RemoveAsync(workflowId, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the request is removed.</param>
            /// <param name="request">The request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Workflow workflow, Request request, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await RemoveAsync(workflow.Id, request.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Request"/> associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which the request is removed.</param>
            /// <param name="requestId">The identifier of the request to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Workflow workflow, long requestId, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await RemoveAsync(workflow.Id, requestId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all requests associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflowId">The identifier of the workflow.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long workflowId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowId, "requests", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all requests associated with a <see cref="Workflow"/>.
            /// </summary>
            /// <param name="workflow">The workflow from which all requests are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Workflow workflow, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await RemoveAllAsync(workflow.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTask"/> records related to an <see cref="Workflow"/>.
        /// </summary>
        public sealed class TasksClient
        {
            private readonly WorkflowClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TasksClient"/> class.
            /// </summary>
            internal TasksClient(WorkflowClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified workflow using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to retrieve the tasks.</param>
            /// <param name="query">The query that defines which tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(long workflowId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTask>(workflowId, "tasks", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified workflow using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to retrieve the tasks.</param>
            /// <param name="query">The query that defines which tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(Workflow workflow, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return await GetAsync(workflow.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified workflow using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowId">The unique identifier of the workflow for which to enumerate the tasks.</param>
            /// <param name="query">The query that defines which tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(long workflowId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTask>(workflowId, "tasks", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified workflow using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflow">The workflow for which to enumerate the tasks.</param>
            /// <param name="query">The query that defines which tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(Workflow workflow, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (workflow is null)
                    throw new ArgumentNullException(nameof(workflow));

                return StreamAsync(workflow.Id, query, ct);
            }
        }
    }
}
