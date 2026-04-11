using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="WorkflowTemplate"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/workflow_templates/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class WorkflowTemplateClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTemplatePhase"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public PhasesClient Phases { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public TaskTemplateAutomationRulesClient TaskTemplateAutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTaskTemplateRelation"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public TaskTemplateRelationsClient TaskTemplateRelations { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Workflow"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public WorkflowsClient Workflows { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowTemplateClient"/> class.
        /// </summary>
        internal WorkflowTemplateClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "workflow_templates/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
            Phases = new PhasesClient(this);
            TaskTemplateAutomationRules = new TaskTemplateAutomationRulesClient(this);
            TaskTemplateRelations = new TaskTemplateRelationsClient(this);
            Workflows = new WorkflowsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="WorkflowTemplate"/> using the specified <see cref="WorkflowTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflow templates to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="WorkflowTemplate"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<WorkflowTemplate>> GetAsync(WorkflowTemplateQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<WorkflowTemplate>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="WorkflowTemplate"/> items as an asynchronous stream using the specified <see cref="WorkflowTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflow templates to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTemplate"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<WorkflowTemplate> StreamAsync(WorkflowTemplateQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<WorkflowTemplate>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="WorkflowTemplate"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow template.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="WorkflowTemplate"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<WorkflowTemplate?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<WorkflowTemplate>(new WorkflowTemplateQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="WorkflowTemplate"/>.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="WorkflowTemplate"/>.</returns>
        public async Task<WorkflowTemplate> CreateAsync(WorkflowTemplate workflowTemplate, CancellationToken ct = default)
        {
            return await PostItemAsync(workflowTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="WorkflowTemplate"/>.
        /// </summary>
        /// <param name="workflowTemplate">The workflow template to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="WorkflowTemplate"/>.</returns>
        public async Task<WorkflowTemplate> UpdateAsync(WorkflowTemplate workflowTemplate, CancellationToken ct = default)
        {
            return await PatchItemAsync(workflowTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly WorkflowTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(WorkflowTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long workflowTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(workflowTemplateId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(WorkflowTemplate workflowTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await GetAsync(workflowTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long workflowTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(workflowTemplateId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(WorkflowTemplate workflowTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return StreamAsync(workflowTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly WorkflowTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(WorkflowTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long workflowTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(workflowTemplateId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(WorkflowTemplate workflowTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await GetAsync(workflowTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long workflowTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(workflowTemplateId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(WorkflowTemplate workflowTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return StreamAsync(workflowTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTemplatePhase"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public sealed class PhasesClient
        {
            private readonly WorkflowTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PhasesClient"/> class.
            /// </summary>
            internal PhasesClient(WorkflowTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTemplatePhase"/> records for the specified workflow template using an <see cref="WorkflowTemplatePhaseQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to retrieve the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTemplatePhase"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTemplatePhase>> GetAsync(long workflowTemplateId, WorkflowTemplatePhaseQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTemplatePhase>(workflowTemplateId, "phases", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTemplatePhase"/> records for the specified workflow template using an <see cref="WorkflowTemplatePhaseQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to retrieve the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTemplatePhase"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTemplatePhase>> GetAsync(WorkflowTemplate workflowTemplate, WorkflowTemplatePhaseQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await GetAsync(workflowTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTemplatePhase"/> items as an asynchronous stream for the specified workflow template using an <see cref="WorkflowTemplatePhaseQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to enumerate the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTemplatePhase"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTemplatePhase> StreamAsync(long workflowTemplateId, WorkflowTemplatePhaseQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTemplatePhase>(workflowTemplateId, "phases", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTemplatePhase"/> items as an asynchronous stream for the specified workflow template using an <see cref="WorkflowTemplatePhaseQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to enumerate the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTemplatePhase"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTemplatePhase> StreamAsync(WorkflowTemplate workflowTemplate, WorkflowTemplatePhaseQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return StreamAsync(workflowTemplate.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowTemplatePhase"/> by its unique identifier for the specified workflow template.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template.</param>
            /// <param name="workflowTemplatePhaseId">The unique identifier of the workflow template phase.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowTemplatePhase"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowTemplatePhase?> GetAsync(long workflowTemplateId, long workflowTemplatePhaseId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<WorkflowTemplatePhase>(workflowTemplateId, "phases", new WorkflowTemplatePhaseQuery().WithId(workflowTemplatePhaseId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowTemplatePhase"/> record for the specified workflow template.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to retrieve the workflow template phase.</param>
            /// <param name="workflowTemplatePhaseId">The unique identifier of the workflow template phase.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowTemplatePhase"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowTemplatePhase?> GetAsync(WorkflowTemplate workflowTemplate, long workflowTemplatePhaseId, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await GetAsync(workflowTemplate.Id, workflowTemplatePhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowTemplatePhase"/> to a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="workflowTemplatePhase">The workflow template phase to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTemplatePhase"/>.</returns>
            public async Task<WorkflowTemplatePhase> CreateAsync(long workflowTemplateId, WorkflowTemplatePhase workflowTemplatePhase, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowTemplateId, "phases", workflowTemplatePhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowTemplatePhase"/> to a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template to which the workflow template phase is added.</param>
            /// <param name="workflowTemplatePhase">The workflow template phase to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTemplatePhase"/>.</returns>
            public async Task<WorkflowTemplatePhase> CreateAsync(WorkflowTemplate workflowTemplate, WorkflowTemplatePhase workflowTemplatePhase, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await CreateAsync(workflowTemplate.Id, workflowTemplatePhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowTemplatePhase"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="workflowTemplatePhase">The workflow template phase to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTemplatePhase"/>.</returns>
            public async Task<WorkflowTemplatePhase> UpdateAsync(long workflowTemplateId, WorkflowTemplatePhase workflowTemplatePhase, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(workflowTemplateId, "phases", workflowTemplatePhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowTemplatePhase"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template with which the workflow template phase is associated.</param>
            /// <param name="workflowTemplatePhase">The workflow template phase to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTemplatePhase"/>.</returns>
            public async Task<WorkflowTemplatePhase> UpdateAsync(WorkflowTemplate workflowTemplate, WorkflowTemplatePhase workflowTemplatePhase, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await UpdateAsync(workflowTemplate.Id, workflowTemplatePhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTemplatePhase"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="workflowTemplatePhaseId">The identifier of the workflow template phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowTemplateId, long workflowTemplatePhaseId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowTemplateId, "phases", workflowTemplatePhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTemplatePhase"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="workflowTemplatePhase">The workflow template phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowTemplateId, WorkflowTemplatePhase workflowTemplatePhase, CancellationToken ct = default)
            {
                if (workflowTemplatePhase is null)
                    throw new ArgumentNullException(nameof(workflowTemplatePhase));

                return await DeleteAsync(workflowTemplateId, workflowTemplatePhase.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTemplatePhase"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template from which the workflow template phase is removed.</param>
            /// <param name="workflowTemplatePhase">The workflow template phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WorkflowTemplate workflowTemplate, WorkflowTemplatePhase workflowTemplatePhase, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                if (workflowTemplatePhase is null)
                    throw new ArgumentNullException(nameof(workflowTemplatePhase));

                return await DeleteAsync(workflowTemplate.Id, workflowTemplatePhase.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTemplatePhase"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template from which the workflow template phase is removed.</param>
            /// <param name="workflowTemplatePhaseId">The identifier of the workflow template phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WorkflowTemplate workflowTemplate, long workflowTemplatePhaseId, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await DeleteAsync(workflowTemplate.Id, workflowTemplatePhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all phases associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long workflowTemplateId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTemplateId, "phases", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all phases associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template from which all phases are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(WorkflowTemplate workflowTemplate, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await DeleteAllAsync(workflowTemplate.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public sealed class TaskTemplateAutomationRulesClient
        {
            private readonly WorkflowTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TaskTemplateAutomationRulesClient"/> class.
            /// </summary>
            internal TaskTemplateAutomationRulesClient(WorkflowTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to retrieve the task template automation rules.</param>
            /// <param name="query">The query that defines which task template automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long workflowTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(workflowTemplateId, "task_template_automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to retrieve the task template automation rules.</param>
            /// <param name="query">The query that defines which task template automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(WorkflowTemplate workflowTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await GetAsync(workflowTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to enumerate the task template automation rules.</param>
            /// <param name="query">The query that defines which task template automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long workflowTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(workflowTemplateId, "task_template_automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to enumerate the task template automation rules.</param>
            /// <param name="query">The query that defines which task template automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(WorkflowTemplate workflowTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return StreamAsync(workflowTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTaskTemplateRelation"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public sealed class TaskTemplateRelationsClient
        {
            private readonly WorkflowTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TaskTemplateRelationsClient"/> class.
            /// </summary>
            internal TaskTemplateRelationsClient(WorkflowTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTaskTemplateRelation"/> records for the specified workflow template using an <see cref="WorkflowTaskTemplateRelationQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to retrieve the task template relations.</param>
            /// <param name="query">The query that defines which task template relations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTaskTemplateRelation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTaskTemplateRelation>> GetAsync(long workflowTemplateId, WorkflowTaskTemplateRelationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTaskTemplateRelation>(workflowTemplateId, "task_template_relations", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTaskTemplateRelation"/> records for the specified workflow template using an <see cref="WorkflowTaskTemplateRelationQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to retrieve the task template relations.</param>
            /// <param name="query">The query that defines which task template relations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTaskTemplateRelation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTaskTemplateRelation>> GetAsync(WorkflowTemplate workflowTemplate, WorkflowTaskTemplateRelationQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await GetAsync(workflowTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTaskTemplateRelation"/> items as an asynchronous stream for the specified workflow template using an <see cref="WorkflowTaskTemplateRelationQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to enumerate the task template relations.</param>
            /// <param name="query">The query that defines which task template relations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTaskTemplateRelation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTaskTemplateRelation> StreamAsync(long workflowTemplateId, WorkflowTaskTemplateRelationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTaskTemplateRelation>(workflowTemplateId, "task_template_relations", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTaskTemplateRelation"/> items as an asynchronous stream for the specified workflow template using an <see cref="WorkflowTaskTemplateRelationQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to enumerate the task template relations.</param>
            /// <param name="query">The query that defines which task template relations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTaskTemplateRelation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTaskTemplateRelation> StreamAsync(WorkflowTemplate workflowTemplate, WorkflowTaskTemplateRelationQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return StreamAsync(workflowTemplate.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowTaskTemplateRelation"/> by its unique identifier for the specified workflow template.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template.</param>
            /// <param name="workflowTaskTemplateRelationId">The unique identifier of the workflow task template relation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowTaskTemplateRelation"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowTaskTemplateRelation?> GetAsync(long workflowTemplateId, long workflowTaskTemplateRelationId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<WorkflowTaskTemplateRelation>(workflowTemplateId, "task_template_relations", new WorkflowTaskTemplateRelationQuery().WithId(workflowTaskTemplateRelationId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowTaskTemplateRelation"/> record for the specified workflow template.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to retrieve the workflow task template relation.</param>
            /// <param name="workflowTaskTemplateRelationId">The unique identifier of the workflow task template relation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowTaskTemplateRelation"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowTaskTemplateRelation?> GetAsync(WorkflowTemplate workflowTemplate, long workflowTaskTemplateRelationId, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await GetAsync(workflowTemplate.Id, workflowTaskTemplateRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowTaskTemplateRelation"/> to a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="workflowTaskTemplateRelation">The workflow task template relation to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskTemplateRelation"/>.</returns>
            public async Task<WorkflowTaskTemplateRelation> CreateAsync(long workflowTemplateId, WorkflowTaskTemplateRelation workflowTaskTemplateRelation, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowTemplateId, "task_template_relations", workflowTaskTemplateRelation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowTaskTemplateRelation"/> to a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template to which the workflow task template relation is added.</param>
            /// <param name="workflowTaskTemplateRelation">The workflow task template relation to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskTemplateRelation"/>.</returns>
            public async Task<WorkflowTaskTemplateRelation> CreateAsync(WorkflowTemplate workflowTemplate, WorkflowTaskTemplateRelation workflowTaskTemplateRelation, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await CreateAsync(workflowTemplate.Id, workflowTaskTemplateRelation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowTaskTemplateRelation"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="workflowTaskTemplateRelation">The workflow task template relation to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskTemplateRelation"/>.</returns>
            public async Task<WorkflowTaskTemplateRelation> UpdateAsync(long workflowTemplateId, WorkflowTaskTemplateRelation workflowTaskTemplateRelation, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(workflowTemplateId, "task_template_relations", workflowTaskTemplateRelation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowTaskTemplateRelation"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template with which the workflow task template relation is associated.</param>
            /// <param name="workflowTaskTemplateRelation">The workflow task template relation to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskTemplateRelation"/>.</returns>
            public async Task<WorkflowTaskTemplateRelation> UpdateAsync(WorkflowTemplate workflowTemplate, WorkflowTaskTemplateRelation workflowTaskTemplateRelation, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await UpdateAsync(workflowTemplate.Id, workflowTaskTemplateRelation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskTemplateRelation"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="workflowTaskTemplateRelationId">The identifier of the workflow task template relation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowTemplateId, long workflowTaskTemplateRelationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowTemplateId, "task_template_relations", workflowTaskTemplateRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskTemplateRelation"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="workflowTaskTemplateRelation">The workflow task template relation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowTemplateId, WorkflowTaskTemplateRelation workflowTaskTemplateRelation, CancellationToken ct = default)
            {
                if (workflowTaskTemplateRelation is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplateRelation));

                return await DeleteAsync(workflowTemplateId, workflowTaskTemplateRelation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskTemplateRelation"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template from which the workflow task template relation is removed.</param>
            /// <param name="workflowTaskTemplateRelation">The workflow task template relation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WorkflowTemplate workflowTemplate, WorkflowTaskTemplateRelation workflowTaskTemplateRelation, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                if (workflowTaskTemplateRelation is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplateRelation));

                return await DeleteAsync(workflowTemplate.Id, workflowTaskTemplateRelation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskTemplateRelation"/> associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template from which the workflow task template relation is removed.</param>
            /// <param name="workflowTaskTemplateRelationId">The identifier of the workflow task template relation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WorkflowTemplate workflowTemplate, long workflowTaskTemplateRelationId, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await DeleteAsync(workflowTemplate.Id, workflowTaskTemplateRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all task template relations associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The identifier of the workflow template.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long workflowTemplateId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTemplateId, "task_template_relations", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all task template relations associated with a <see cref="WorkflowTemplate"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template from which all task template relations are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(WorkflowTemplate workflowTemplate, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await DeleteAllAsync(workflowTemplate.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Workflow"/> records related to an <see cref="WorkflowTemplate"/>.
        /// </summary>
        public sealed class WorkflowsClient
        {
            private readonly WorkflowTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="WorkflowsClient"/> class.
            /// </summary>
            internal WorkflowsClient(WorkflowTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Workflow"/> records for the specified workflow template using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to retrieve the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Workflow"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Workflow>> GetAsync(long workflowTemplateId, WorkflowQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Workflow>(workflowTemplateId, "workflows", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Workflow"/> records for the specified workflow template using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to retrieve the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Workflow"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Workflow>> GetAsync(WorkflowTemplate workflowTemplate, WorkflowQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return await GetAsync(workflowTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Workflow"/> items as an asynchronous stream for the specified workflow template using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="workflowTemplateId">The unique identifier of the workflow template for which to enumerate the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Workflow"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Workflow> StreamAsync(long workflowTemplateId, WorkflowQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Workflow>(workflowTemplateId, "workflows", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Workflow"/> items as an asynchronous stream for the specified workflow template using an <see cref="WorkflowQuery"/>.
            /// </summary>
            /// <param name="workflowTemplate">The workflow template for which to enumerate the workflows.</param>
            /// <param name="query">The query that defines which workflows to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Workflow"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Workflow> StreamAsync(WorkflowTemplate workflowTemplate, WorkflowQuery query, CancellationToken ct = default)
            {
                if (workflowTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTemplate));

                return StreamAsync(workflowTemplate.Id, query, ct);
            }
        }
    }
}
