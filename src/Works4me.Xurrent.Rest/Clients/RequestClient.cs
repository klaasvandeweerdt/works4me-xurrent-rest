using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Request"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/requests/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class RequestClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AffectedSla"/> records related to an <see cref="Request"/>.
        /// </summary>
        public AffectedServiceLevelAgreementsClient AffectedServiceLevelAgreements { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Request"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AutomationRule"/> records related to an <see cref="Request"/>.
        /// </summary>
        public AutomationRulesClient AutomationRules { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Request"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Request"/> records related to an <see cref="Request"/>.
        /// </summary>
        public GroupedRequestsClient GroupedRequests { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="InboundEmail"/> records related to an <see cref="Request"/>.
        /// </summary>
        public InboundEmailsClient InboundEmails { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="KnowledgeArticle"/> records related to an <see cref="Request"/>.
        /// </summary>
        public KnowledgeArticlesClient KnowledgeArticles { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Note"/> records related to an <see cref="Request"/>.
        /// </summary>
        public NotesClient Notes { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Attachment"/> records related to an <see cref="Request"/>.
        /// </summary>
        public NotesAttachmentsClient NotesAttachments { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="Request"/>.
        /// </summary>
        public SprintBacklogItemsClient SprintBacklogItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Tag"/> records related to an <see cref="Request"/>.
        /// </summary>
        public TagsClient Tags { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Watch"/> records related to an <see cref="Request"/>.
        /// </summary>
        public WatchesClient Watches { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestClient"/> class.
        /// </summary>
        internal RequestClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "requests/"))
        {
            AffectedServiceLevelAgreements = new AffectedServiceLevelAgreementsClient(this);
            AuditEntries = new AuditEntriesClient(this);
            AutomationRules = new AutomationRulesClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
            GroupedRequests = new GroupedRequestsClient(this);
            InboundEmails = new InboundEmailsClient(this);
            KnowledgeArticles = new KnowledgeArticlesClient(this);
            Notes = new NotesClient(this);
            NotesAttachments = new NotesAttachmentsClient(this);
            SprintBacklogItems = new SprintBacklogItemsClient(this);
            Tags = new TagsClient(this);
            Watches = new WatchesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Request"/> using the specified <see cref="RequestQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which requests to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Request"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(RequestQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Request>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Request"/> items as an asynchronous stream using the specified <see cref="RequestQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which requests to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Request> StreamAsync(RequestQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Request>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Request"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the request.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Request"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Request?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Request>(new RequestQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Archive a <see cref="Request"/>.<br />
        /// The request must be disabled.
        /// </summary>
        /// <param name="request">The request to archive.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The archived <see cref="Request"/>.</returns>
        public async Task<Request> ArchiveAsync(Request request, CancellationToken ct = default)
        {
            return await PostItemAsync(request, "archive", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Request"/>.
        /// </summary>
        /// <param name="request">The request to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Request"/>.</returns>
        public async Task<Request> CreateAsync(Request request, CancellationToken ct = default)
        {
            return await PostItemAsync(request, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Request"/>.
        /// </summary>
        /// <param name="requestId">The identifier of the request to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Request"/>.</returns>
        public async Task<Request> RestoreAsync(long requestId, CancellationToken ct = default)
        {
            return await PostItemAsync(new Request(requestId), "restore", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Request"/>.
        /// </summary>
        /// <param name="reference">The reference to the request to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Request"/>.</returns>
        public async Task<Request> RestoreAsync(ResourceReference reference, CancellationToken ct = default)
        {
            if (reference is null)
                throw new ArgumentNullException(nameof(reference));

            if (!reference.Id.HasValue)
                throw new ArgumentException("The archive reference must have a valid identifier.", nameof(reference));

            return await RestoreAsync(reference.Id.Value, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Trash a <see cref="Request"/>.<br />
        /// The request must be disabled.
        /// </summary>
        /// <param name="request">The request to trash.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The trashed <see cref="Request"/>.</returns>
        public async Task<Request> TrashAsync(Request request, CancellationToken ct = default)
        {
            return await PostItemAsync(request, "trash", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Request"/>.
        /// </summary>
        /// <param name="request">The request to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Request"/>.</returns>
        public async Task<Request> UpdateAsync(Request request, CancellationToken ct = default)
        {
            return await PatchItemAsync(request, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AffectedSla"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class AffectedServiceLevelAgreementsClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AffectedServiceLevelAgreementsClient"/> class.
            /// </summary>
            internal AffectedServiceLevelAgreementsClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AffectedSla"/> records for the specified request using an <see cref="AffectedSlaQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the affected service level agreements.</param>
            /// <param name="query">The query that defines which affected service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AffectedSla"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AffectedSla>> GetAsync(long requestId, AffectedSlaQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AffectedSla>(requestId, "affected_slas", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AffectedSla"/> records for the specified request using an <see cref="AffectedSlaQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the affected service level agreements.</param>
            /// <param name="query">The query that defines which affected service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AffectedSla"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AffectedSla>> GetAsync(Request request, AffectedSlaQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AffectedSla"/> items as an asynchronous stream for the specified request using an <see cref="AffectedSlaQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the affected service level agreements.</param>
            /// <param name="query">The query that defines which affected service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AffectedSla"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AffectedSla> StreamAsync(long requestId, AffectedSlaQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AffectedSla>(requestId, "affected_slas", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AffectedSla"/> items as an asynchronous stream for the specified request using an <see cref="AffectedSlaQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the affected service level agreements.</param>
            /// <param name="query">The query that defines which affected service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AffectedSla"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AffectedSla> StreamAsync(Request request, AffectedSlaQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified request using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long requestId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(requestId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified request using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Request request, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified request using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long requestId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(requestId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified request using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Request request, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AutomationRule"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class AutomationRulesClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AutomationRulesClient"/> class.
            /// </summary>
            internal AutomationRulesClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified request using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(long requestId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AutomationRule>(requestId, "automation_rules", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AutomationRule"/> records for the specified request using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AutomationRule"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AutomationRule>> GetAsync(Request request, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified request using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(long requestId, AutomationRuleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AutomationRule>(requestId, "automation_rules", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AutomationRule"/> items as an asynchronous stream for the specified request using an <see cref="AutomationRuleQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the automation rules.</param>
            /// <param name="query">The query that defines which automation rules to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AutomationRule"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AutomationRule> StreamAsync(Request request, AutomationRuleQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified request using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long requestId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(requestId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified request using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(Request request, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified request using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long requestId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(requestId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified request using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(Request request, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long requestId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(requestId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long requestId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(requestId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Request request, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(request.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Request request, long configurationItemId, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await AddAsync(request.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long requestId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(requestId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long requestId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(requestId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Request request, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(request.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Request request, long configurationItemId, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await RemoveAsync(request.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long requestId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(requestId, "cis", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which all configuration items are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Request request, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await RemoveAllAsync(request.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Request"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class GroupedRequestsClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="GroupedRequestsClient"/> class.
            /// </summary>
            internal GroupedRequestsClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified request using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the grouped requests.</param>
            /// <param name="query">The query that defines which grouped requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(long requestId, RequestQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Request>(requestId, "grouped_requests", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified request using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the grouped requests.</param>
            /// <param name="query">The query that defines which grouped requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(Request request, RequestQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified request using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the grouped requests.</param>
            /// <param name="query">The query that defines which grouped requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(long requestId, RequestQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Request>(requestId, "grouped_requests", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified request using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the grouped requests.</param>
            /// <param name="query">The query that defines which grouped requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(Request request, RequestQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="InboundEmail"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class InboundEmailsClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="InboundEmailsClient"/> class.
            /// </summary>
            internal InboundEmailsClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="InboundEmail"/> records for the specified request using an <see cref="InboundEmailQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the inbound emails.</param>
            /// <param name="query">The query that defines which inbound emails to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="InboundEmail"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<InboundEmail>> GetAsync(long requestId, InboundEmailQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<InboundEmail>(requestId, "inbound_emails", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="InboundEmail"/> records for the specified request using an <see cref="InboundEmailQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the inbound emails.</param>
            /// <param name="query">The query that defines which inbound emails to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="InboundEmail"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<InboundEmail>> GetAsync(Request request, InboundEmailQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="InboundEmail"/> items as an asynchronous stream for the specified request using an <see cref="InboundEmailQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the inbound emails.</param>
            /// <param name="query">The query that defines which inbound emails to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="InboundEmail"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<InboundEmail> StreamAsync(long requestId, InboundEmailQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<InboundEmail>(requestId, "inbound_emails", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="InboundEmail"/> items as an asynchronous stream for the specified request using an <see cref="InboundEmailQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the inbound emails.</param>
            /// <param name="query">The query that defines which inbound emails to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="InboundEmail"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<InboundEmail> StreamAsync(Request request, InboundEmailQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="KnowledgeArticle"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class KnowledgeArticlesClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="KnowledgeArticlesClient"/> class.
            /// </summary>
            internal KnowledgeArticlesClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="KnowledgeArticle"/> records for the specified request using an <see cref="KnowledgeArticleQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the knowledge articles.</param>
            /// <param name="query">The query that defines which knowledge articles to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="KnowledgeArticle"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<KnowledgeArticle>> GetAsync(long requestId, KnowledgeArticleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<KnowledgeArticle>(requestId, "knowledge_articles", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="KnowledgeArticle"/> records for the specified request using an <see cref="KnowledgeArticleQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the knowledge articles.</param>
            /// <param name="query">The query that defines which knowledge articles to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="KnowledgeArticle"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<KnowledgeArticle>> GetAsync(Request request, KnowledgeArticleQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="KnowledgeArticle"/> items as an asynchronous stream for the specified request using an <see cref="KnowledgeArticleQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the knowledge articles.</param>
            /// <param name="query">The query that defines which knowledge articles to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="KnowledgeArticle"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<KnowledgeArticle> StreamAsync(long requestId, KnowledgeArticleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<KnowledgeArticle>(requestId, "knowledge_articles", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="KnowledgeArticle"/> items as an asynchronous stream for the specified request using an <see cref="KnowledgeArticleQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the knowledge articles.</param>
            /// <param name="query">The query that defines which knowledge articles to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="KnowledgeArticle"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<KnowledgeArticle> StreamAsync(Request request, KnowledgeArticleQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Note"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class NotesClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotesClient"/> class.
            /// </summary>
            internal NotesClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified request using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(long requestId, NoteQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Note>(requestId, "notes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Note"/> records for the specified request using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Note"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Note>> GetAsync(Request request, NoteQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified request using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(long requestId, NoteQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Note>(requestId, "notes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Note"/> items as an asynchronous stream for the specified request using an <see cref="NoteQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the notes.</param>
            /// <param name="query">The query that defines which notes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Note"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Note> StreamAsync(Request request, NoteQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(long requestId, NoteCreate noteCreate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(requestId, "notes", noteCreate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="NoteCreate"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request to which the note create is added.</param>
            /// <param name="noteCreate">The note create to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="NoteCreate"/>.</returns>
            public async Task<NoteCreate> CreateAsync(Request request, NoteCreate noteCreate, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await CreateAsync(request.Id, noteCreate, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Attachment"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class NotesAttachmentsClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="NotesAttachmentsClient"/> class.
            /// </summary>
            internal NotesAttachmentsClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Attachment"/> records for the specified request using an <see cref="AttachmentQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the notes attachments.</param>
            /// <param name="query">The query that defines which notes attachments to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Attachment"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Attachment>> GetAsync(long requestId, AttachmentQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Attachment>(requestId, "note_attachments", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Attachment"/> records for the specified request using an <see cref="AttachmentQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the notes attachments.</param>
            /// <param name="query">The query that defines which notes attachments to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Attachment"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Attachment>> GetAsync(Request request, AttachmentQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Attachment"/> items as an asynchronous stream for the specified request using an <see cref="AttachmentQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the notes attachments.</param>
            /// <param name="query">The query that defines which notes attachments to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Attachment"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Attachment> StreamAsync(long requestId, AttachmentQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Attachment>(requestId, "note_attachments", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Attachment"/> items as an asynchronous stream for the specified request using an <see cref="AttachmentQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the notes attachments.</param>
            /// <param name="query">The query that defines which notes attachments to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Attachment"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Attachment> StreamAsync(Request request, AttachmentQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SprintBacklogItem"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class SprintBacklogItemsClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SprintBacklogItemsClient"/> class.
            /// </summary>
            internal SprintBacklogItemsClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified request using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(long requestId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SprintBacklogItem>(requestId, "sprint_backlog_items", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SprintBacklogItem"/> records for the specified request using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SprintBacklogItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SprintBacklogItem>> GetAsync(Request request, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified request using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(long requestId, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SprintBacklogItem>(requestId, "sprint_backlog_items", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SprintBacklogItem"/> items as an asynchronous stream for the specified request using an <see cref="SprintBacklogItemQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the sprint backlog items.</param>
            /// <param name="query">The query that defines which sprint backlog items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SprintBacklogItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SprintBacklogItem> StreamAsync(Request request, SprintBacklogItemQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Tag"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class TagsClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TagsClient"/> class.
            /// </summary>
            internal TagsClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Tag"/> records for the specified request using an <see cref="TagQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the tags.</param>
            /// <param name="query">The query that defines which tags to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Tag"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Tag>> GetAsync(long requestId, TagQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Tag>(requestId, "tags", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Tag"/> records for the specified request using an <see cref="TagQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the tags.</param>
            /// <param name="query">The query that defines which tags to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Tag"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Tag>> GetAsync(Request request, TagQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Tag"/> items as an asynchronous stream for the specified request using an <see cref="TagQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the tags.</param>
            /// <param name="query">The query that defines which tags to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Tag"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Tag> StreamAsync(long requestId, TagQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Tag>(requestId, "tags", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Tag"/> items as an asynchronous stream for the specified request using an <see cref="TagQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the tags.</param>
            /// <param name="query">The query that defines which tags to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Tag"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Tag> StreamAsync(Request request, TagQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="Tag"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="tag">The tag to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Tag"/>.</returns>
            public async Task<Tag> CreateAsync(long requestId, Tag tag, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(requestId, "tags", tag, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="Tag"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request to which the tag is added.</param>
            /// <param name="tag">The tag to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Tag"/>.</returns>
            public async Task<Tag> CreateAsync(Request request, Tag tag, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await CreateAsync(request.Id, tag, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Tag"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="tagId">The identifier of the tag to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long requestId, long tagId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(requestId, "tags", tagId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Tag"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="tag">The tag to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long requestId, Tag tag, CancellationToken ct = default)
            {
                if (tag is null)
                    throw new ArgumentNullException(nameof(tag));

                return await DeleteAsync(requestId, tag.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Tag"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which the tag is removed.</param>
            /// <param name="tag">The tag to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Request request, Tag tag, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                if (tag is null)
                    throw new ArgumentNullException(nameof(tag));

                return await DeleteAsync(request.Id, tag.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Tag"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which the tag is removed.</param>
            /// <param name="tagId">The identifier of the tag to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Request request, long tagId, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await DeleteAsync(request.Id, tagId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all tags associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long requestId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(requestId, "tags", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all tags associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which all tags are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Request request, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await DeleteAllAsync(request.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Watch"/> records related to an <see cref="Request"/>.
        /// </summary>
        public sealed class WatchesClient
        {
            private readonly RequestClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="WatchesClient"/> class.
            /// </summary>
            internal WatchesClient(RequestClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Watch"/> records for the specified request using an <see cref="WatchQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to retrieve the watches.</param>
            /// <param name="query">The query that defines which watches to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Watch"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Watch>> GetAsync(long requestId, WatchQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Watch>(requestId, "watches", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Watch"/> records for the specified request using an <see cref="WatchQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to retrieve the watches.</param>
            /// <param name="query">The query that defines which watches to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Watch"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Watch>> GetAsync(Request request, WatchQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Watch"/> items as an asynchronous stream for the specified request using an <see cref="WatchQuery"/>.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request for which to enumerate the watches.</param>
            /// <param name="query">The query that defines which watches to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Watch"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Watch> StreamAsync(long requestId, WatchQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Watch>(requestId, "watches", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Watch"/> items as an asynchronous stream for the specified request using an <see cref="WatchQuery"/>.
            /// </summary>
            /// <param name="request">The request for which to enumerate the watches.</param>
            /// <param name="query">The query that defines which watches to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Watch"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Watch> StreamAsync(Request request, WatchQuery query, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return StreamAsync(request.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="Watch"/> by its unique identifier for the specified request.
            /// </summary>
            /// <param name="requestId">The unique identifier of the request.</param>
            /// <param name="watchId">The unique identifier of the watch.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="Watch"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<Watch?> GetAsync(long requestId, long watchId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<Watch>(requestId, "watches", new WatchQuery().WithId(watchId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="Watch"/> record for the specified request.
            /// </summary>
            /// <param name="request">The request for which to retrieve the watch.</param>
            /// <param name="watchId">The unique identifier of the watch.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="Watch"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<Watch?> GetAsync(Request request, long watchId, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await GetAsync(request.Id, watchId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="Watch"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="watch">The watch to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Watch"/>.</returns>
            public async Task<Watch> CreateAsync(long requestId, Watch watch, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(requestId, "watches", watch, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="Watch"/> to a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request to which the watch is added.</param>
            /// <param name="watch">The watch to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Watch"/>.</returns>
            public async Task<Watch> CreateAsync(Request request, Watch watch, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await CreateAsync(request.Id, watch, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="Watch"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="watch">The watch to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Watch"/>.</returns>
            public async Task<Watch> UpdateAsync(long requestId, Watch watch, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(requestId, "watches", watch, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="Watch"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request with which the watch is associated.</param>
            /// <param name="watch">The watch to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Watch"/>.</returns>
            public async Task<Watch> UpdateAsync(Request request, Watch watch, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await UpdateAsync(request.Id, watch, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Watch"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="watchId">The identifier of the watch to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long requestId, long watchId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(requestId, "watches", watchId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Watch"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="watch">The watch to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long requestId, Watch watch, CancellationToken ct = default)
            {
                if (watch is null)
                    throw new ArgumentNullException(nameof(watch));

                return await DeleteAsync(requestId, watch.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Watch"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which the watch is removed.</param>
            /// <param name="watch">The watch to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Request request, Watch watch, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                if (watch is null)
                    throw new ArgumentNullException(nameof(watch));

                return await DeleteAsync(request.Id, watch.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Watch"/> associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which the watch is removed.</param>
            /// <param name="watchId">The identifier of the watch to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Request request, long watchId, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await DeleteAsync(request.Id, watchId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all watches associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="requestId">The identifier of the request.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long requestId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(requestId, "watches", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all watches associated with a <see cref="Request"/>.
            /// </summary>
            /// <param name="request">The request from which all watches are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Request request, CancellationToken ct = default)
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                return await DeleteAllAsync(request.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
