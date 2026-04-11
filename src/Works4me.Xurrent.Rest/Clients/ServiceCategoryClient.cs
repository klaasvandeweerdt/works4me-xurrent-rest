using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ServiceCategory"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/service_categories/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ServiceCategoryClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ServiceCategory"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Service"/> records related to an <see cref="ServiceCategory"/>.
        /// </summary>
        public ServicesClient Services { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCategoryClient"/> class.
        /// </summary>
        internal ServiceCategoryClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "service_categories/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Services = new ServicesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ServiceCategory"/> using the specified <see cref="ServiceCategoryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service categories to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ServiceCategory"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ServiceCategory>> GetAsync(ServiceCategoryQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ServiceCategory>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ServiceCategory"/> items as an asynchronous stream using the specified <see cref="ServiceCategoryQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service categories to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceCategory"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ServiceCategory> StreamAsync(ServiceCategoryQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ServiceCategory>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ServiceCategory"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service category.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ServiceCategory"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ServiceCategory?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ServiceCategory>(new ServiceCategoryQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ServiceCategory"/>.
        /// </summary>
        /// <param name="serviceCategory">The service category to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ServiceCategory"/>.</returns>
        public async Task<ServiceCategory> CreateAsync(ServiceCategory serviceCategory, CancellationToken ct = default)
        {
            return await PostItemAsync(serviceCategory, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ServiceCategory"/>.
        /// </summary>
        /// <param name="serviceCategory">The service category to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ServiceCategory"/>.</returns>
        public async Task<ServiceCategory> UpdateAsync(ServiceCategory serviceCategory, CancellationToken ct = default)
        {
            return await PatchItemAsync(serviceCategory, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a <see cref="ServiceCategory"/>.
        /// </summary>
            /// <param name="serviceCategoryId">The identifier of the service category to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long serviceCategoryId, CancellationToken ct = default)
            {
                return await DeleteItemAsync(serviceCategoryId, ct).ConfigureAwait(false);
            }

        /// <summary>
        /// Delete a <see cref="ServiceCategory"/>.
        /// </summary>
        /// <param name="serviceCategory">The service category to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ServiceCategory"/>.</returns>
        public async Task<bool> DeleteAsync(ServiceCategory serviceCategory, CancellationToken ct = default)
        {
            if (serviceCategory is null)
                throw new ArgumentNullException(nameof(serviceCategory));

            return await DeleteAsync(serviceCategory.Id, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ServiceCategory"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ServiceCategoryClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ServiceCategoryClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceCategoryId">The unique identifier of the service category for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long serviceCategoryId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(serviceCategoryId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceCategory">The service category for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ServiceCategory serviceCategory, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (serviceCategory is null)
                    throw new ArgumentNullException(nameof(serviceCategory));

                return await GetAsync(serviceCategory.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceCategoryId">The unique identifier of the service category for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long serviceCategoryId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(serviceCategoryId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service category using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceCategory">The service category for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ServiceCategory serviceCategory, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (serviceCategory is null)
                    throw new ArgumentNullException(nameof(serviceCategory));

                return StreamAsync(serviceCategory.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Service"/> records related to an <see cref="ServiceCategory"/>.
        /// </summary>
        public sealed class ServicesClient
        {
            private readonly ServiceCategoryClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServicesClient"/> class.
            /// </summary>
            internal ServicesClient(ServiceCategoryClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Service"/> records for the specified service category using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="serviceCategoryId">The unique identifier of the service category for which to retrieve the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Service"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Service>> GetAsync(long serviceCategoryId, ServiceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Service>(serviceCategoryId, "services", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Service"/> records for the specified service category using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="serviceCategory">The service category for which to retrieve the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Service"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Service>> GetAsync(ServiceCategory serviceCategory, ServiceQuery query, CancellationToken ct = default)
            {
                if (serviceCategory is null)
                    throw new ArgumentNullException(nameof(serviceCategory));

                return await GetAsync(serviceCategory.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Service"/> items as an asynchronous stream for the specified service category using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="serviceCategoryId">The unique identifier of the service category for which to enumerate the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Service"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Service> StreamAsync(long serviceCategoryId, ServiceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Service>(serviceCategoryId, "services", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Service"/> items as an asynchronous stream for the specified service category using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="serviceCategory">The service category for which to enumerate the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Service"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Service> StreamAsync(ServiceCategory serviceCategory, ServiceQuery query, CancellationToken ct = default)
            {
                if (serviceCategory is null)
                    throw new ArgumentNullException(nameof(serviceCategory));

                return StreamAsync(serviceCategory.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategoryId">The identifier of the service category.</param>
            /// <param name="serviceId">The identifier of the service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceCategoryId, long serviceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceCategoryId, "services", serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategoryId">The identifier of the service category.</param>
            /// <param name="service">The service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceCategoryId, Service service, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await AddAsync(serviceCategoryId, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategory">The service category from which the service is removed.</param>
            /// <param name="service">The service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceCategory serviceCategory, Service service, CancellationToken ct = default)
            {
                if (serviceCategory is null)
                    throw new ArgumentNullException(nameof(serviceCategory));

                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await AddAsync(serviceCategory.Id, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategory">The service category from which the service is removed.</param>
            /// <param name="serviceId">The identifier of the service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceCategory serviceCategory, long serviceId, CancellationToken ct = default)
            {
                if (serviceCategory is null)
                    throw new ArgumentNullException(nameof(serviceCategory));

                return await AddAsync(serviceCategory.Id, serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategoryId">The identifier of the service category.</param>
            /// <param name="serviceId">The identifier of the service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceCategoryId, long serviceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceCategoryId, "services", serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategoryId">The identifier of the service category.</param>
            /// <param name="service">The service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceCategoryId, Service service, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await RemoveAsync(serviceCategoryId, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategory">The service category from which the service is removed.</param>
            /// <param name="service">The service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceCategory serviceCategory, Service service, CancellationToken ct = default)
            {
                if (serviceCategory is null)
                    throw new ArgumentNullException(nameof(serviceCategory));

                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await RemoveAsync(serviceCategory.Id, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategory">The service category from which the service is removed.</param>
            /// <param name="serviceId">The identifier of the service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceCategory serviceCategory, long serviceId, CancellationToken ct = default)
            {
                if (serviceCategory is null)
                    throw new ArgumentNullException(nameof(serviceCategory));

                return await RemoveAsync(serviceCategory.Id, serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all services associated with a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategoryId">The identifier of the service category.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceCategoryId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceCategoryId, "services", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all services associated with a <see cref="ServiceCategory"/>.
            /// </summary>
            /// <param name="serviceCategory">The service category from which all services are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceCategory serviceCategory, CancellationToken ct = default)
            {
                if (serviceCategory is null)
                    throw new ArgumentNullException(nameof(serviceCategory));

                return await RemoveAllAsync(serviceCategory.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
