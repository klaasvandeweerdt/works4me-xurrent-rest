using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="WorkflowTaskTemplate"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/task_templates/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class WorkflowTaskTemplateClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTaskTemplateApproval"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public ApprovalsClient Approvals { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTask"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public WorkflowTasksClient WorkflowTasks { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTemplate"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public WorkflowTemplatesClient WorkflowTemplates { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowTaskTemplateClient"/> class.
        /// </summary>
        internal WorkflowTaskTemplateClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "task_templates/"))
        {
            Approvals = new ApprovalsClient(this);
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
            WorkflowTasks = new WorkflowTasksClient(this);
            WorkflowTemplates = new WorkflowTemplatesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="WorkflowTaskTemplate"/> using the specified <see cref="WorkflowTaskTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflow task templates to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="WorkflowTaskTemplate"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<WorkflowTaskTemplate>> GetAsync(WorkflowTaskTemplateQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<WorkflowTaskTemplate>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="WorkflowTaskTemplate"/> items as an asynchronous stream using the specified <see cref="WorkflowTaskTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which workflow task templates to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTaskTemplate"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<WorkflowTaskTemplate> StreamAsync(WorkflowTaskTemplateQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<WorkflowTaskTemplate>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="WorkflowTaskTemplate"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the workflow task template.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="WorkflowTaskTemplate"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<WorkflowTaskTemplate?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<WorkflowTaskTemplate>(new WorkflowTaskTemplateQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        /// <param name="workflowTaskTemplate">The workflow task template to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="WorkflowTaskTemplate"/>.</returns>
        public async Task<WorkflowTaskTemplate> CreateAsync(WorkflowTaskTemplate workflowTaskTemplate, CancellationToken ct = default)
        {
            return await PostItemAsync(workflowTaskTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        /// <param name="workflowTaskTemplate">The workflow task template to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="WorkflowTaskTemplate"/>.</returns>
        public async Task<WorkflowTaskTemplate> UpdateAsync(WorkflowTaskTemplate workflowTaskTemplate, CancellationToken ct = default)
        {
            return await PatchItemAsync(workflowTaskTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTaskTemplateApproval"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public sealed class ApprovalsClient
        {
            private readonly WorkflowTaskTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ApprovalsClient"/> class.
            /// </summary>
            internal ApprovalsClient(WorkflowTaskTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTaskTemplateApproval"/> records for the specified workflow task template using an <see cref="WorkflowTaskTemplateApprovalQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to retrieve the approvals.</param>
            /// <param name="query">The query that defines which approvals to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTaskTemplateApproval"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTaskTemplateApproval>> GetAsync(long workflowTaskTemplateId, WorkflowTaskTemplateApprovalQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTaskTemplateApproval>(workflowTaskTemplateId, "approvals", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTaskTemplateApproval"/> records for the specified workflow task template using an <see cref="WorkflowTaskTemplateApprovalQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to retrieve the approvals.</param>
            /// <param name="query">The query that defines which approvals to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTaskTemplateApproval"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTaskTemplateApproval>> GetAsync(WorkflowTaskTemplate workflowTaskTemplate, WorkflowTaskTemplateApprovalQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await GetAsync(workflowTaskTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTaskTemplateApproval"/> items as an asynchronous stream for the specified workflow task template using an <see cref="WorkflowTaskTemplateApprovalQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to enumerate the approvals.</param>
            /// <param name="query">The query that defines which approvals to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTaskTemplateApproval"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTaskTemplateApproval> StreamAsync(long workflowTaskTemplateId, WorkflowTaskTemplateApprovalQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTaskTemplateApproval>(workflowTaskTemplateId, "approvals", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTaskTemplateApproval"/> items as an asynchronous stream for the specified workflow task template using an <see cref="WorkflowTaskTemplateApprovalQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to enumerate the approvals.</param>
            /// <param name="query">The query that defines which approvals to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTaskTemplateApproval"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTaskTemplateApproval> StreamAsync(WorkflowTaskTemplate workflowTaskTemplate, WorkflowTaskTemplateApprovalQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return StreamAsync(workflowTaskTemplate.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowTaskTemplateApproval"/> by its unique identifier for the specified workflow task template.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template.</param>
            /// <param name="workflowTaskTemplateApprovalId">The unique identifier of the workflow task template approval.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowTaskTemplateApproval"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowTaskTemplateApproval?> GetAsync(long workflowTaskTemplateId, long workflowTaskTemplateApprovalId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<WorkflowTaskTemplateApproval>(workflowTaskTemplateId, "approvals", new WorkflowTaskTemplateApprovalQuery().WithId(workflowTaskTemplateApprovalId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="WorkflowTaskTemplateApproval"/> record for the specified workflow task template.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to retrieve the workflow task template approval.</param>
            /// <param name="workflowTaskTemplateApprovalId">The unique identifier of the workflow task template approval.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="WorkflowTaskTemplateApproval"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<WorkflowTaskTemplateApproval?> GetAsync(WorkflowTaskTemplate workflowTaskTemplate, long workflowTaskTemplateApprovalId, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await GetAsync(workflowTaskTemplate.Id, workflowTaskTemplateApprovalId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowTaskTemplateApproval"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="workflowTaskTemplateApproval">The workflow task template approval to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskTemplateApproval"/>.</returns>
            public async Task<WorkflowTaskTemplateApproval> CreateAsync(long workflowTaskTemplateId, WorkflowTaskTemplateApproval workflowTaskTemplateApproval, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowTaskTemplateId, "approvals", workflowTaskTemplateApproval, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="WorkflowTaskTemplateApproval"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template to which the workflow task template approval is added.</param>
            /// <param name="workflowTaskTemplateApproval">The workflow task template approval to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskTemplateApproval"/>.</returns>
            public async Task<WorkflowTaskTemplateApproval> CreateAsync(WorkflowTaskTemplate workflowTaskTemplate, WorkflowTaskTemplateApproval workflowTaskTemplateApproval, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await CreateAsync(workflowTaskTemplate.Id, workflowTaskTemplateApproval, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowTaskTemplateApproval"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="workflowTaskTemplateApproval">The workflow task template approval to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskTemplateApproval"/>.</returns>
            public async Task<WorkflowTaskTemplateApproval> UpdateAsync(long workflowTaskTemplateId, WorkflowTaskTemplateApproval workflowTaskTemplateApproval, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(workflowTaskTemplateId, "approvals", workflowTaskTemplateApproval, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="WorkflowTaskTemplateApproval"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template with which the workflow task template approval is associated.</param>
            /// <param name="workflowTaskTemplateApproval">The workflow task template approval to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="WorkflowTaskTemplateApproval"/>.</returns>
            public async Task<WorkflowTaskTemplateApproval> UpdateAsync(WorkflowTaskTemplate workflowTaskTemplate, WorkflowTaskTemplateApproval workflowTaskTemplateApproval, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await UpdateAsync(workflowTaskTemplate.Id, workflowTaskTemplateApproval, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskTemplateApproval"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="workflowTaskTemplateApprovalId">The identifier of the workflow task template approval to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowTaskTemplateId, long workflowTaskTemplateApprovalId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowTaskTemplateId, "approvals", workflowTaskTemplateApprovalId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskTemplateApproval"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="workflowTaskTemplateApproval">The workflow task template approval to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long workflowTaskTemplateId, WorkflowTaskTemplateApproval workflowTaskTemplateApproval, CancellationToken ct = default)
            {
                if (workflowTaskTemplateApproval is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplateApproval));

                return await DeleteAsync(workflowTaskTemplateId, workflowTaskTemplateApproval.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskTemplateApproval"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the workflow task template approval is removed.</param>
            /// <param name="workflowTaskTemplateApproval">The workflow task template approval to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WorkflowTaskTemplate workflowTaskTemplate, WorkflowTaskTemplateApproval workflowTaskTemplateApproval, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                if (workflowTaskTemplateApproval is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplateApproval));

                return await DeleteAsync(workflowTaskTemplate.Id, workflowTaskTemplateApproval.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="WorkflowTaskTemplateApproval"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the workflow task template approval is removed.</param>
            /// <param name="workflowTaskTemplateApprovalId">The identifier of the workflow task template approval to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(WorkflowTaskTemplate workflowTaskTemplate, long workflowTaskTemplateApprovalId, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await DeleteAsync(workflowTaskTemplate.Id, workflowTaskTemplateApprovalId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all approvals associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long workflowTaskTemplateId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTaskTemplateId, "approvals", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all approvals associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which all approvals are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(WorkflowTaskTemplate workflowTaskTemplate, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await DeleteAllAsync(workflowTaskTemplate.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly WorkflowTaskTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(WorkflowTaskTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow task template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long workflowTaskTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(workflowTaskTemplateId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified workflow task template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(WorkflowTaskTemplate workflowTaskTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await GetAsync(workflowTaskTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow task template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long workflowTaskTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(workflowTaskTemplateId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified workflow task template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(WorkflowTaskTemplate workflowTaskTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return StreamAsync(workflowTaskTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly WorkflowTaskTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(WorkflowTaskTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow task template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long workflowTaskTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(workflowTaskTemplateId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified workflow task template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(WorkflowTaskTemplate workflowTaskTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await GetAsync(workflowTaskTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow task template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long workflowTaskTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(workflowTaskTemplateId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified workflow task template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(WorkflowTaskTemplate workflowTaskTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return StreamAsync(workflowTaskTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly WorkflowTaskTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(WorkflowTaskTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified workflow task template using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long workflowTaskTemplateId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(workflowTaskTemplateId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified workflow task template using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(WorkflowTaskTemplate workflowTaskTemplate, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await GetAsync(workflowTaskTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified workflow task template using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long workflowTaskTemplateId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(workflowTaskTemplateId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified workflow task template using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(WorkflowTaskTemplate workflowTaskTemplate, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return StreamAsync(workflowTaskTemplate.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowTaskTemplateId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowTaskTemplateId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowTaskTemplateId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(workflowTaskTemplateId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTaskTemplate workflowTaskTemplate, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(workflowTaskTemplate.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTaskTemplate workflowTaskTemplate, long configurationItemId, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await AddAsync(workflowTaskTemplate.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowTaskTemplateId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowTaskTemplateId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowTaskTemplateId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(workflowTaskTemplateId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTaskTemplate workflowTaskTemplate, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(workflowTaskTemplate.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTaskTemplate workflowTaskTemplate, long configurationItemId, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await RemoveAsync(workflowTaskTemplate.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long workflowTaskTemplateId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTaskTemplateId, "cis", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which all configuration items are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(WorkflowTaskTemplate workflowTaskTemplate, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await RemoveAllAsync(workflowTaskTemplate.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly WorkflowTaskTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(WorkflowTaskTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified workflow task template using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long workflowTaskTemplateId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(workflowTaskTemplateId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified workflow task template using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(WorkflowTaskTemplate workflowTaskTemplate, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await GetAsync(workflowTaskTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified workflow task template using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long workflowTaskTemplateId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(workflowTaskTemplateId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified workflow task template using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(WorkflowTaskTemplate workflowTaskTemplate, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return StreamAsync(workflowTaskTemplate.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowTaskTemplateId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(workflowTaskTemplateId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long workflowTaskTemplateId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(workflowTaskTemplateId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTaskTemplate workflowTaskTemplate, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(workflowTaskTemplate.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(WorkflowTaskTemplate workflowTaskTemplate, long serviceInstanceId, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await AddAsync(workflowTaskTemplate.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowTaskTemplateId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(workflowTaskTemplateId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long workflowTaskTemplateId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(workflowTaskTemplateId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTaskTemplate workflowTaskTemplate, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(workflowTaskTemplate.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(WorkflowTaskTemplate workflowTaskTemplate, long serviceInstanceId, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await RemoveAsync(workflowTaskTemplate.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The identifier of the workflow task template.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long workflowTaskTemplateId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(workflowTaskTemplateId, "service_instances", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="WorkflowTaskTemplate"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template from which all service instances are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(WorkflowTaskTemplate workflowTaskTemplate, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await RemoveAllAsync(workflowTaskTemplate.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTask"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public sealed class WorkflowTasksClient
        {
            private readonly WorkflowTaskTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="WorkflowTasksClient"/> class.
            /// </summary>
            internal WorkflowTasksClient(WorkflowTaskTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified workflow task template using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to retrieve the workflow tasks.</param>
            /// <param name="query">The query that defines which workflow tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(long workflowTaskTemplateId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTask>(workflowTaskTemplateId, "tasks", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTask"/> records for the specified workflow task template using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to retrieve the workflow tasks.</param>
            /// <param name="query">The query that defines which workflow tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTask"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTask>> GetAsync(WorkflowTaskTemplate workflowTaskTemplate, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await GetAsync(workflowTaskTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified workflow task template using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to enumerate the workflow tasks.</param>
            /// <param name="query">The query that defines which workflow tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(long workflowTaskTemplateId, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTask>(workflowTaskTemplateId, "tasks", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTask"/> items as an asynchronous stream for the specified workflow task template using an <see cref="WorkflowTaskQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to enumerate the workflow tasks.</param>
            /// <param name="query">The query that defines which workflow tasks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTask"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTask> StreamAsync(WorkflowTaskTemplate workflowTaskTemplate, WorkflowTaskQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return StreamAsync(workflowTaskTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTemplate"/> records related to an <see cref="WorkflowTaskTemplate"/>.
        /// </summary>
        public sealed class WorkflowTemplatesClient
        {
            private readonly WorkflowTaskTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="WorkflowTemplatesClient"/> class.
            /// </summary>
            internal WorkflowTemplatesClient(WorkflowTaskTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTemplate"/> records for the specified workflow task template using an <see cref="WorkflowTemplateQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to retrieve the workflow templates.</param>
            /// <param name="query">The query that defines which workflow templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTemplate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTemplate>> GetAsync(long workflowTaskTemplateId, WorkflowTemplateQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTemplate>(workflowTaskTemplateId, "workflow_templates", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTemplate"/> records for the specified workflow task template using an <see cref="WorkflowTemplateQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to retrieve the workflow templates.</param>
            /// <param name="query">The query that defines which workflow templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTemplate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTemplate>> GetAsync(WorkflowTaskTemplate workflowTaskTemplate, WorkflowTemplateQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return await GetAsync(workflowTaskTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTemplate"/> items as an asynchronous stream for the specified workflow task template using an <see cref="WorkflowTemplateQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplateId">The unique identifier of the workflow task template for which to enumerate the workflow templates.</param>
            /// <param name="query">The query that defines which workflow templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTemplate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTemplate> StreamAsync(long workflowTaskTemplateId, WorkflowTemplateQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTemplate>(workflowTaskTemplateId, "workflow_templates", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTemplate"/> items as an asynchronous stream for the specified workflow task template using an <see cref="WorkflowTemplateQuery"/>.
            /// </summary>
            /// <param name="workflowTaskTemplate">The workflow task template for which to enumerate the workflow templates.</param>
            /// <param name="query">The query that defines which workflow templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTemplate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTemplate> StreamAsync(WorkflowTaskTemplate workflowTaskTemplate, WorkflowTemplateQuery query, CancellationToken ct = default)
            {
                if (workflowTaskTemplate is null)
                    throw new ArgumentNullException(nameof(workflowTaskTemplate));

                return StreamAsync(workflowTaskTemplate.Id, query, ct);
            }
        }
    }
}
