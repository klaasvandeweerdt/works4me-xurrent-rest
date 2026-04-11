using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="AppInstance"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/app_instances/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class AppInstanceClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="AppInstance"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="AppInstance"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppInstanceClient"/> class.
        /// </summary>
        internal AppInstanceClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "app_instances/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="AppInstance"/> using the specified <see cref="AppInstanceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which app instances to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="AppInstance"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<AppInstance>> GetAsync(AppInstanceQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<AppInstance>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="AppInstance"/> items as an asynchronous stream using the specified <see cref="AppInstanceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which app instances to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AppInstance"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<AppInstance> StreamAsync(AppInstanceQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<AppInstance>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="AppInstance"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the app instance.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="AppInstance"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<AppInstance?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<AppInstance>(new AppInstanceQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="AppInstance"/>.
        /// </summary>
        /// <param name="appInstance">The app instance to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="AppInstance"/>.</returns>
        public async Task<AppInstance> CreateAsync(AppInstance appInstance, CancellationToken ct = default)
        {
            return await PostItemAsync(appInstance, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="AppInstance"/>.
        /// </summary>
        /// <param name="appInstance">The app instance to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="AppInstance"/>.</returns>
        public async Task<AppInstance> UpdateAsync(AppInstance appInstance, CancellationToken ct = default)
        {
            return await PatchItemAsync(appInstance, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="AppInstance"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly AppInstanceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(AppInstanceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified app instance using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appInstanceId">The unique identifier of the app instance for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long appInstanceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(appInstanceId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified app instance using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appInstance">The app instance for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(AppInstance appInstance, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (appInstance is null)
                    throw new ArgumentNullException(nameof(appInstance));

                return await GetAsync(appInstance.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified app instance using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appInstanceId">The unique identifier of the app instance for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long appInstanceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(appInstanceId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified app instance using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appInstance">The app instance for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(AppInstance appInstance, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (appInstance is null)
                    throw new ArgumentNullException(nameof(appInstance));

                return StreamAsync(appInstance.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="AppInstance"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly AppInstanceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(AppInstanceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified app instance using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="appInstanceId">The unique identifier of the app instance for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long appInstanceId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(appInstanceId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified app instance using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="appInstance">The app instance for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(AppInstance appInstance, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (appInstance is null)
                    throw new ArgumentNullException(nameof(appInstance));

                return await GetAsync(appInstance.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified app instance using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="appInstanceId">The unique identifier of the app instance for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long appInstanceId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(appInstanceId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified app instance using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="appInstance">The app instance for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(AppInstance appInstance, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (appInstance is null)
                    throw new ArgumentNullException(nameof(appInstance));

                return StreamAsync(appInstance.Id, query, ct);
            }
        }
    }
}
