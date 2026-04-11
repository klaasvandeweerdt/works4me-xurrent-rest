using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Service"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/services/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ServiceClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Service"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="RequestTemplate"/> records related to an <see cref="Service"/>.
        /// </summary>
        public RequestTemplatesClient RequestTemplates { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Risk"/> records related to an <see cref="Service"/>.
        /// </summary>
        public RisksClient Risks { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="Service"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="Service"/>.
        /// </summary>
        public ServiceLevelAgreementsClient ServiceLevelAgreements { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceOffering"/> records related to an <see cref="Service"/>.
        /// </summary>
        public ServiceOfferingsClient ServiceOfferings { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="WorkflowTemplate"/> records related to an <see cref="Service"/>.
        /// </summary>
        public WorkflowTemplatesClient WorkflowTemplates { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClient"/> class.
        /// </summary>
        internal ServiceClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "services/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            RequestTemplates = new RequestTemplatesClient(this);
            Risks = new RisksClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
            ServiceLevelAgreements = new ServiceLevelAgreementsClient(this);
            ServiceOfferings = new ServiceOfferingsClient(this);
            WorkflowTemplates = new WorkflowTemplatesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Service"/> using the specified <see cref="ServiceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which services to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Service"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Service>> GetAsync(ServiceQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Service>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Service"/> items as an asynchronous stream using the specified <see cref="ServiceQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which services to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Service"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Service> StreamAsync(ServiceQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Service>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Service"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Service"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Service?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Service>(new ServiceQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Service"/>.
        /// </summary>
        /// <param name="service">The service to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Service"/>.</returns>
        public async Task<Service> CreateAsync(Service service, CancellationToken ct = default)
        {
            return await PostItemAsync(service, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Service"/>.
        /// </summary>
        /// <param name="service">The service to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Service"/>.</returns>
        public async Task<Service> UpdateAsync(Service service, CancellationToken ct = default)
        {
            return await PatchItemAsync(service, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Service"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ServiceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ServiceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long serviceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(serviceId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Service service, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await GetAsync(service.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long serviceId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(serviceId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Service service, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return StreamAsync(service.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="RequestTemplate"/> records related to an <see cref="Service"/>.
        /// </summary>
        public sealed class RequestTemplatesClient
        {
            private readonly ServiceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RequestTemplatesClient"/> class.
            /// </summary>
            internal RequestTemplatesClient(ServiceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="RequestTemplate"/> records for the specified service using an <see cref="RequestTemplateQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to retrieve the request templates.</param>
            /// <param name="query">The query that defines which request templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="RequestTemplate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<RequestTemplate>> GetAsync(long serviceId, RequestTemplateQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<RequestTemplate>(serviceId, "request_templates", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="RequestTemplate"/> records for the specified service using an <see cref="RequestTemplateQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to retrieve the request templates.</param>
            /// <param name="query">The query that defines which request templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="RequestTemplate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<RequestTemplate>> GetAsync(Service service, RequestTemplateQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await GetAsync(service.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="RequestTemplate"/> items as an asynchronous stream for the specified service using an <see cref="RequestTemplateQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to enumerate the request templates.</param>
            /// <param name="query">The query that defines which request templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RequestTemplate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<RequestTemplate> StreamAsync(long serviceId, RequestTemplateQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<RequestTemplate>(serviceId, "request_templates", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="RequestTemplate"/> items as an asynchronous stream for the specified service using an <see cref="RequestTemplateQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to enumerate the request templates.</param>
            /// <param name="query">The query that defines which request templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RequestTemplate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<RequestTemplate> StreamAsync(Service service, RequestTemplateQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return StreamAsync(service.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Risk"/> records related to an <see cref="Service"/>.
        /// </summary>
        public sealed class RisksClient
        {
            private readonly ServiceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RisksClient"/> class.
            /// </summary>
            internal RisksClient(ServiceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Risk"/> records for the specified service using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to retrieve the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Risk"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Risk>> GetAsync(long serviceId, RiskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Risk>(serviceId, "risks", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Risk"/> records for the specified service using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to retrieve the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Risk"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Risk>> GetAsync(Service service, RiskQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await GetAsync(service.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Risk"/> items as an asynchronous stream for the specified service using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to enumerate the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Risk"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Risk> StreamAsync(long serviceId, RiskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Risk>(serviceId, "risks", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Risk"/> items as an asynchronous stream for the specified service using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to enumerate the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Risk"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Risk> StreamAsync(Service service, RiskQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return StreamAsync(service.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="Service"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly ServiceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(ServiceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified service using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long serviceId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(serviceId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified service using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(Service service, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await GetAsync(service.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified service using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long serviceId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(serviceId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified service using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(Service service, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return StreamAsync(service.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="Service"/>.
        /// </summary>
        public sealed class ServiceLevelAgreementsClient
        {
            private readonly ServiceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceLevelAgreementsClient"/> class.
            /// </summary>
            internal ServiceLevelAgreementsClient(ServiceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified service using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(long serviceId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceLevelAgreement>(serviceId, "slas", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified service using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(Service service, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await GetAsync(service.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified service using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(long serviceId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceLevelAgreement>(serviceId, "slas", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified service using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(Service service, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return StreamAsync(service.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceOffering"/> records related to an <see cref="Service"/>.
        /// </summary>
        public sealed class ServiceOfferingsClient
        {
            private readonly ServiceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceOfferingsClient"/> class.
            /// </summary>
            internal ServiceOfferingsClient(ServiceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceOffering"/> records for the specified service using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to retrieve the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceOffering>> GetAsync(long serviceId, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceOffering>(serviceId, "service_offerings", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceOffering"/> records for the specified service using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to retrieve the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceOffering>> GetAsync(Service service, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await GetAsync(service.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceOffering"/> items as an asynchronous stream for the specified service using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to enumerate the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceOffering> StreamAsync(long serviceId, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceOffering>(serviceId, "service_offerings", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceOffering"/> items as an asynchronous stream for the specified service using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to enumerate the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceOffering> StreamAsync(Service service, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return StreamAsync(service.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="WorkflowTemplate"/> records related to an <see cref="Service"/>.
        /// </summary>
        public sealed class WorkflowTemplatesClient
        {
            private readonly ServiceClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="WorkflowTemplatesClient"/> class.
            /// </summary>
            internal WorkflowTemplatesClient(ServiceClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTemplate"/> records for the specified service using an <see cref="WorkflowTemplateQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to retrieve the workflow templates.</param>
            /// <param name="query">The query that defines which workflow templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTemplate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTemplate>> GetAsync(long serviceId, WorkflowTemplateQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<WorkflowTemplate>(serviceId, "workflow_templates", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="WorkflowTemplate"/> records for the specified service using an <see cref="WorkflowTemplateQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to retrieve the workflow templates.</param>
            /// <param name="query">The query that defines which workflow templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="WorkflowTemplate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<WorkflowTemplate>> GetAsync(Service service, WorkflowTemplateQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await GetAsync(service.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTemplate"/> items as an asynchronous stream for the specified service using an <see cref="WorkflowTemplateQuery"/>.
            /// </summary>
            /// <param name="serviceId">The unique identifier of the service for which to enumerate the workflow templates.</param>
            /// <param name="query">The query that defines which workflow templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTemplate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTemplate> StreamAsync(long serviceId, WorkflowTemplateQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<WorkflowTemplate>(serviceId, "workflow_templates", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="WorkflowTemplate"/> items as an asynchronous stream for the specified service using an <see cref="WorkflowTemplateQuery"/>.
            /// </summary>
            /// <param name="service">The service for which to enumerate the workflow templates.</param>
            /// <param name="query">The query that defines which workflow templates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="WorkflowTemplate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<WorkflowTemplate> StreamAsync(Service service, WorkflowTemplateQuery query, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return StreamAsync(service.Id, query, ct);
            }
        }
    }
}
