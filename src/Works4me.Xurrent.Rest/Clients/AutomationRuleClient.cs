using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="AutomationRule"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/automation_rules/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class AutomationRuleClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="AutomationRule"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomationRuleClient"/> class.
        /// </summary>
        internal AutomationRuleClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "automation_rules/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="AutomationRule"/> using the specified <see cref="AutomationRuleQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which automation rules to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(AutomationRuleQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<AutomationRule>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream using the specified <see cref="AutomationRuleQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which automation rules to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<AutomationRule> StreamAsync(AutomationRuleQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<AutomationRule>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="AutomationRule"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the automation rule.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="AutomationRule"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<AutomationRule?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<AutomationRule>(new AutomationRuleQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="AutomationRule"/>.
        /// </summary>
        /// <param name="automationRule">The automation rule to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="AutomationRule"/>.</returns>
        public async Task<AutomationRule> CreateAsync(AutomationRule automationRule, CancellationToken ct = default)
        {
            return await PostItemAsync(automationRule, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="AutomationRule"/>.
        /// </summary>
        /// <param name="automationRule">The automation rule to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="AutomationRule"/>.</returns>
        public async Task<AutomationRule> UpdateAsync(AutomationRule automationRule, CancellationToken ct = default)
        {
            return await PatchItemAsync(automationRule, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an <see cref="AutomationRule"/>.
        /// </summary>
            /// <param name="automationRuleId">The identifier of the automation rule to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long automationRuleId, CancellationToken ct = default)
            {
                return await DeleteItemAsync(automationRuleId, ct).ConfigureAwait(false);
            }

        /// <summary>
        /// Delete an <see cref="AutomationRule"/>.
        /// </summary>
        /// <param name="automationRule">The automation rule to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="AutomationRule"/>.</returns>
        public async Task<bool> DeleteAsync(AutomationRule automationRule, CancellationToken ct = default)
        {
            if (automationRule is null)
                throw new ArgumentNullException(nameof(automationRule));

            return await DeleteAsync(automationRule.Id, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="AutomationRule"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly AutomationRuleClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(AutomationRuleClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified automation rule using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="automationRuleId">The unique identifier of the automation rule for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long automationRuleId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(automationRuleId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified automation rule using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="automationRule">The automation rule for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(AutomationRule automationRule, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (automationRule is null)
                    throw new ArgumentNullException(nameof(automationRule));

                return await GetAsync(automationRule.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified automation rule using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="automationRuleId">The unique identifier of the automation rule for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long automationRuleId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(automationRuleId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified automation rule using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="automationRule">The automation rule for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(AutomationRule automationRule, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (automationRule is null)
                    throw new ArgumentNullException(nameof(automationRule));

                return StreamAsync(automationRule.Id, query, ct);
            }
        }
    }
}
