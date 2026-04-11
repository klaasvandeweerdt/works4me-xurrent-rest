using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Broadcast"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/broadcasts/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class BroadcastClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Organization"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public CustomersClient Customers { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Team"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public TeamsClient Teams { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="BroadcastTranslation"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public TranslationsClient Translations { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BroadcastClient"/> class.
        /// </summary>
        internal BroadcastClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "broadcasts/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Customers = new CustomersClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
            Teams = new TeamsClient(this);
            Translations = new TranslationsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Broadcast"/> using the specified <see cref="BroadcastQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which broadcasts to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Broadcast"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Broadcast>> GetAsync(BroadcastQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Broadcast>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Broadcast"/> items as an asynchronous stream using the specified <see cref="BroadcastQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which broadcasts to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Broadcast"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Broadcast> StreamAsync(BroadcastQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Broadcast>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Broadcast"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the broadcast.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Broadcast"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Broadcast?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Broadcast>(new BroadcastQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Broadcast"/>.
        /// </summary>
        /// <param name="broadcast">The broadcast to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Broadcast"/>.</returns>
        public async Task<Broadcast> CreateAsync(Broadcast broadcast, CancellationToken ct = default)
        {
            return await PostItemAsync(broadcast, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Broadcast"/>.
        /// </summary>
        /// <param name="broadcast">The broadcast to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Broadcast"/>.</returns>
        public async Task<Broadcast> UpdateAsync(Broadcast broadcast, CancellationToken ct = default)
        {
            return await PatchItemAsync(broadcast, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly BroadcastClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(BroadcastClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified broadcast using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long broadcastId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(broadcastId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified broadcast using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Broadcast broadcast, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await GetAsync(broadcast.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified broadcast using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long broadcastId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(broadcastId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified broadcast using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Broadcast broadcast, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return StreamAsync(broadcast.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Organization"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public sealed class CustomersClient
        {
            private readonly BroadcastClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomersClient"/> class.
            /// </summary>
            internal CustomersClient(BroadcastClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified broadcast using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to retrieve the customers.</param>
            /// <param name="query">The query that defines which customers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(long broadcastId, OrganizationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Organization>(broadcastId, "customers", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified broadcast using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to retrieve the customers.</param>
            /// <param name="query">The query that defines which customers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(Broadcast broadcast, OrganizationQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await GetAsync(broadcast.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified broadcast using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to enumerate the customers.</param>
            /// <param name="query">The query that defines which customers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(long broadcastId, OrganizationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Organization>(broadcastId, "customers", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified broadcast using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to enumerate the customers.</param>
            /// <param name="query">The query that defines which customers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(Broadcast broadcast, OrganizationQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return StreamAsync(broadcast.Id, query, ct);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long broadcastId, long organizationId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(broadcastId, "customers", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long broadcastId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(broadcastId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the organization is removed.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Broadcast broadcast, Organization organization, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(broadcast.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Broadcast broadcast, long organizationId, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await AddAsync(broadcast.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long broadcastId, long organizationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(broadcastId, "customers", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long broadcastId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(broadcastId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the organization is removed.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Broadcast broadcast, Organization organization, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(broadcast.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Broadcast broadcast, long organizationId, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await RemoveAsync(broadcast.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all customers associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long broadcastId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(broadcastId, "customers", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all customers associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which all customers are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Broadcast broadcast, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await RemoveAllAsync(broadcast.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly BroadcastClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(BroadcastClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified broadcast using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long broadcastId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(broadcastId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified broadcast using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(Broadcast broadcast, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await GetAsync(broadcast.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified broadcast using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long broadcastId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(broadcastId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified broadcast using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(Broadcast broadcast, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return StreamAsync(broadcast.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long broadcastId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(broadcastId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long broadcastId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(broadcastId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Broadcast broadcast, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await AddAsync(broadcast.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceInstance"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Broadcast broadcast, long serviceInstanceId, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await AddAsync(broadcast.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long broadcastId, long serviceInstanceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(broadcastId, "service_instances", serviceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long broadcastId, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(broadcastId, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the service instance is removed.</param>
            /// <param name="serviceInstance">The service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Broadcast broadcast, ServiceInstance serviceInstance, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                if (serviceInstance is null)
                    throw new ArgumentNullException(nameof(serviceInstance));

                return await RemoveAsync(broadcast.Id, serviceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceInstance"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the service instance is removed.</param>
            /// <param name="serviceInstanceId">The identifier of the service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Broadcast broadcast, long serviceInstanceId, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await RemoveAsync(broadcast.Id, serviceInstanceId, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Team"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public sealed class TeamsClient
        {
            private readonly BroadcastClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TeamsClient"/> class.
            /// </summary>
            internal TeamsClient(BroadcastClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Team"/> records for the specified broadcast using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to retrieve the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Team"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Team>> GetAsync(long broadcastId, TeamQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Team>(broadcastId, "teams", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Team"/> records for the specified broadcast using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to retrieve the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Team"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Team>> GetAsync(Broadcast broadcast, TeamQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await GetAsync(broadcast.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Team"/> items as an asynchronous stream for the specified broadcast using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to enumerate the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Team"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Team> StreamAsync(long broadcastId, TeamQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Team>(broadcastId, "teams", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Team"/> items as an asynchronous stream for the specified broadcast using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to enumerate the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Team"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Team> StreamAsync(Broadcast broadcast, TeamQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return StreamAsync(broadcast.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Team"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="teamId">The identifier of the team to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long broadcastId, long teamId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(broadcastId, "teams", teamId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Team"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="team">The team to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long broadcastId, Team team, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await AddAsync(broadcastId, team.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Team"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the team is removed.</param>
            /// <param name="team">The team to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Broadcast broadcast, Team team, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await AddAsync(broadcast.Id, team.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Team"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the team is removed.</param>
            /// <param name="teamId">The identifier of the team to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Broadcast broadcast, long teamId, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await AddAsync(broadcast.Id, teamId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Team"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="teamId">The identifier of the team to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long broadcastId, long teamId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(broadcastId, "teams", teamId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Team"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="team">The team to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long broadcastId, Team team, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await RemoveAsync(broadcastId, team.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Team"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the team is removed.</param>
            /// <param name="team">The team to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Broadcast broadcast, Team team, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await RemoveAsync(broadcast.Id, team.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Team"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the team is removed.</param>
            /// <param name="teamId">The identifier of the team to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Broadcast broadcast, long teamId, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await RemoveAsync(broadcast.Id, teamId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all teams associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long broadcastId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(broadcastId, "teams", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all teams associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which all teams are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Broadcast broadcast, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await RemoveAllAsync(broadcast.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="BroadcastTranslation"/> records related to an <see cref="Broadcast"/>.
        /// </summary>
        public sealed class TranslationsClient
        {
            private readonly BroadcastClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TranslationsClient"/> class.
            /// </summary>
            internal TranslationsClient(BroadcastClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="BroadcastTranslation"/> records for the specified broadcast using an <see cref="BroadcastTranslationQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to retrieve the translations.</param>
            /// <param name="query">The query that defines which translations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="BroadcastTranslation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<BroadcastTranslation>> GetAsync(long broadcastId, BroadcastTranslationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<BroadcastTranslation>(broadcastId, "translations", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="BroadcastTranslation"/> records for the specified broadcast using an <see cref="BroadcastTranslationQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to retrieve the translations.</param>
            /// <param name="query">The query that defines which translations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="BroadcastTranslation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<BroadcastTranslation>> GetAsync(Broadcast broadcast, BroadcastTranslationQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await GetAsync(broadcast.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="BroadcastTranslation"/> items as an asynchronous stream for the specified broadcast using an <see cref="BroadcastTranslationQuery"/>.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast for which to enumerate the translations.</param>
            /// <param name="query">The query that defines which translations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="BroadcastTranslation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<BroadcastTranslation> StreamAsync(long broadcastId, BroadcastTranslationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<BroadcastTranslation>(broadcastId, "translations", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="BroadcastTranslation"/> items as an asynchronous stream for the specified broadcast using an <see cref="BroadcastTranslationQuery"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to enumerate the translations.</param>
            /// <param name="query">The query that defines which translations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="BroadcastTranslation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<BroadcastTranslation> StreamAsync(Broadcast broadcast, BroadcastTranslationQuery query, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return StreamAsync(broadcast.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="BroadcastTranslation"/> by its unique identifier for the specified broadcast.
            /// </summary>
            /// <param name="broadcastId">The unique identifier of the broadcast.</param>
            /// <param name="broadcastTranslationId">The unique identifier of the broadcast translation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="BroadcastTranslation"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<BroadcastTranslation?> GetAsync(long broadcastId, long broadcastTranslationId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<BroadcastTranslation>(broadcastId, "translations", new BroadcastTranslationQuery().WithId(broadcastTranslationId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="BroadcastTranslation"/> record for the specified broadcast.
            /// </summary>
            /// <param name="broadcast">The broadcast for which to retrieve the broadcast translation.</param>
            /// <param name="broadcastTranslationId">The unique identifier of the broadcast translation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="BroadcastTranslation"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<BroadcastTranslation?> GetAsync(Broadcast broadcast, long broadcastTranslationId, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await GetAsync(broadcast.Id, broadcastTranslationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="BroadcastTranslation"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="broadcastTranslation">The broadcast translation to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="BroadcastTranslation"/>.</returns>
            public async Task<BroadcastTranslation> CreateAsync(long broadcastId, BroadcastTranslation broadcastTranslation, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(broadcastId, "translations", broadcastTranslation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="BroadcastTranslation"/> to a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast to which the broadcast translation is added.</param>
            /// <param name="broadcastTranslation">The broadcast translation to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="BroadcastTranslation"/>.</returns>
            public async Task<BroadcastTranslation> CreateAsync(Broadcast broadcast, BroadcastTranslation broadcastTranslation, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await CreateAsync(broadcast.Id, broadcastTranslation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="BroadcastTranslation"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="broadcastTranslation">The broadcast translation to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="BroadcastTranslation"/>.</returns>
            public async Task<BroadcastTranslation> UpdateAsync(long broadcastId, BroadcastTranslation broadcastTranslation, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(broadcastId, "translations", broadcastTranslation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="BroadcastTranslation"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast with which the broadcast translation is associated.</param>
            /// <param name="broadcastTranslation">The broadcast translation to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="BroadcastTranslation"/>.</returns>
            public async Task<BroadcastTranslation> UpdateAsync(Broadcast broadcast, BroadcastTranslation broadcastTranslation, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await UpdateAsync(broadcast.Id, broadcastTranslation, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="BroadcastTranslation"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="broadcastTranslationId">The identifier of the broadcast translation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long broadcastId, long broadcastTranslationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(broadcastId, "translations", broadcastTranslationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="BroadcastTranslation"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcastId">The identifier of the broadcast.</param>
            /// <param name="broadcastTranslation">The broadcast translation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long broadcastId, BroadcastTranslation broadcastTranslation, CancellationToken ct = default)
            {
                if (broadcastTranslation is null)
                    throw new ArgumentNullException(nameof(broadcastTranslation));

                return await DeleteAsync(broadcastId, broadcastTranslation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="BroadcastTranslation"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the broadcast translation is removed.</param>
            /// <param name="broadcastTranslation">The broadcast translation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Broadcast broadcast, BroadcastTranslation broadcastTranslation, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                if (broadcastTranslation is null)
                    throw new ArgumentNullException(nameof(broadcastTranslation));

                return await DeleteAsync(broadcast.Id, broadcastTranslation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="BroadcastTranslation"/> associated with a <see cref="Broadcast"/>.
            /// </summary>
            /// <param name="broadcast">The broadcast from which the broadcast translation is removed.</param>
            /// <param name="broadcastTranslationId">The identifier of the broadcast translation to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Broadcast broadcast, long broadcastTranslationId, CancellationToken ct = default)
            {
                if (broadcast is null)
                    throw new ArgumentNullException(nameof(broadcast));

                return await DeleteAsync(broadcast.Id, broadcastTranslationId, ct).ConfigureAwait(false);
            }
        }
    }
}
