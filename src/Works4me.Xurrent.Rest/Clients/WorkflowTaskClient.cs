using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="WorkflowTask"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/tasks/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class WorkflowTaskClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTaskApproval"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public ApprovalsClient Approvals { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Note"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public NotesClient Notes { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTask"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public PredecessorsClient Predecessors { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public SprintBacklogItemsClient SprintBacklogItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTask"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public SuccessorsClient Successors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowTaskClient"/> class.
        /// </summary>
        internal WorkflowTaskClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "tasks/"))
        {
            Approvals = new ApprovalsClient(this);
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
            Notes = new NotesClient(this);
            Predecessors = new PredecessorsClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
            SprintBacklogItems = new SprintBacklogItemsClient(this);
            Successors = new SuccessorsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="WorkflowTask"/> using the specified <see cref="WorkflowTaskQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflow tasks to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(WorkflowTaskQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<WorkflowTask>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream using the specified <see cref="WorkflowTaskQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflow tasks to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<WorkflowTask> StreamAsync(WorkflowTaskQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<WorkflowTask>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="WorkflowTask"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow task.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="WorkflowTask"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<WorkflowTask?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<WorkflowTask>(new WorkflowTaskQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="WorkflowTask"/>.
        /// </summary>
        /// <param name="workflowTask">The workflow task to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="WorkflowTask"/>.</returns>
        public async Task<WorkflowTask> CreateAsync(WorkflowTask workflowTask, CancellationToken ct = default)
        {
            return await PostItemAsync(workflowTask, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="WorkflowTask"/>.
        /// </summary>
        /// <param name="workflowTask">The workflow task to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="WorkflowTask"/>.</returns>
        public async Task<WorkflowTask> UpdateAsync(WorkflowTask workflowTask, CancellationToken ct = default)
        {
            return await PatchItemAsync(workflowTask, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTaskApproval"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public sealed class ApprovalsClient
        {
            private readonly WorkflowTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ApprovalsClient"/> class.
            /// </summary>
            internal ApprovalsClient(WorkflowTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTaskApproval"/> records for the specified workflow task using an <see cref="WorkflowTaskApprovalQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to retrieve the approvals.</param>
            /// <param name="query">The query that defines which approvals to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTaskApproval"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTaskApproval>> GetAsync(long workflowTaskId, WorkflowTaskApprovalQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTaskApproval>(workflowTaskId, "approvals", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTaskApproval"/> records for the specified workflow task using an <see cref="WorkflowTaskApprovalQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the approvals.</param>
            /// <param name="query">The query that defines which approvals to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTaskApproval"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTaskApproval>> GetAsync(WorkflowTask workflowTask, WorkflowTaskApprovalQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTaskApproval"/> items as an asynchronous stream for the specified workflow task using an <see cref="WorkflowTaskApprovalQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to enumerate the approvals.</param>
            /// <param name="query">The query that defines which approvals to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTaskApproval"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTaskApproval> StreamAsync(long workflowTaskId, WorkflowTaskApprovalQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTaskApproval>(workflowTaskId, "approvals", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTaskApproval"/> items as an asynchronous stream for the specified workflow task using an <see cref="WorkflowTaskApprovalQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to enumerate the approvals.</param>
            /// <param name="query">The query that defines which approvals to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTaskApproval"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTaskApproval> StreamAsync(WorkflowTask workflowTask, WorkflowTaskApprovalQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return StreamAsync(workflowTask.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowTaskApproval"/> by its unique identifier for the specified workflow task.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task.</param>
            /// <param name="workflowTaskApprovalId">The unique identifier of the workflow task approval.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowTaskApproval"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowTaskApproval?> GetAsync(long workflowTaskId, long workflowTaskApprovalId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<WorkflowTaskApproval>(workflowTaskId, "approvals", new WorkflowTaskApprovalQuery().WithId(workflowTaskApprovalId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowTaskApproval"/> record for the specified workflow task.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the workflow task approval.</param>
            /// <param name="workflowTaskApprovalId">The unique identifier of the workflow task approval.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowTaskApproval"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowTaskApproval?> GetAsync(WorkflowTask workflowTask, long workflowTaskApprovalId, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, workflowTaskApprovalId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowTaskApproval"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTaskApproval">The workflow task approval to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskApproval"/>.</returns>
            public async Task<WorkflowTaskApproval> CreateAsync(long workflowTaskId, WorkflowTaskApproval workflowTaskApproval, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowTaskId, "approvals", workflowTaskApproval, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowTaskApproval"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task to which the workflow task approval is added.</param>
            /// <param name="workflowTaskApproval">The workflow task approval to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskApproval"/>.</returns>
            public async Task<WorkflowTaskApproval> CreateAsync(WorkflowTask workflowTask, WorkflowTaskApproval workflowTaskApproval, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await CreateAsync(workflowTask.Id, workflowTaskApproval, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowTaskApproval"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTaskApproval">The workflow task approval to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskApproval"/>.</returns>
            public async Task<WorkflowTaskApproval> UpdateAsync(long workflowTaskId, WorkflowTaskApproval workflowTaskApproval, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(workflowTaskId, "approvals", workflowTaskApproval, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowTaskApproval"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task with which the workflow task approval is associated.</param>
            /// <param name="workflowTaskApproval">The workflow task approval to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskApproval"/>.</returns>
            public async Task<WorkflowTaskApproval> UpdateAsync(WorkflowTask workflowTask, WorkflowTaskApproval workflowTaskApproval, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await UpdateAsync(workflowTask.Id, workflowTaskApproval, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskApproval"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTaskApprovalId">The identifier of the workflow task approval to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowTaskId, long workflowTaskApprovalId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowTaskId, "approvals", workflowTaskApprovalId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskApproval"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTaskApproval">The workflow task approval to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowTaskId, WorkflowTaskApproval workflowTaskApproval, CancellationToken ct = default)
            {
                if (workflowTaskApproval is null)
                    throw new ArgumentNullException(nameof(workflowTaskApproval));

                return await DeleteAsync(workflowTaskId, workflowTaskApproval.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskApproval"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the workflow task approval is removed.</param>
            /// <param name="workflowTaskApproval">The workflow task approval to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WorkflowTask workflowTask, WorkflowTaskApproval workflowTaskApproval, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                if (workflowTaskApproval is null)
                    throw new ArgumentNullException(nameof(workflowTaskApproval));

                return await DeleteAsync(workflowTask.Id, workflowTaskApproval.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskApproval"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the workflow task approval is removed.</param>
            /// <param name="workflowTaskApprovalId">The identifier of the workflow task approval to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WorkflowTask workflowTask, long workflowTaskApprovalId, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await DeleteAsync(workflowTask.Id, workflowTaskApprovalId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all approvals associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long workflowTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTaskId, "approvals", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all approvals associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which all approvals are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await DeleteAllAsync(workflowTask.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly WorkflowTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(WorkflowTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow task using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long workflowTaskId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(workflowTaskId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow task using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(WorkflowTask workflowTask, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow task using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long workflowTaskId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(workflowTaskId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow task using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(WorkflowTask workflowTask, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return StreamAsync(workflowTask.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly WorkflowTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(WorkflowTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow task using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long workflowTaskId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(workflowTaskId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow task using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(WorkflowTask workflowTask, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow task using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long workflowTaskId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(workflowTaskId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow task using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(WorkflowTask workflowTask, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return StreamAsync(workflowTask.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly WorkflowTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(WorkflowTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified workflow task using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long workflowTaskId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(workflowTaskId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified workflow task using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(WorkflowTask workflowTask, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified workflow task using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long workflowTaskId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(workflowTaskId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified workflow task using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(WorkflowTask workflowTask, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return StreamAsync(workflowTask.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowTaskId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowTaskId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowTaskId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(workflowTaskId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTask workflowTask, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(workflowTask.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTask workflowTask, long configurationItemId, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await AddAsync(workflowTask.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowTaskId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowTaskId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowTaskId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(workflowTaskId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTask workflowTask, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(workflowTask.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTask workflowTask, long configurationItemId, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAsync(workflowTask.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long workflowTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTaskId, "cis", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which all configuration items are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAllAsync(workflowTask.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Note"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public sealed class NotesClient
        {
            private readonly WorkflowTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotesClient"/> class.
            /// </summary>
            internal NotesClient(WorkflowTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified workflow task using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(long workflowTaskId, NoteQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Note>(workflowTaskId, "notes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified workflow task using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(WorkflowTask workflowTask, NoteQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified workflow task using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(long workflowTaskId, NoteQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Note>(workflowTaskId, "notes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified workflow task using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(WorkflowTask workflowTask, NoteQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return StreamAsync(workflowTask.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(long workflowTaskId, NoteCreate noteCreate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowTaskId, "notes", noteCreate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task to which the note create is added.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(WorkflowTask workflowTask, NoteCreate noteCreate, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await CreateAsync(workflowTask.Id, noteCreate, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTask"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public sealed class PredecessorsClient
        {
            private readonly WorkflowTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PredecessorsClient"/> class.
            /// </summary>
            internal PredecessorsClient(WorkflowTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified workflow task using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to retrieve the predecessors.</param>
            /// <param name="query">The query that defines which predecessors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(long workflowTaskId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTask>(workflowTaskId, "predecessors", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified workflow task using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the predecessors.</param>
            /// <param name="query">The query that defines which predecessors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(WorkflowTask workflowTask, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified workflow task using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to enumerate the predecessors.</param>
            /// <param name="query">The query that defines which predecessors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(long workflowTaskId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTask>(workflowTaskId, "predecessors", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified workflow task using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to enumerate the predecessors.</param>
            /// <param name="query">The query that defines which predecessors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(WorkflowTask workflowTask, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return StreamAsync(workflowTask.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="WorkflowTask"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTaskId">The identifier of the workflow task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long parentWorkflowTaskId, long workflowTaskId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(parentWorkflowTaskId, "predecessors", workflowTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="WorkflowTask"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTask">The workflow task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long parentWorkflowTaskId, WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await AddAsync(parentWorkflowTaskId, workflowTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="WorkflowTask"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTask">The workflow task from which the workflow task is removed.</param>
            /// <param name="workflowTask">The workflow task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTask parentWorkflowTask, WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (parentWorkflowTask is null)
                    throw new ArgumentNullException(nameof(parentWorkflowTask));

                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await AddAsync(parentWorkflowTask.Id, workflowTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="WorkflowTask"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTask">The workflow task from which the workflow task is removed.</param>
            /// <param name="workflowTaskId">The identifier of the workflow task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTask parentWorkflowTask, long workflowTaskId, CancellationToken ct = default)
            {
                if (parentWorkflowTask is null)
                    throw new ArgumentNullException(nameof(parentWorkflowTask));

                return await AddAsync(parentWorkflowTask.Id, workflowTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="WorkflowTask"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTaskId">The identifier of the workflow task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long parentWorkflowTaskId, long workflowTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(parentWorkflowTaskId, "predecessors", workflowTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="WorkflowTask"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTask">The workflow task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long parentWorkflowTaskId, WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAsync(parentWorkflowTaskId, workflowTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="WorkflowTask"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTask">The workflow task from which the workflow task is removed.</param>
            /// <param name="workflowTask">The workflow task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTask parentWorkflowTask, WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (parentWorkflowTask is null)
                    throw new ArgumentNullException(nameof(parentWorkflowTask));

                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAsync(parentWorkflowTask.Id, workflowTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="WorkflowTask"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTask">The workflow task from which the workflow task is removed.</param>
            /// <param name="workflowTaskId">The identifier of the workflow task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTask parentWorkflowTask, long workflowTaskId, CancellationToken ct = default)
            {
                if (parentWorkflowTask is null)
                    throw new ArgumentNullException(nameof(parentWorkflowTask));

                return await RemoveAsync(parentWorkflowTask.Id, workflowTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all predecessors associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long workflowTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTaskId, "predecessors", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all predecessors associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which all predecessors are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAllAsync(workflowTask.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly WorkflowTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(WorkflowTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified workflow task using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long workflowTaskId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(workflowTaskId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified workflow task using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(WorkflowTask workflowTask, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified workflow task using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long workflowTaskId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(workflowTaskId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified workflow task using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(WorkflowTask workflowTask, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return StreamAsync(workflowTask.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowTaskId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowTaskId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowTaskId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(workflowTaskId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTask workflowTask, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(workflowTask.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTask workflowTask, long serviceInstanceId, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await AddAsync(workflowTask.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowTaskId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowTaskId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowTaskId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(workflowTaskId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTask workflowTask, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(workflowTask.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTask workflowTask, long serviceInstanceId, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAsync(workflowTask.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long workflowTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTaskId, "service_instances", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which all service instances are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAllAsync(workflowTask.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public sealed class SprintBacklogItemsClient
        {
            private readonly WorkflowTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SprintBacklogItemsClient"/> class.
            /// </summary>
            internal SprintBacklogItemsClient(WorkflowTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified workflow task using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to retrieve the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(long workflowTaskId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SprintBacklogItem>(workflowTaskId, "sprint_backlog_items", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified workflow task using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(WorkflowTask workflowTask, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified workflow task using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to enumerate the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(long workflowTaskId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SprintBacklogItem>(workflowTaskId, "sprint_backlog_items", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified workflow task using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to enumerate the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(WorkflowTask workflowTask, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return StreamAsync(workflowTask.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTask"/> records related to an <see cref="WorkflowTask"/>.
        /// </summary>
        public sealed class SuccessorsClient
        {
            private readonly WorkflowTaskClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SuccessorsClient"/> class.
            /// </summary>
            internal SuccessorsClient(WorkflowTaskClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified workflow task using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to retrieve the successors.</param>
            /// <param name="query">The query that defines which successors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(long workflowTaskId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTask>(workflowTaskId, "successors", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified workflow task using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to retrieve the successors.</param>
            /// <param name="query">The query that defines which successors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(WorkflowTask workflowTask, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await GetAsync(workflowTask.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified workflow task using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTaskId">The unique identifier of the workflow task for which to enumerate the successors.</param>
            /// <param name="query">The query that defines which successors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(long workflowTaskId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTask>(workflowTaskId, "successors", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified workflow task using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task for which to enumerate the successors.</param>
            /// <param name="query">The query that defines which successors to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(WorkflowTask workflowTask, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return StreamAsync(workflowTask.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="WorkflowTask"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTaskId">The identifier of the workflow task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long parentWorkflowTaskId, long workflowTaskId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(parentWorkflowTaskId, "successors", workflowTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="WorkflowTask"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTask">The workflow task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long parentWorkflowTaskId, WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await AddAsync(parentWorkflowTaskId, workflowTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="WorkflowTask"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTask">The workflow task from which the workflow task is removed.</param>
            /// <param name="workflowTask">The workflow task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTask parentWorkflowTask, WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (parentWorkflowTask is null)
                    throw new ArgumentNullException(nameof(parentWorkflowTask));

                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await AddAsync(parentWorkflowTask.Id, workflowTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="WorkflowTask"/> to a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTask">The workflow task from which the workflow task is removed.</param>
            /// <param name="workflowTaskId">The identifier of the workflow task to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTask parentWorkflowTask, long workflowTaskId, CancellationToken ct = default)
            {
                if (parentWorkflowTask is null)
                    throw new ArgumentNullException(nameof(parentWorkflowTask));

                return await AddAsync(parentWorkflowTask.Id, workflowTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="WorkflowTask"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTaskId">The identifier of the workflow task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long parentWorkflowTaskId, long workflowTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(parentWorkflowTaskId, "successors", workflowTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="WorkflowTask"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTaskId">The identifier of the workflow task.</param>
            /// <param name="workflowTask">The workflow task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long parentWorkflowTaskId, WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAsync(parentWorkflowTaskId, workflowTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="WorkflowTask"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTask">The workflow task from which the workflow task is removed.</param>
            /// <param name="workflowTask">The workflow task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTask parentWorkflowTask, WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (parentWorkflowTask is null)
                    throw new ArgumentNullException(nameof(parentWorkflowTask));

                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAsync(parentWorkflowTask.Id, workflowTask.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="WorkflowTask"/> associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="parentWorkflowTask">The workflow task from which the workflow task is removed.</param>
            /// <param name="workflowTaskId">The identifier of the workflow task to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTask parentWorkflowTask, long workflowTaskId, CancellationToken ct = default)
            {
                if (parentWorkflowTask is null)
                    throw new ArgumentNullException(nameof(parentWorkflowTask));

                return await RemoveAsync(parentWorkflowTask.Id, workflowTaskId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all successors associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTaskId">The identifier of the workflow task.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long workflowTaskId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTaskId, "successors", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all successors associated with a <see cref="WorkflowTask"/>.
            /// </summary>
            /// <param name="workflowTask">The workflow task from which all successors are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(WorkflowTask workflowTask, CancellationToken ct = default)
            {
                if (workflowTask is null)
                    throw new ArgumentNullException(nameof(workflowTask));

                return await RemoveAllAsync(workflowTask.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
