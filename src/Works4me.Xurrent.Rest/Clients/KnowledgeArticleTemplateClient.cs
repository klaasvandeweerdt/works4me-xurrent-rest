using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="KnowledgeArticleTemplate"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/knowledge_article_templates/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class KnowledgeArticleTemplateClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="KnowledgeArticleTemplate"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="KnowledgeArticle"/> records related to an <see cref="KnowledgeArticleTemplate"/>.
        /// </summary>
        public KnowledgeArticlesClient KnowledgeArticles { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="KnowledgeArticleTemplate"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnowledgeArticleTemplateClient"/> class.
        /// </summary>
        internal KnowledgeArticleTemplateClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "knowledge_article_templates/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            KnowledgeArticles = new KnowledgeArticlesClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="KnowledgeArticleTemplate"/> using the specified <see cref="KnowledgeArticleTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which knowledge article templates to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="KnowledgeArticleTemplate"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<KnowledgeArticleTemplate>> GetAsync(KnowledgeArticleTemplateQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<KnowledgeArticleTemplate>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="KnowledgeArticleTemplate"/> items as an asynchronous stream using the specified <see cref="KnowledgeArticleTemplateQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which knowledge article templates to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="KnowledgeArticleTemplate"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<KnowledgeArticleTemplate> StreamAsync(KnowledgeArticleTemplateQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<KnowledgeArticleTemplate>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="KnowledgeArticleTemplate"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the knowledge article template.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="KnowledgeArticleTemplate"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<KnowledgeArticleTemplate?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<KnowledgeArticleTemplate>(new KnowledgeArticleTemplateQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="KnowledgeArticleTemplate"/>.
        /// </summary>
        /// <param name="knowledgeArticleTemplate">The knowledge article template to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="KnowledgeArticleTemplate"/>.</returns>
        public async Task<KnowledgeArticleTemplate> CreateAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, CancellationToken ct = default)
        {
            return await PostItemAsync(knowledgeArticleTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="KnowledgeArticleTemplate"/>.
        /// </summary>
        /// <param name="knowledgeArticleTemplate">The knowledge article template to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="KnowledgeArticleTemplate"/>.</returns>
        public async Task<KnowledgeArticleTemplate> UpdateAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, CancellationToken ct = default)
        {
            return await PatchItemAsync(knowledgeArticleTemplate, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="KnowledgeArticleTemplate"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly KnowledgeArticleTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(KnowledgeArticleTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified knowledge article template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The unique identifier of the knowledge article template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long knowledgeArticleTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(knowledgeArticleTemplateId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified knowledge article template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                return await GetAsync(knowledgeArticleTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified knowledge article template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The unique identifier of the knowledge article template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long knowledgeArticleTemplateId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(knowledgeArticleTemplateId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified knowledge article template using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                return StreamAsync(knowledgeArticleTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="KnowledgeArticle"/> records related to an <see cref="KnowledgeArticleTemplate"/>.
        /// </summary>
        public sealed class KnowledgeArticlesClient
        {
            private readonly KnowledgeArticleTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="KnowledgeArticlesClient"/> class.
            /// </summary>
            internal KnowledgeArticlesClient(KnowledgeArticleTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="KnowledgeArticle"/> records for the specified knowledge article template using an <see cref="KnowledgeArticleQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The unique identifier of the knowledge article template for which to retrieve the knowledge articles.</param>
            /// <param name="query">The query that defines which knowledge articles to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="KnowledgeArticle"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<KnowledgeArticle>> GetAsync(long knowledgeArticleTemplateId, KnowledgeArticleQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<KnowledgeArticle>(knowledgeArticleTemplateId, "knowledge_articles", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="KnowledgeArticle"/> records for the specified knowledge article template using an <see cref="KnowledgeArticleQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template for which to retrieve the knowledge articles.</param>
            /// <param name="query">The query that defines which knowledge articles to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="KnowledgeArticle"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<KnowledgeArticle>> GetAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, KnowledgeArticleQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                return await GetAsync(knowledgeArticleTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="KnowledgeArticle"/> items as an asynchronous stream for the specified knowledge article template using an <see cref="KnowledgeArticleQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The unique identifier of the knowledge article template for which to enumerate the knowledge articles.</param>
            /// <param name="query">The query that defines which knowledge articles to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="KnowledgeArticle"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<KnowledgeArticle> StreamAsync(long knowledgeArticleTemplateId, KnowledgeArticleQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<KnowledgeArticle>(knowledgeArticleTemplateId, "knowledge_articles", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="KnowledgeArticle"/> items as an asynchronous stream for the specified knowledge article template using an <see cref="KnowledgeArticleQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template for which to enumerate the knowledge articles.</param>
            /// <param name="query">The query that defines which knowledge articles to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="KnowledgeArticle"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<KnowledgeArticle> StreamAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, KnowledgeArticleQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                return StreamAsync(knowledgeArticleTemplate.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="KnowledgeArticleTemplate"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly KnowledgeArticleTemplateClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(KnowledgeArticleTemplateClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified knowledge article template using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The unique identifier of the knowledge article template for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long knowledgeArticleTemplateId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(knowledgeArticleTemplateId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified knowledge article template using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                return await GetAsync(knowledgeArticleTemplate.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified knowledge article template using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The unique identifier of the knowledge article template for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long knowledgeArticleTemplateId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(knowledgeArticleTemplateId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified knowledge article template using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                return StreamAsync(knowledgeArticleTemplate.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The identifier of the knowledge article template.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long knowledgeArticleTemplateId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(knowledgeArticleTemplateId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The identifier of the knowledge article template.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long knowledgeArticleTemplateId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(knowledgeArticleTemplateId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(knowledgeArticleTemplate.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, long serviceInstanceId, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                return await AddAsync(knowledgeArticleTemplate.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The identifier of the knowledge article template.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long knowledgeArticleTemplateId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(knowledgeArticleTemplateId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The identifier of the knowledge article template.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long knowledgeArticleTemplateId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(knowledgeArticleTemplateId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(knowledgeArticleTemplate.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, long serviceInstanceId, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                return await RemoveAsync(knowledgeArticleTemplate.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplateId">The identifier of the knowledge article template.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long knowledgeArticleTemplateId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(knowledgeArticleTemplateId, "service_instances", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="KnowledgeArticleTemplate"/>.
            /// </summary>
            /// <param name="knowledgeArticleTemplate">The knowledge article template from which all service instances are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(KnowledgeArticleTemplate knowledgeArticleTemplate, CancellationToken ct = default)
            {
                if (knowledgeArticleTemplate is null)
                    throw new ArgumentNullException(nameof(knowledgeArticleTemplate));

                return await RemoveAllAsync(knowledgeArticleTemplate.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
