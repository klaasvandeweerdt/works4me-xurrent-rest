using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ServiceInstance"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/service_instances/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ServiceInstanceClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public ChildrenClient Children { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public ParentsClient Parents { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public ServiceLevelAgreementsClient ServiceLevelAgreements { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceInstanceClient"/> class.
        /// </summary>
        internal ServiceInstanceClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "service_instances/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Children = new ChildrenClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
            Parents = new ParentsClient(this);
            ServiceLevelAgreements = new ServiceLevelAgreementsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ServiceInstance"/> using the specified <see cref="ServiceInstanceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service instances to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(ServiceInstanceQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ServiceInstance>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream using the specified <see cref="ServiceInstanceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service instances to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ServiceInstance> StreamAsync(ServiceInstanceQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ServiceInstance>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ServiceInstance"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service instance.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ServiceInstance"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ServiceInstance?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ServiceInstance>(new ServiceInstanceQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ServiceInstance"/>.
        /// </summary>
        /// <param name="serviceInstance">The service instance to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ServiceInstance"/>.</returns>
        public async Task<ServiceInstance> CreateAsync(ServiceInstance serviceInstance, CancellationToken ct = default)
        {
            return await PostItemAsync(serviceInstance, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ServiceInstance"/>.
        /// </summary>
        /// <param name="serviceInstance">The service instance to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ServiceInstance"/>.</returns>
        public async Task<ServiceInstance> UpdateAsync(ServiceInstance serviceInstance, CancellationToken ct = default)
        {
            return await PatchItemAsync(serviceInstance, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ServiceInstanceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ServiceInstanceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service instance using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long serviceInstanceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(serviceInstanceId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service instance using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ServiceInstance serviceInstance, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await GetAsync(serviceInstance.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service instance using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long serviceInstanceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(serviceInstanceId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service instance using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ServiceInstance serviceInstance, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return StreamAsync(serviceInstance.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public sealed class ChildrenClient
        {
            private readonly ServiceInstanceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ChildrenClient"/> class.
            /// </summary>
            internal ChildrenClient(ServiceInstanceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified service instance using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to retrieve the children.</param>
            /// <param name="query">The query that defines which children to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long serviceInstanceId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(serviceInstanceId, "child_service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified service instance using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to retrieve the children.</param>
            /// <param name="query">The query that defines which children to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(ServiceInstance serviceInstance, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await GetAsync(serviceInstance.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified service instance using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to enumerate the children.</param>
            /// <param name="query">The query that defines which children to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long serviceInstanceId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(serviceInstanceId, "child_service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified service instance using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to enumerate the children.</param>
            /// <param name="query">The query that defines which children to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(ServiceInstance serviceInstance, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return StreamAsync(serviceInstance.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly ServiceInstanceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(ServiceInstanceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified service instance using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long serviceInstanceId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(serviceInstanceId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified service instance using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(ServiceInstance serviceInstance, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await GetAsync(serviceInstance.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified service instance using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long serviceInstanceId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(serviceInstanceId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified service instance using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(ServiceInstance serviceInstance, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return StreamAsync(serviceInstance.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The identifier of the service instance.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceInstanceId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceInstanceId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The identifier of the service instance.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceInstanceId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(serviceInstanceId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceInstance serviceInstance, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(serviceInstance.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceInstance serviceInstance, long configurationItemId, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(serviceInstance.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The identifier of the service instance.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceInstanceId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceInstanceId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The identifier of the service instance.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceInstanceId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(serviceInstanceId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceInstance serviceInstance, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(serviceInstance.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceInstance serviceInstance, long configurationItemId, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(serviceInstance.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The identifier of the service instance.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceInstanceId, "cis", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="ServiceInstance"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance from which all configuration items are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAllAsync(serviceInstance.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public sealed class ParentsClient
        {
            private readonly ServiceInstanceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ParentsClient"/> class.
            /// </summary>
            internal ParentsClient(ServiceInstanceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified service instance using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to retrieve the parents.</param>
            /// <param name="query">The query that defines which parents to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long serviceInstanceId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(serviceInstanceId, "parent_service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified service instance using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to retrieve the parents.</param>
            /// <param name="query">The query that defines which parents to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(ServiceInstance serviceInstance, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await GetAsync(serviceInstance.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified service instance using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to enumerate the parents.</param>
            /// <param name="query">The query that defines which parents to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long serviceInstanceId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(serviceInstanceId, "parent_service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified service instance using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to enumerate the parents.</param>
            /// <param name="query">The query that defines which parents to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(ServiceInstance serviceInstance, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return StreamAsync(serviceInstance.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="ServiceInstance"/>.
        /// </summary>
        public sealed class ServiceLevelAgreementsClient
        {
            private readonly ServiceInstanceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceLevelAgreementsClient"/> class.
            /// </summary>
            internal ServiceLevelAgreementsClient(ServiceInstanceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified service instance using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(long serviceInstanceId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceLevelAgreement>(serviceInstanceId, "slas", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified service instance using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(ServiceInstance serviceInstance, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await GetAsync(serviceInstance.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified service instance using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceInstanceId">The unique identifier of the service instance for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(long serviceInstanceId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceLevelAgreement>(serviceInstanceId, "slas", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified service instance using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceInstance">The service instance for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(ServiceInstance serviceInstance, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return StreamAsync(serviceInstance.Id, query, ct);
            }
        }
    }
}
