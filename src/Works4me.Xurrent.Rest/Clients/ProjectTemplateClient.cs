using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ProjectTemplate"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/project_templates/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ProjectTemplateClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ProjectTemplate"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="ProjectTemplate"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ProjectTemplatePhase"/> records related to an <see cref="ProjectTemplate"/>.
        /// </summary>
        public PhasesClient Phases { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ProjectTaskTemplateRelation"/> records related to an <see cref="ProjectTemplate"/>.
        /// </summary>
        public TaskTemplatesClient TaskTemplates { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTemplateClient"/> class.
        /// </summary>
        internal ProjectTemplateClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "project_templates/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
            Phases = new PhasesClient(this);
            TaskTemplates = new TaskTemplatesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ProjectTemplate"/> using the specified <see cref="ProjectTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which project templates to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ProjectTemplate"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ProjectTemplate>> GetAsync(ProjectTemplateQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ProjectTemplate>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ProjectTemplate"/> items as an asynchronous stream using the specified <see cref="ProjectTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which project templates to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTemplate"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ProjectTemplate> StreamAsync(ProjectTemplateQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ProjectTemplate>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ProjectTemplate"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project template.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ProjectTemplate"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ProjectTemplate?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ProjectTemplate>(new ProjectTemplateQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ProjectTemplate"/>.
        /// </summary>
        /// <param name="projectTemplate">The project template to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ProjectTemplate"/>.</returns>
        public async Task<ProjectTemplate> CreateAsync(ProjectTemplate projectTemplate, CancellationToken ct = default)
        {
            return await PostItemAsync(projectTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ProjectTemplate"/>.
        /// </summary>
        /// <param name="projectTemplate">The project template to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ProjectTemplate"/>.</returns>
        public async Task<ProjectTemplate> UpdateAsync(ProjectTemplate projectTemplate, CancellationToken ct = default)
        {
            return await PatchItemAsync(projectTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ProjectTemplate"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ProjectTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ProjectTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectTemplateId">The unique identifier of the project template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long projectTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(projectTemplateId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified project template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ProjectTemplate projectTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await GetAsync(projectTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectTemplateId">The unique identifier of the project template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long projectTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(projectTemplateId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified project template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ProjectTemplate projectTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return StreamAsync(projectTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="ProjectTemplate"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly ProjectTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(ProjectTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified project template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="projectTemplateId">The unique identifier of the project template for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long projectTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(projectTemplateId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified project template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(ProjectTemplate projectTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await GetAsync(projectTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified project template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="projectTemplateId">The unique identifier of the project template for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long projectTemplateId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(projectTemplateId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified project template using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(ProjectTemplate projectTemplate, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return StreamAsync(projectTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ProjectTemplatePhase"/> records related to an <see cref="ProjectTemplate"/>.
        /// </summary>
        public sealed class PhasesClient
        {
            private readonly ProjectTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PhasesClient"/> class.
            /// </summary>
            internal PhasesClient(ProjectTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTemplatePhase"/> records for the specified project template using an <see cref="ProjectTemplatePhaseQuery"/>.
            /// </summary>
            /// <param name="projectTemplateId">The unique identifier of the project template for which to retrieve the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTemplatePhase"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTemplatePhase>> GetAsync(long projectTemplateId, ProjectTemplatePhaseQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ProjectTemplatePhase>(projectTemplateId, "phases", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTemplatePhase"/> records for the specified project template using an <see cref="ProjectTemplatePhaseQuery"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template for which to retrieve the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTemplatePhase"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTemplatePhase>> GetAsync(ProjectTemplate projectTemplate, ProjectTemplatePhaseQuery query, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await GetAsync(projectTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTemplatePhase"/> items as an asynchronous stream for the specified project template using an <see cref="ProjectTemplatePhaseQuery"/>.
            /// </summary>
            /// <param name="projectTemplateId">The unique identifier of the project template for which to enumerate the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTemplatePhase"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTemplatePhase> StreamAsync(long projectTemplateId, ProjectTemplatePhaseQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ProjectTemplatePhase>(projectTemplateId, "phases", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTemplatePhase"/> items as an asynchronous stream for the specified project template using an <see cref="ProjectTemplatePhaseQuery"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template for which to enumerate the phases.</param>
            /// <param name="query">The query that defines which phases to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTemplatePhase"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTemplatePhase> StreamAsync(ProjectTemplate projectTemplate, ProjectTemplatePhaseQuery query, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return StreamAsync(projectTemplate.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="ProjectTemplatePhase"/> by its unique identifier for the specified project template.
            /// </summary>
            /// <param name="projectTemplateId">The unique identifier of the project template.</param>
            /// <param name="projectTemplatePhaseId">The unique identifier of the project template phase.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="ProjectTemplatePhase"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<ProjectTemplatePhase?> GetAsync(long projectTemplateId, long projectTemplatePhaseId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<ProjectTemplatePhase>(projectTemplateId, "phases", new ProjectTemplatePhaseQuery().WithId(projectTemplatePhaseId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="ProjectTemplatePhase"/> record for the specified project template.
            /// </summary>
            /// <param name="projectTemplate">The project template for which to retrieve the project template phase.</param>
            /// <param name="projectTemplatePhaseId">The unique identifier of the project template phase.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="ProjectTemplatePhase"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<ProjectTemplatePhase?> GetAsync(ProjectTemplate projectTemplate, long projectTemplatePhaseId, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await GetAsync(projectTemplate.Id, projectTemplatePhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="ProjectTemplatePhase"/> to a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="projectTemplatePhase">The project template phase to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectTemplatePhase"/>.</returns>
            public async Task<ProjectTemplatePhase> CreateAsync(long projectTemplateId, ProjectTemplatePhase projectTemplatePhase, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectTemplateId, "phases", projectTemplatePhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="ProjectTemplatePhase"/> to a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template to which the project template phase is added.</param>
            /// <param name="projectTemplatePhase">The project template phase to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectTemplatePhase"/>.</returns>
            public async Task<ProjectTemplatePhase> CreateAsync(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await CreateAsync(projectTemplate.Id, projectTemplatePhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="ProjectTemplatePhase"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="projectTemplatePhase">The project template phase to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectTemplatePhase"/>.</returns>
            public async Task<ProjectTemplatePhase> UpdateAsync(long projectTemplateId, ProjectTemplatePhase projectTemplatePhase, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(projectTemplateId, "phases", projectTemplatePhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="ProjectTemplatePhase"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template with which the project template phase is associated.</param>
            /// <param name="projectTemplatePhase">The project template phase to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="ProjectTemplatePhase"/>.</returns>
            public async Task<ProjectTemplatePhase> UpdateAsync(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await UpdateAsync(projectTemplate.Id, projectTemplatePhase, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectTemplatePhase"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="projectTemplatePhaseId">The identifier of the project template phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long projectTemplateId, long projectTemplatePhaseId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(projectTemplateId, "phases", projectTemplatePhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectTemplatePhase"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="projectTemplatePhase">The project template phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long projectTemplateId, ProjectTemplatePhase projectTemplatePhase, CancellationToken ct = default)
            {
                if (projectTemplatePhase is null)
                    throw new ArgumentNullException(nameof(projectTemplatePhase));

                return await DeleteAsync(projectTemplateId, projectTemplatePhase.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectTemplatePhase"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template from which the project template phase is removed.</param>
            /// <param name="projectTemplatePhase">The project template phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ProjectTemplate projectTemplate, ProjectTemplatePhase projectTemplatePhase, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                if (projectTemplatePhase is null)
                    throw new ArgumentNullException(nameof(projectTemplatePhase));

                return await DeleteAsync(projectTemplate.Id, projectTemplatePhase.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="ProjectTemplatePhase"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template from which the project template phase is removed.</param>
            /// <param name="projectTemplatePhaseId">The identifier of the project template phase to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ProjectTemplate projectTemplate, long projectTemplatePhaseId, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await DeleteAsync(projectTemplate.Id, projectTemplatePhaseId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all phases associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long projectTemplateId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectTemplateId, "phases", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all phases associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template from which all phases are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(ProjectTemplate projectTemplate, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await DeleteAllAsync(projectTemplate.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ProjectTaskTemplateRelation"/> records related to an <see cref="ProjectTemplate"/>.
        /// </summary>
        public sealed class TaskTemplatesClient
        {
            private readonly ProjectTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TaskTemplatesClient"/> class.
            /// </summary>
            internal TaskTemplatesClient(ProjectTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTaskTemplateRelation"/> records for the specified project template using an <see cref="ProjectTaskTemplateRelationQuery"/>.
            /// </summary>
            /// <param name="projectTemplateId">The unique identifier of the project template for which to retrieve the task templates.</param>
            /// <param name="query">The query that defines which task templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTaskTemplateRelation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTaskTemplateRelation>> GetAsync(long projectTemplateId, ProjectTaskTemplateRelationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ProjectTaskTemplateRelation>(projectTemplateId, "task_templates", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ProjectTaskTemplateRelation"/> records for the specified project template using an <see cref="ProjectTaskTemplateRelationQuery"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template for which to retrieve the task templates.</param>
            /// <param name="query">The query that defines which task templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ProjectTaskTemplateRelation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ProjectTaskTemplateRelation>> GetAsync(ProjectTemplate projectTemplate, ProjectTaskTemplateRelationQuery query, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await GetAsync(projectTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTaskTemplateRelation"/> items as an asynchronous stream for the specified project template using an <see cref="ProjectTaskTemplateRelationQuery"/>.
            /// </summary>
            /// <param name="projectTemplateId">The unique identifier of the project template for which to enumerate the task templates.</param>
            /// <param name="query">The query that defines which task templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTaskTemplateRelation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTaskTemplateRelation> StreamAsync(long projectTemplateId, ProjectTaskTemplateRelationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ProjectTaskTemplateRelation>(projectTemplateId, "task_templates", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ProjectTaskTemplateRelation"/> items as an asynchronous stream for the specified project template using an <see cref="ProjectTaskTemplateRelationQuery"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template for which to enumerate the task templates.</param>
            /// <param name="query">The query that defines which task templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ProjectTaskTemplateRelation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ProjectTaskTemplateRelation> StreamAsync(ProjectTemplate projectTemplate, ProjectTaskTemplateRelationQuery query, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return StreamAsync(projectTemplate.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ProjectTaskTemplateRelation"/> to a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="projectTaskTemplateRelationId">The identifier of the project task template relation to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectTemplateId, long projectTaskTemplateRelationId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(projectTemplateId, "task_templates", projectTaskTemplateRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ProjectTaskTemplateRelation"/> to a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="projectTaskTemplateRelation">The project task template relation to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long projectTemplateId, ProjectTaskTemplateRelation projectTaskTemplateRelation, CancellationToken ct = default)
            {
                if (projectTaskTemplateRelation is null)
                    throw new ArgumentNullException(nameof(projectTaskTemplateRelation));

                return await AddAsync(projectTemplateId, projectTaskTemplateRelation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ProjectTaskTemplateRelation"/> to a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template from which the project task template relation is removed.</param>
            /// <param name="projectTaskTemplateRelation">The project task template relation to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ProjectTemplate projectTemplate, ProjectTaskTemplateRelation projectTaskTemplateRelation, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                if (projectTaskTemplateRelation is null)
                    throw new ArgumentNullException(nameof(projectTaskTemplateRelation));

                return await AddAsync(projectTemplate.Id, projectTaskTemplateRelation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ProjectTaskTemplateRelation"/> to a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template from which the project task template relation is removed.</param>
            /// <param name="projectTaskTemplateRelationId">The identifier of the project task template relation to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ProjectTemplate projectTemplate, long projectTaskTemplateRelationId, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await AddAsync(projectTemplate.Id, projectTaskTemplateRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTaskTemplateRelation"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="projectTaskTemplateRelationId">The identifier of the project task template relation to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectTemplateId, long projectTaskTemplateRelationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(projectTemplateId, "task_templates", projectTaskTemplateRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTaskTemplateRelation"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="projectTaskTemplateRelation">The project task template relation to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long projectTemplateId, ProjectTaskTemplateRelation projectTaskTemplateRelation, CancellationToken ct = default)
            {
                if (projectTaskTemplateRelation is null)
                    throw new ArgumentNullException(nameof(projectTaskTemplateRelation));

                return await RemoveAsync(projectTemplateId, projectTaskTemplateRelation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTaskTemplateRelation"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template from which the project task template relation is removed.</param>
            /// <param name="projectTaskTemplateRelation">The project task template relation to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ProjectTemplate projectTemplate, ProjectTaskTemplateRelation projectTaskTemplateRelation, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                if (projectTaskTemplateRelation is null)
                    throw new ArgumentNullException(nameof(projectTaskTemplateRelation));

                return await RemoveAsync(projectTemplate.Id, projectTaskTemplateRelation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ProjectTaskTemplateRelation"/> associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template from which the project task template relation is removed.</param>
            /// <param name="projectTaskTemplateRelationId">The identifier of the project task template relation to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ProjectTemplate projectTemplate, long projectTaskTemplateRelationId, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await RemoveAsync(projectTemplate.Id, projectTaskTemplateRelationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all task templates associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplateId">The identifier of the project template.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long projectTemplateId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(projectTemplateId, "task_templates", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all task templates associated with a <see cref="ProjectTemplate"/>.
            /// </summary>
            /// <param name="projectTemplate">The project template from which all task templates are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ProjectTemplate projectTemplate, CancellationToken ct = default)
            {
                if (projectTemplate is null)
                    throw new ArgumentNullException(nameof(projectTemplate));

                return await RemoveAllAsync(projectTemplate.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
