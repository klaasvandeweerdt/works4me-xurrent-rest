using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="KnowledgeArticle"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/knowledge_articles/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class KnowledgeArticleClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="KnowledgeArticle"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Request"/> records related to an <see cref="KnowledgeArticle"/>.
        /// </summary>
        public RequestsClient Requests { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="KnowledgeArticle"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="KnowledgeArticleTranslation"/> records related to an <see cref="KnowledgeArticle"/>.
        /// </summary>
        public TranslationsClient Translations { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgeArticleClient"/> class.
        /// </summary>
        internal KnowledgeArticleClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "knowledge_articles/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Requests = new RequestsClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
            Translations = new TranslationsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="KnowledgeArticle"/> using the specified <see cref="KnowledgeArticleQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which knowledge articles to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="KnowledgeArticle"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<KnowledgeArticle>> GetAsync(KnowledgeArticleQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<KnowledgeArticle>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="KnowledgeArticle"/> items as an asynchronous stream using the specified <see cref="KnowledgeArticleQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which knowledge articles to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="KnowledgeArticle"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<KnowledgeArticle> StreamAsync(KnowledgeArticleQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<KnowledgeArticle>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="KnowledgeArticle"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the knowledge article.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="KnowledgeArticle"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<KnowledgeArticle?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<KnowledgeArticle>(new KnowledgeArticleQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="KnowledgeArticle"/>.
        /// </summary>
        /// <param name="knowledgeArticle">The knowledge article to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="KnowledgeArticle"/>.</returns>
        public async Task<KnowledgeArticle> CreateAsync(KnowledgeArticle knowledgeArticle, CancellationToken ct = default)
        {
            return await PostItemAsync(knowledgeArticle, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="KnowledgeArticle"/>.
        /// </summary>
        /// <param name="knowledgeArticle">The knowledge article to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="KnowledgeArticle"/>.</returns>
        public async Task<KnowledgeArticle> UpdateAsync(KnowledgeArticle knowledgeArticle, CancellationToken ct = default)
        {
            return await PatchItemAsync(knowledgeArticle, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="KnowledgeArticle"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly KnowledgeArticleClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(KnowledgeArticleClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified knowledge article using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The unique identifier of the knowledge article for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long knowledgeArticleId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(knowledgeArticleId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified knowledge article using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(KnowledgeArticle knowledgeArticle, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return await GetAsync(knowledgeArticle.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified knowledge article using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The unique identifier of the knowledge article for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long knowledgeArticleId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(knowledgeArticleId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified knowledge article using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(KnowledgeArticle knowledgeArticle, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return StreamAsync(knowledgeArticle.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Request"/> records related to an <see cref="KnowledgeArticle"/>.
        /// </summary>
        public sealed class RequestsClient
        {
            private readonly KnowledgeArticleClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RequestsClient"/> class.
            /// </summary>
            internal RequestsClient(KnowledgeArticleClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified knowledge article using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The unique identifier of the knowledge article for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(long knowledgeArticleId, RequestQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Request>(knowledgeArticleId, "requests", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Request"/> records for the specified knowledge article using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article for which to retrieve the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Request"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Request>> GetAsync(KnowledgeArticle knowledgeArticle, RequestQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return await GetAsync(knowledgeArticle.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified knowledge article using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The unique identifier of the knowledge article for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(long knowledgeArticleId, RequestQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Request>(knowledgeArticleId, "requests", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Request"/> items as an asynchronous stream for the specified knowledge article using an <see cref="RequestQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article for which to enumerate the requests.</param>
            /// <param name="query">The query that defines which requests to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Request"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Request> StreamAsync(KnowledgeArticle knowledgeArticle, RequestQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return StreamAsync(knowledgeArticle.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="KnowledgeArticle"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly KnowledgeArticleClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(KnowledgeArticleClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified knowledge article using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The unique identifier of the knowledge article for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long knowledgeArticleId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(knowledgeArticleId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified knowledge article using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(KnowledgeArticle knowledgeArticle, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return await GetAsync(knowledgeArticle.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified knowledge article using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The unique identifier of the knowledge article for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long knowledgeArticleId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(knowledgeArticleId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified knowledge article using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(KnowledgeArticle knowledgeArticle, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return StreamAsync(knowledgeArticle.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The identifier of the knowledge article.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long knowledgeArticleId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(knowledgeArticleId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The identifier of the knowledge article.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long knowledgeArticleId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(knowledgeArticleId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(KnowledgeArticle knowledgeArticle, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(knowledgeArticle.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(KnowledgeArticle knowledgeArticle, long serviceInstanceId, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return await AddAsync(knowledgeArticle.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The identifier of the knowledge article.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long knowledgeArticleId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(knowledgeArticleId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The identifier of the knowledge article.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long knowledgeArticleId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(knowledgeArticleId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(KnowledgeArticle knowledgeArticle, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(knowledgeArticle.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(KnowledgeArticle knowledgeArticle, long serviceInstanceId, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return await RemoveAsync(knowledgeArticle.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The identifier of the knowledge article.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long knowledgeArticleId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(knowledgeArticleId, "service_instances", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="KnowledgeArticle"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article from which all service instances are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(KnowledgeArticle knowledgeArticle, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return await RemoveAllAsync(knowledgeArticle.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="KnowledgeArticleTranslation"/> records related to an <see cref="KnowledgeArticle"/>.
        /// </summary>
        public sealed class TranslationsClient
        {
            private readonly KnowledgeArticleClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TranslationsClient"/> class.
            /// </summary>
            internal TranslationsClient(KnowledgeArticleClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="KnowledgeArticleTranslation"/> records for the specified knowledge article using an <see cref="KnowledgeArticleTranslationQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The unique identifier of the knowledge article for which to retrieve the translations.</param>
            /// <param name="query">The query that defines which translations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="KnowledgeArticleTranslation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<KnowledgeArticleTranslation>> GetAsync(long knowledgeArticleId, KnowledgeArticleTranslationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<KnowledgeArticleTranslation>(knowledgeArticleId, "translations", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="KnowledgeArticleTranslation"/> records for the specified knowledge article using an <see cref="KnowledgeArticleTranslationQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article for which to retrieve the translations.</param>
            /// <param name="query">The query that defines which translations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="KnowledgeArticleTranslation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<KnowledgeArticleTranslation>> GetAsync(KnowledgeArticle knowledgeArticle, KnowledgeArticleTranslationQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return await GetAsync(knowledgeArticle.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="KnowledgeArticleTranslation"/> items as an asynchronous stream for the specified knowledge article using an <see cref="KnowledgeArticleTranslationQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleId">The unique identifier of the knowledge article for which to enumerate the translations.</param>
            /// <param name="query">The query that defines which translations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="KnowledgeArticleTranslation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<KnowledgeArticleTranslation> StreamAsync(long knowledgeArticleId, KnowledgeArticleTranslationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<KnowledgeArticleTranslation>(knowledgeArticleId, "translations", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="KnowledgeArticleTranslation"/> items as an asynchronous stream for the specified knowledge article using an <see cref="KnowledgeArticleTranslationQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article for which to enumerate the translations.</param>
            /// <param name="query">The query that defines which translations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="KnowledgeArticleTranslation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<KnowledgeArticleTranslation> StreamAsync(KnowledgeArticle knowledgeArticle, KnowledgeArticleTranslationQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return StreamAsync(knowledgeArticle.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="KnowledgeArticleTranslation"/> by its unique identifier for the specified knowledge article.
            /// </summary>
            /// <param name="knowledgeArticleId">The unique identifier of the knowledge article.</param>
            /// <param name="knowledgeArticleTranslationId">The unique identifier of the knowledge article translation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="KnowledgeArticleTranslation"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<KnowledgeArticleTranslation?> GetAsync(long knowledgeArticleId, long knowledgeArticleTranslationId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<KnowledgeArticleTranslation>(knowledgeArticleId, "translations", new KnowledgeArticleTranslationQuery().WithId(knowledgeArticleTranslationId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="KnowledgeArticleTranslation"/> record for the specified knowledge article.
            /// </summary>
            /// <param name="knowledgeArticle">The knowledge article for which to retrieve the knowledge article translation.</param>
            /// <param name="knowledgeArticleTranslationId">The unique identifier of the knowledge article translation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="KnowledgeArticleTranslation"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<KnowledgeArticleTranslation?> GetAsync(KnowledgeArticle knowledgeArticle, long knowledgeArticleTranslationId, CancellationToken ct = default)
            {
                if (knowledgeArticle is null)
                    throw new ArgumentNullException(nameof(knowledgeArticle));

                return await GetAsync(knowledgeArticle.Id, knowledgeArticleTranslationId, ct).ConfigureAwait(false);
            }
        }
    }
}
