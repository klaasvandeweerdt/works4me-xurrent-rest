using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="AppOffering"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/app_offerings/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class AppOfferingClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AppInstance"/> records related to an <see cref="AppOffering"/>.
        /// </summary>
        public AppInstancesClient AppInstances { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="AppOffering"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AppOfferingAutomationRule"/> records related to an <see cref="AppOffering"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AppOfferingScope"/> records related to an <see cref="AppOffering"/>.
        /// </summary>
        public ScopesClient Scopes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppOfferingClient"/> class.
        /// </summary>
        internal AppOfferingClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "app_offerings/"))
        {
            AppInstances = new AppInstancesClient(this);
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
            Scopes = new ScopesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="AppOffering"/> using the specified <see cref="AppOfferingQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which app offerings to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="AppOffering"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<AppOffering>> GetAsync(AppOfferingQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<AppOffering>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="AppOffering"/> items as an asynchronous stream using the specified <see cref="AppOfferingQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which app offerings to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AppOffering"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<AppOffering> StreamAsync(AppOfferingQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<AppOffering>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="AppOffering"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the app offering.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="AppOffering"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<AppOffering?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<AppOffering>(new AppOfferingQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="AppOffering"/>.
        /// </summary>
        /// <param name="appOffering">The app offering to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="AppOffering"/>.</returns>
        public async Task<AppOffering> CreateAsync(AppOffering appOffering, CancellationToken ct = default)
        {
            return await PostItemAsync(appOffering, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="AppOffering"/>.
        /// </summary>
        /// <param name="appOffering">The app offering to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="AppOffering"/>.</returns>
        public async Task<AppOffering> UpdateAsync(AppOffering appOffering, CancellationToken ct = default)
        {
            return await PatchItemAsync(appOffering, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AppInstance"/> records related to an <see cref="AppOffering"/>.
        /// </summary>
        public sealed class AppInstancesClient
        {
            private readonly AppOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AppInstancesClient"/> class.
            /// </summary>
            internal AppInstancesClient(AppOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AppInstance"/> records for the specified app offering using an <see cref="AppInstanceQuery"/>.
            /// </summary>
            /// <param name="appOfferingId">The unique identifier of the app offering for which to retrieve the app instances.</param>
            /// <param name="query">The query that defines which app instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AppInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AppInstance>> GetAsync(long appOfferingId, AppInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AppInstance>(appOfferingId, "app_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AppInstance"/> records for the specified app offering using an <see cref="AppInstanceQuery"/>.
            /// </summary>
            /// <param name="appOffering">The app offering for which to retrieve the app instances.</param>
            /// <param name="query">The query that defines which app instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AppInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AppInstance>> GetAsync(AppOffering appOffering, AppInstanceQuery query, CancellationToken ct = default)
            {
                if (appOffering is null)
                    throw new ArgumentNullException(nameof(appOffering));

                return await GetAsync(appOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AppInstance"/> items as an asynchronous stream for the specified app offering using an <see cref="AppInstanceQuery"/>.
            /// </summary>
            /// <param name="appOfferingId">The unique identifier of the app offering for which to enumerate the app instances.</param>
            /// <param name="query">The query that defines which app instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AppInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AppInstance> StreamAsync(long appOfferingId, AppInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AppInstance>(appOfferingId, "app_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AppInstance"/> items as an asynchronous stream for the specified app offering using an <see cref="AppInstanceQuery"/>.
            /// </summary>
            /// <param name="appOffering">The app offering for which to enumerate the app instances.</param>
            /// <param name="query">The query that defines which app instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AppInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AppInstance> StreamAsync(AppOffering appOffering, AppInstanceQuery query, CancellationToken ct = default)
            {
                if (appOffering is null)
                    throw new ArgumentNullException(nameof(appOffering));

                return StreamAsync(appOffering.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="AppOffering"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly AppOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(AppOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified app offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appOfferingId">The unique identifier of the app offering for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long appOfferingId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(appOfferingId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified app offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appOffering">The app offering for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(AppOffering appOffering, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (appOffering is null)
                    throw new ArgumentNullException(nameof(appOffering));

                return await GetAsync(appOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified app offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appOfferingId">The unique identifier of the app offering for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long appOfferingId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(appOfferingId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified app offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="appOffering">The app offering for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(AppOffering appOffering, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (appOffering is null)
                    throw new ArgumentNullException(nameof(appOffering));

                return StreamAsync(appOffering.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AppOfferingAutomationRule"/> records related to an <see cref="AppOffering"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly AppOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(AppOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AppOfferingAutomationRule"/> records for the specified app offering using an <see cref="AppOfferingAutomationRuleQuery"/>.
            /// </summary>
            /// <param name="appOfferingId">The unique identifier of the app offering for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AppOfferingAutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AppOfferingAutomationRule>> GetAsync(long appOfferingId, AppOfferingAutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AppOfferingAutomationRule>(appOfferingId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AppOfferingAutomationRule"/> records for the specified app offering using an <see cref="AppOfferingAutomationRuleQuery"/>.
            /// </summary>
            /// <param name="appOffering">The app offering for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AppOfferingAutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AppOfferingAutomationRule>> GetAsync(AppOffering appOffering, AppOfferingAutomationRuleQuery query, CancellationToken ct = default)
            {
                if (appOffering is null)
                    throw new ArgumentNullException(nameof(appOffering));

                return await GetAsync(appOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AppOfferingAutomationRule"/> items as an asynchronous stream for the specified app offering using an <see cref="AppOfferingAutomationRuleQuery"/>.
            /// </summary>
            /// <param name="appOfferingId">The unique identifier of the app offering for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AppOfferingAutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AppOfferingAutomationRule> StreamAsync(long appOfferingId, AppOfferingAutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AppOfferingAutomationRule>(appOfferingId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AppOfferingAutomationRule"/> items as an asynchronous stream for the specified app offering using an <see cref="AppOfferingAutomationRuleQuery"/>.
            /// </summary>
            /// <param name="appOffering">The app offering for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AppOfferingAutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AppOfferingAutomationRule> StreamAsync(AppOffering appOffering, AppOfferingAutomationRuleQuery query, CancellationToken ct = default)
            {
                if (appOffering is null)
                    throw new ArgumentNullException(nameof(appOffering));

                return StreamAsync(appOffering.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AppOfferingScope"/> records related to an <see cref="AppOffering"/>.
        /// </summary>
        public sealed class ScopesClient
        {
            private readonly AppOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ScopesClient"/> class.
            /// </summary>
            internal ScopesClient(AppOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AppOfferingScope"/> records for the specified app offering using an <see cref="AppOfferingScopeQuery"/>.
            /// </summary>
            /// <param name="appOfferingId">The unique identifier of the app offering for which to retrieve the scopes.</param>
            /// <param name="query">The query that defines which scopes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AppOfferingScope"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AppOfferingScope>> GetAsync(long appOfferingId, AppOfferingScopeQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AppOfferingScope>(appOfferingId, "scopes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AppOfferingScope"/> records for the specified app offering using an <see cref="AppOfferingScopeQuery"/>.
            /// </summary>
            /// <param name="appOffering">The app offering for which to retrieve the scopes.</param>
            /// <param name="query">The query that defines which scopes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AppOfferingScope"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AppOfferingScope>> GetAsync(AppOffering appOffering, AppOfferingScopeQuery query, CancellationToken ct = default)
            {
                if (appOffering is null)
                    throw new ArgumentNullException(nameof(appOffering));

                return await GetAsync(appOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AppOfferingScope"/> items as an asynchronous stream for the specified app offering using an <see cref="AppOfferingScopeQuery"/>.
            /// </summary>
            /// <param name="appOfferingId">The unique identifier of the app offering for which to enumerate the scopes.</param>
            /// <param name="query">The query that defines which scopes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AppOfferingScope"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AppOfferingScope> StreamAsync(long appOfferingId, AppOfferingScopeQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AppOfferingScope>(appOfferingId, "scopes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AppOfferingScope"/> items as an asynchronous stream for the specified app offering using an <see cref="AppOfferingScopeQuery"/>.
            /// </summary>
            /// <param name="appOffering">The app offering for which to enumerate the scopes.</param>
            /// <param name="query">The query that defines which scopes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AppOfferingScope"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AppOfferingScope> StreamAsync(AppOffering appOffering, AppOfferingScopeQuery query, CancellationToken ct = default)
            {
                if (appOffering is null)
                    throw new ArgumentNullException(nameof(appOffering));

                return StreamAsync(appOffering.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="AppOfferingScope"/> by its unique identifier for the specified app offering.
            /// </summary>
            /// <param name="appOfferingId">The unique identifier of the app offering.</param>
            /// <param name="appOfferingScopeId">The unique identifier of the app offering scope.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="AppOfferingScope"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<AppOfferingScope?> GetAsync(long appOfferingId, long appOfferingScopeId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<AppOfferingScope>(appOfferingId, "scopes", new AppOfferingScopeQuery().WithId(appOfferingScopeId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="AppOfferingScope"/> record for the specified app offering.
            /// </summary>
            /// <param name="appOffering">The app offering for which to retrieve the app offering scope.</param>
            /// <param name="appOfferingScopeId">The unique identifier of the app offering scope.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="AppOfferingScope"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<AppOfferingScope?> GetAsync(AppOffering appOffering, long appOfferingScopeId, CancellationToken ct = default)
            {
                if (appOffering is null)
                    throw new ArgumentNullException(nameof(appOffering));

                return await GetAsync(appOffering.Id, appOfferingScopeId, ct).ConfigureAwait(false);
            }
        }
    }
}
