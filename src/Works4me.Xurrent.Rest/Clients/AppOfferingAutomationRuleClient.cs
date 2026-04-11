using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="AppOfferingAutomationRule"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/app_offering_automation_rules/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class AppOfferingAutomationRuleClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="AppOfferingAutomationRule"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppOfferingAutomationRuleClient"/> class.
        /// </summary>
        internal AppOfferingAutomationRuleClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "app_offering_automation_rules/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="AppOfferingAutomationRule"/> using the specified <see cref="AppOfferingAutomationRuleQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which app offering automation rules to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="AppOfferingAutomationRule"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<AppOfferingAutomationRule>> GetAsync(AppOfferingAutomationRuleQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<AppOfferingAutomationRule>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="AppOfferingAutomationRule"/> items as an asynchronous stream using the specified <see cref="AppOfferingAutomationRuleQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which app offering automation rules to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AppOfferingAutomationRule"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<AppOfferingAutomationRule> StreamAsync(AppOfferingAutomationRuleQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<AppOfferingAutomationRule>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="AppOfferingAutomationRule"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the app offering automation rule.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="AppOfferingAutomationRule"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<AppOfferingAutomationRule?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<AppOfferingAutomationRule>(new AppOfferingAutomationRuleQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="AppOfferingAutomationRule"/>.
        /// </summary>
        /// <param name="appOfferingAutomationRule">The app offering automation rule to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="AppOfferingAutomationRule"/>.</returns>
        public async Task<AppOfferingAutomationRule> CreateAsync(AppOfferingAutomationRule appOfferingAutomationRule, CancellationToken ct = default)
        {
            return await PostItemAsync(appOfferingAutomationRule, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="AppOfferingAutomationRule"/>.
        /// </summary>
        /// <param name="appOfferingAutomationRule">The app offering automation rule to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="AppOfferingAutomationRule"/>.</returns>
        public async Task<AppOfferingAutomationRule> UpdateAsync(AppOfferingAutomationRule appOfferingAutomationRule, CancellationToken ct = default)
        {
            return await PatchItemAsync(appOfferingAutomationRule, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an <see cref="AppOfferingAutomationRule"/>.
        /// </summary>
            /// <param name="appOfferingAutomationRuleId">The identifier of the app offering automation rule to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long appOfferingAutomationRuleId, CancellationToken ct = default)
            {
                return await DeleteItemAsync(appOfferingAutomationRuleId, ct).ConfigureAwait(false);
            }

        /// <summary>
        /// Delete an <see cref="AppOfferingAutomationRule"/>.
        /// </summary>
        /// <param name="appOfferingAutomationRule">The app offering automation rule to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="AppOfferingAutomationRule"/>.</returns>
        public async Task<bool> DeleteAsync(AppOfferingAutomationRule appOfferingAutomationRule, CancellationToken ct = default)
        {
            if (appOfferingAutomationRule is null)
                throw new ArgumentNullException(nameof(appOfferingAutomationRule));

            return await DeleteAsync(appOfferingAutomationRule.Id, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="AppOfferingAutomationRule"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly AppOfferingAutomationRuleClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(AppOfferingAutomationRuleClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified app offering automation rule using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appOfferingAutomationRuleId">The unique identifier of the app offering automation rule for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long appOfferingAutomationRuleId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(appOfferingAutomationRuleId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified app offering automation rule using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appOfferingAutomationRule">The app offering automation rule for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(AppOfferingAutomationRule appOfferingAutomationRule, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (appOfferingAutomationRule is null)
                    throw new ArgumentNullException(nameof(appOfferingAutomationRule));

                return await GetAsync(appOfferingAutomationRule.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified app offering automation rule using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appOfferingAutomationRuleId">The unique identifier of the app offering automation rule for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long appOfferingAutomationRuleId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(appOfferingAutomationRuleId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified app offering automation rule using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appOfferingAutomationRule">The app offering automation rule for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(AppOfferingAutomationRule appOfferingAutomationRule, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (appOfferingAutomationRule is null)
                    throw new ArgumentNullException(nameof(appOfferingAutomationRule));

                return StreamAsync(appOfferingAutomationRule.Id, query, ct);
            }
        }
    }
}
