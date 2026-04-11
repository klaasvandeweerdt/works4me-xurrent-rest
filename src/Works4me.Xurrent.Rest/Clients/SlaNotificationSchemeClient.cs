using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="SlaNotificationScheme"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/sla_notification_schemes/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class SlaNotificationSchemeClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="SlaNotificationScheme"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SlaNotificationRule"/> records related to an <see cref="SlaNotificationScheme"/>.
        /// </summary>
        public NotificationRulesClient NotificationRules { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SlaNotificationSchemeClient"/> class.
        /// </summary>
        internal SlaNotificationSchemeClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "sla_notification_schemes/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            NotificationRules = new NotificationRulesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="SlaNotificationScheme"/> using the specified <see cref="SlaNotificationSchemeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service level agreement notification schemes to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="SlaNotificationScheme"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<SlaNotificationScheme>> GetAsync(SlaNotificationSchemeQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<SlaNotificationScheme>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="SlaNotificationScheme"/> items as an asynchronous stream using the specified <see cref="SlaNotificationSchemeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service level agreement notification schemes to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SlaNotificationScheme"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<SlaNotificationScheme> StreamAsync(SlaNotificationSchemeQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<SlaNotificationScheme>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="SlaNotificationScheme"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service level agreement notification scheme.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="SlaNotificationScheme"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<SlaNotificationScheme?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<SlaNotificationScheme>(new SlaNotificationSchemeQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="SlaNotificationScheme"/>.
        /// </summary>
        /// <param name="slaNotificationScheme">The service level agreement notification scheme to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="SlaNotificationScheme"/>.</returns>
        public async Task<SlaNotificationScheme> CreateAsync(SlaNotificationScheme slaNotificationScheme, CancellationToken ct = default)
        {
            return await PostItemAsync(slaNotificationScheme, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="SlaNotificationScheme"/>.
        /// </summary>
        /// <param name="slaNotificationScheme">The service level agreement notification scheme to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="SlaNotificationScheme"/>.</returns>
        public async Task<SlaNotificationScheme> UpdateAsync(SlaNotificationScheme slaNotificationScheme, CancellationToken ct = default)
        {
            return await PatchItemAsync(slaNotificationScheme, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="SlaNotificationScheme"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly SlaNotificationSchemeClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(SlaNotificationSchemeClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service level agreement notification scheme using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The unique identifier of the service level agreement notification scheme for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long slaNotificationSchemeId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(slaNotificationSchemeId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service level agreement notification scheme using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(SlaNotificationScheme slaNotificationScheme, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                return await GetAsync(slaNotificationScheme.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service level agreement notification scheme using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The unique identifier of the service level agreement notification scheme for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long slaNotificationSchemeId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(slaNotificationSchemeId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service level agreement notification scheme using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(SlaNotificationScheme slaNotificationScheme, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                return StreamAsync(slaNotificationScheme.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SlaNotificationRule"/> records related to an <see cref="SlaNotificationScheme"/>.
        /// </summary>
        public sealed class NotificationRulesClient
        {
            private readonly SlaNotificationSchemeClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotificationRulesClient"/> class.
            /// </summary>
            internal NotificationRulesClient(SlaNotificationSchemeClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SlaNotificationRule"/> records for the specified service level agreement notification scheme using an <see cref="SlaNotificationRuleQuery"/>.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The unique identifier of the service level agreement notification scheme for which to retrieve the notification rules.</param>
            /// <param name="query">The query that defines which notification rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SlaNotificationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SlaNotificationRule>> GetAsync(long slaNotificationSchemeId, SlaNotificationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SlaNotificationRule>(slaNotificationSchemeId, "sla_notification_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SlaNotificationRule"/> records for the specified service level agreement notification scheme using an <see cref="SlaNotificationRuleQuery"/>.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme for which to retrieve the notification rules.</param>
            /// <param name="query">The query that defines which notification rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SlaNotificationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SlaNotificationRule>> GetAsync(SlaNotificationScheme slaNotificationScheme, SlaNotificationRuleQuery query, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                return await GetAsync(slaNotificationScheme.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SlaNotificationRule"/> items as an asynchronous stream for the specified service level agreement notification scheme using an <see cref="SlaNotificationRuleQuery"/>.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The unique identifier of the service level agreement notification scheme for which to enumerate the notification rules.</param>
            /// <param name="query">The query that defines which notification rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SlaNotificationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SlaNotificationRule> StreamAsync(long slaNotificationSchemeId, SlaNotificationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SlaNotificationRule>(slaNotificationSchemeId, "sla_notification_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SlaNotificationRule"/> items as an asynchronous stream for the specified service level agreement notification scheme using an <see cref="SlaNotificationRuleQuery"/>.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme for which to enumerate the notification rules.</param>
            /// <param name="query">The query that defines which notification rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SlaNotificationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SlaNotificationRule> StreamAsync(SlaNotificationScheme slaNotificationScheme, SlaNotificationRuleQuery query, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                return StreamAsync(slaNotificationScheme.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="SlaNotificationRule"/> by its unique identifier for the specified service level agreement notification scheme.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The unique identifier of the service level agreement notification scheme.</param>
            /// <param name="slaNotificationRuleId">The unique identifier of the service level agreement notification rule.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="SlaNotificationRule"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<SlaNotificationRule?> GetAsync(long slaNotificationSchemeId, long slaNotificationRuleId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<SlaNotificationRule>(slaNotificationSchemeId, "sla_notification_rules", new SlaNotificationRuleQuery().WithId(slaNotificationRuleId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="SlaNotificationRule"/> record for the specified service level agreement notification scheme.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme for which to retrieve the service level agreement notification rule.</param>
            /// <param name="slaNotificationRuleId">The unique identifier of the service level agreement notification rule.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="SlaNotificationRule"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<SlaNotificationRule?> GetAsync(SlaNotificationScheme slaNotificationScheme, long slaNotificationRuleId, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                return await GetAsync(slaNotificationScheme.Id, slaNotificationRuleId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="SlaNotificationRule"/> to a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The identifier of the service level agreement notification scheme.</param>
            /// <param name="slaNotificationRule">The service level agreement notification rule to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SlaNotificationRule"/>.</returns>
            public async Task<SlaNotificationRule> CreateAsync(long slaNotificationSchemeId, SlaNotificationRule slaNotificationRule, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(slaNotificationSchemeId, "sla_notification_rules", slaNotificationRule, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="SlaNotificationRule"/> to a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme to which the service level agreement notification rule is added.</param>
            /// <param name="slaNotificationRule">The service level agreement notification rule to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SlaNotificationRule"/>.</returns>
            public async Task<SlaNotificationRule> CreateAsync(SlaNotificationScheme slaNotificationScheme, SlaNotificationRule slaNotificationRule, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                return await CreateAsync(slaNotificationScheme.Id, slaNotificationRule, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="SlaNotificationRule"/> associated with a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The identifier of the service level agreement notification scheme.</param>
            /// <param name="slaNotificationRule">The service level agreement notification rule to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SlaNotificationRule"/>.</returns>
            public async Task<SlaNotificationRule> UpdateAsync(long slaNotificationSchemeId, SlaNotificationRule slaNotificationRule, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(slaNotificationSchemeId, "sla_notification_rules", slaNotificationRule, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="SlaNotificationRule"/> associated with a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme with which the service level agreement notification rule is associated.</param>
            /// <param name="slaNotificationRule">The service level agreement notification rule to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="SlaNotificationRule"/>.</returns>
            public async Task<SlaNotificationRule> UpdateAsync(SlaNotificationScheme slaNotificationScheme, SlaNotificationRule slaNotificationRule, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                return await UpdateAsync(slaNotificationScheme.Id, slaNotificationRule, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SlaNotificationRule"/> associated with a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The identifier of the service level agreement notification scheme.</param>
            /// <param name="slaNotificationRuleId">The identifier of the service level agreement notification rule to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long slaNotificationSchemeId, long slaNotificationRuleId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(slaNotificationSchemeId, "sla_notification_rules", slaNotificationRuleId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SlaNotificationRule"/> associated with a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The identifier of the service level agreement notification scheme.</param>
            /// <param name="slaNotificationRule">The service level agreement notification rule to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long slaNotificationSchemeId, SlaNotificationRule slaNotificationRule, CancellationToken ct = default)
            {
                if (slaNotificationRule is null)
                    throw new ArgumentNullException(nameof(slaNotificationRule));

                return await DeleteAsync(slaNotificationSchemeId, slaNotificationRule.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SlaNotificationRule"/> associated with a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme from which the service level agreement notification rule is removed.</param>
            /// <param name="slaNotificationRule">The service level agreement notification rule to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(SlaNotificationScheme slaNotificationScheme, SlaNotificationRule slaNotificationRule, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                if (slaNotificationRule is null)
                    throw new ArgumentNullException(nameof(slaNotificationRule));

                return await DeleteAsync(slaNotificationScheme.Id, slaNotificationRule.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="SlaNotificationRule"/> associated with a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme from which the service level agreement notification rule is removed.</param>
            /// <param name="slaNotificationRuleId">The identifier of the service level agreement notification rule to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(SlaNotificationScheme slaNotificationScheme, long slaNotificationRuleId, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                return await DeleteAsync(slaNotificationScheme.Id, slaNotificationRuleId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all service level agreement notification rules associated with a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationSchemeId">The identifier of the service level agreement notification scheme.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long slaNotificationSchemeId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(slaNotificationSchemeId, "sla_notification_rules", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all service level agreement notification rules associated with a <see cref="SlaNotificationScheme"/>.
            /// </summary>
            /// <param name="slaNotificationScheme">The service level agreement notification scheme from which all service level agreement notification rules are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(SlaNotificationScheme slaNotificationScheme, CancellationToken ct = default)
            {
                if (slaNotificationScheme is null)
                    throw new ArgumentNullException(nameof(slaNotificationScheme));

                return await DeleteAllAsync(slaNotificationScheme.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
