using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ServiceLevelAgreement"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/service_level_agreements/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed partial class ServiceLevelAgreementClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SlaCoverageGroup"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public CoverageGroupsClient CoverageGroups { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Person"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public CustomerRepresentativesClient CustomerRepresentatives { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="EffortClassRateIDs"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public EffortClassRateIDsClient EffortClassRateIDs { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Organization"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public OrganizationsClient Organizations { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Person"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public PeopleClient People { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="RfcTypeActivityID"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public RfcTypeActivityIDsClient RfcTypeActivityIDs { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ParentServiceInstance"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Site"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public SitesClient Sites { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SkillPool"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public SkillPoolsClient SkillPools { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="StandardServiceRequestActivityID"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public StandardServiceRequestActivityIDsClient StandardServiceRequestActivityIDs { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLevelAgreementClient"/> class.
        /// </summary>
        internal ServiceLevelAgreementClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "slas/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            CoverageGroups = new CoverageGroupsClient(this);
            CustomerRepresentatives = new CustomerRepresentativesClient(this);
            EffortClassRateIDs = new EffortClassRateIDsClient(this);
            Organizations = new OrganizationsClient(this);
            People = new PeopleClient(this);
            RfcTypeActivityIDs = new RfcTypeActivityIDsClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
            Sites = new SitesClient(this);
            SkillPools = new SkillPoolsClient(this);
            StandardServiceRequestActivityIDs = new StandardServiceRequestActivityIDsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ServiceLevelAgreement"/> using the specified <see cref="ServiceLevelAgreementQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service level agreements to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(ServiceLevelAgreementQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ServiceLevelAgreement>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream using the specified <see cref="ServiceLevelAgreementQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service level agreements to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(ServiceLevelAgreementQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ServiceLevelAgreement>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ServiceLevelAgreement"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service level agreement.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ServiceLevelAgreement"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ServiceLevelAgreement?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ServiceLevelAgreement>(new ServiceLevelAgreementQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ServiceLevelAgreement"/>.</returns>
        public async Task<ServiceLevelAgreement> CreateAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
        {
            return await PostItemAsync(serviceLevelAgreement, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        /// <param name="serviceLevelAgreement">The service level agreement to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ServiceLevelAgreement"/>.</returns>
        public async Task<ServiceLevelAgreement> UpdateAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
        {
            return await PatchItemAsync(serviceLevelAgreement, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service level agreement using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long serviceLevelAgreementId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(serviceLevelAgreementId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service level agreement using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service level agreement using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long serviceLevelAgreementId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(serviceLevelAgreementId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service level agreement using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SlaCoverageGroup"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class CoverageGroupsClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="CoverageGroupsClient"/> class.
            /// </summary>
            internal CoverageGroupsClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SlaCoverageGroup"/> records for the specified service level agreement using an <see cref="SlaCoverageGroupQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the coverage groups.</param>
            /// <param name="query">The query that defines which coverage groups to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SlaCoverageGroup"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SlaCoverageGroup>> GetAsync(long serviceLevelAgreementId, SlaCoverageGroupQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SlaCoverageGroup>(serviceLevelAgreementId, "coverage_groups", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SlaCoverageGroup"/> records for the specified service level agreement using an <see cref="SlaCoverageGroupQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the coverage groups.</param>
            /// <param name="query">The query that defines which coverage groups to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SlaCoverageGroup"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SlaCoverageGroup>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, SlaCoverageGroupQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SlaCoverageGroup"/> items as an asynchronous stream for the specified service level agreement using an <see cref="SlaCoverageGroupQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the coverage groups.</param>
            /// <param name="query">The query that defines which coverage groups to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SlaCoverageGroup"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SlaCoverageGroup> StreamAsync(long serviceLevelAgreementId, SlaCoverageGroupQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SlaCoverageGroup>(serviceLevelAgreementId, "coverage_groups", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SlaCoverageGroup"/> items as an asynchronous stream for the specified service level agreement using an <see cref="SlaCoverageGroupQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the coverage groups.</param>
            /// <param name="query">The query that defines which coverage groups to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SlaCoverageGroup"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SlaCoverageGroup> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, SlaCoverageGroupQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="SlaCoverageGroup"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="slaCoverageGroupId">The identifier of the service level agreement coverage group to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, long slaCoverageGroupId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceLevelAgreementId, "coverage_groups", slaCoverageGroupId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SlaCoverageGroup"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="slaCoverageGroup">The service level agreement coverage group to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, SlaCoverageGroup slaCoverageGroup, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return await AddAsync(serviceLevelAgreementId, slaCoverageGroup.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SlaCoverageGroup"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the service level agreement coverage group is removed.</param>
            /// <param name="slaCoverageGroup">The service level agreement coverage group to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, SlaCoverageGroup slaCoverageGroup, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return await AddAsync(serviceLevelAgreement.Id, slaCoverageGroup.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SlaCoverageGroup"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the service level agreement coverage group is removed.</param>
            /// <param name="slaCoverageGroupId">The identifier of the service level agreement coverage group to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, long slaCoverageGroupId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(serviceLevelAgreement.Id, slaCoverageGroupId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SlaCoverageGroup"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="slaCoverageGroupId">The identifier of the service level agreement coverage group to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, long slaCoverageGroupId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "coverage_groups", slaCoverageGroupId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SlaCoverageGroup"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="slaCoverageGroup">The service level agreement coverage group to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, SlaCoverageGroup slaCoverageGroup, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return await RemoveAsync(serviceLevelAgreementId, slaCoverageGroup.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SlaCoverageGroup"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the service level agreement coverage group is removed.</param>
            /// <param name="slaCoverageGroup">The service level agreement coverage group to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, SlaCoverageGroup slaCoverageGroup, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return await RemoveAsync(serviceLevelAgreement.Id, slaCoverageGroup.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SlaCoverageGroup"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the service level agreement coverage group is removed.</param>
            /// <param name="slaCoverageGroupId">The identifier of the service level agreement coverage group to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, long slaCoverageGroupId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(serviceLevelAgreement.Id, slaCoverageGroupId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all coverage groups associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "coverage_groups", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all coverage groups associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all coverage groups are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Person"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class CustomerRepresentativesClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomerRepresentativesClient"/> class.
            /// </summary>
            internal CustomerRepresentativesClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified service level agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the customer representatives.</param>
            /// <param name="query">The query that defines which customer representatives to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(long serviceLevelAgreementId, PersonQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Person>(serviceLevelAgreementId, "customer_representatives", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified service level agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the customer representatives.</param>
            /// <param name="query">The query that defines which customer representatives to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, PersonQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified service level agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the customer representatives.</param>
            /// <param name="query">The query that defines which customer representatives to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(long serviceLevelAgreementId, PersonQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Person>(serviceLevelAgreementId, "customer_representatives", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified service level agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the customer representatives.</param>
            /// <param name="query">The query that defines which customer representatives to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, PersonQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, long personId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceLevelAgreementId, "customer_representatives", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(serviceLevelAgreementId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the person is removed.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, Person person, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(serviceLevelAgreement.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, long personId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(serviceLevelAgreement.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, long personId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "customer_representatives", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(serviceLevelAgreementId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the person is removed.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, Person person, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(serviceLevelAgreement.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, long personId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(serviceLevelAgreement.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all customer representatives associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "customer_representatives", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all customer representatives associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all customer representatives are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="EffortClassRateIDs"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class EffortClassRateIDsClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="EffortClassRateIDsClient"/> class.
            /// </summary>
            internal EffortClassRateIDsClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="EffortClassRateIDs"/> records for the specified service level agreement using an <see cref="EffortClassRateIDsQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the effort class rate i ds.</param>
            /// <param name="query">The query that defines which effort class rate i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="EffortClassRateIDs"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<EffortClassRateIDs>> GetAsync(long serviceLevelAgreementId, EffortClassRateIDsQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<EffortClassRateIDs>(serviceLevelAgreementId, "effort_class_rateIDs", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="EffortClassRateIDs"/> records for the specified service level agreement using an <see cref="EffortClassRateIDsQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the effort class rate i ds.</param>
            /// <param name="query">The query that defines which effort class rate i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="EffortClassRateIDs"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<EffortClassRateIDs>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, EffortClassRateIDsQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="EffortClassRateIDs"/> items as an asynchronous stream for the specified service level agreement using an <see cref="EffortClassRateIDsQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the effort class rate i ds.</param>
            /// <param name="query">The query that defines which effort class rate i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="EffortClassRateIDs"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<EffortClassRateIDs> StreamAsync(long serviceLevelAgreementId, EffortClassRateIDsQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<EffortClassRateIDs>(serviceLevelAgreementId, "effort_class_rateIDs", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="EffortClassRateIDs"/> items as an asynchronous stream for the specified service level agreement using an <see cref="EffortClassRateIDsQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the effort class rate i ds.</param>
            /// <param name="query">The query that defines which effort class rate i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="EffortClassRateIDs"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<EffortClassRateIDs> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, EffortClassRateIDsQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="EffortClassRateIDs"/> by its unique identifier for the specified service level agreement.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement.</param>
            /// <param name="effortClassRateIDsId">The unique identifier of the effort class rate i ds.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="EffortClassRateIDs"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<EffortClassRateIDs?> GetAsync(long serviceLevelAgreementId, long effortClassRateIDsId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<EffortClassRateIDs>(serviceLevelAgreementId, "effort_class_rateIDs", new EffortClassRateIDsQuery().WithId(effortClassRateIDsId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="EffortClassRateIDs"/> record for the specified service level agreement.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the effort class rate i ds.</param>
            /// <param name="effortClassRateIDsId">The unique identifier of the effort class rate i ds.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="EffortClassRateIDs"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<EffortClassRateIDs?> GetAsync(ServiceLevelAgreement serviceLevelAgreement, long effortClassRateIDsId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, effortClassRateIDsId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="EffortClassRateIDs"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="effortClassRateIDs">The effort class rate i ds to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="EffortClassRateIDs"/>.</returns>
            public async Task<EffortClassRateIDs> CreateAsync(long serviceLevelAgreementId, EffortClassRateIDs effortClassRateIDs, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceLevelAgreementId, "effort_class_rateIDs", effortClassRateIDs, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="EffortClassRateIDs"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement to which the effort class rate i ds is added.</param>
            /// <param name="effortClassRateIDs">The effort class rate i ds to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="EffortClassRateIDs"/>.</returns>
            public async Task<EffortClassRateIDs> CreateAsync(ServiceLevelAgreement serviceLevelAgreement, EffortClassRateIDs effortClassRateIDs, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await CreateAsync(serviceLevelAgreement.Id, effortClassRateIDs, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="EffortClassRateIDs"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="effortClassRateIDs">The effort class rate i ds to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="EffortClassRateIDs"/>.</returns>
            public async Task<EffortClassRateIDs> UpdateAsync(long serviceLevelAgreementId, EffortClassRateIDs effortClassRateIDs, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(serviceLevelAgreementId, "effort_class_rateIDs", effortClassRateIDs, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="EffortClassRateIDs"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement with which the effort class rate i ds is associated.</param>
            /// <param name="effortClassRateIDs">The effort class rate i ds to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="EffortClassRateIDs"/>.</returns>
            public async Task<EffortClassRateIDs> UpdateAsync(ServiceLevelAgreement serviceLevelAgreement, EffortClassRateIDs effortClassRateIDs, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await UpdateAsync(serviceLevelAgreement.Id, effortClassRateIDs, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="EffortClassRateIDs"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="effortClassRateIDsId">The identifier of the effort class rate i ds to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long serviceLevelAgreementId, long effortClassRateIDsId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "effort_class_rateIDs", effortClassRateIDsId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="EffortClassRateIDs"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="effortClassRateIDs">The effort class rate i ds to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long serviceLevelAgreementId, EffortClassRateIDs effortClassRateIDs, CancellationToken ct = default)
            {
                if (effortClassRateIDs is null)
                    throw new ArgumentNullException(nameof(effortClassRateIDs));

                return await DeleteAsync(serviceLevelAgreementId, effortClassRateIDs.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="EffortClassRateIDs"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the effort class rate i ds is removed.</param>
            /// <param name="effortClassRateIDs">The effort class rate i ds to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ServiceLevelAgreement serviceLevelAgreement, EffortClassRateIDs effortClassRateIDs, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (effortClassRateIDs is null)
                    throw new ArgumentNullException(nameof(effortClassRateIDs));

                return await DeleteAsync(serviceLevelAgreement.Id, effortClassRateIDs.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="EffortClassRateIDs"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the effort class rate i ds is removed.</param>
            /// <param name="effortClassRateIDsId">The identifier of the effort class rate i ds to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ServiceLevelAgreement serviceLevelAgreement, long effortClassRateIDsId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await DeleteAsync(serviceLevelAgreement.Id, effortClassRateIDsId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all effort class rate i ds associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "effort_class_rateIDs", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all effort class rate i ds associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all effort class rate i ds are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await DeleteAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Organization"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class OrganizationsClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="OrganizationsClient"/> class.
            /// </summary>
            internal OrganizationsClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified service level agreement using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(long serviceLevelAgreementId, OrganizationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Organization>(serviceLevelAgreementId, "organizations", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified service level agreement using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, OrganizationQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified service level agreement using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(long serviceLevelAgreementId, OrganizationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Organization>(serviceLevelAgreementId, "organizations", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified service level agreement using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, OrganizationQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, long organizationId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceLevelAgreementId, "organizations", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(serviceLevelAgreementId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the organization is removed.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, Organization organization, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(serviceLevelAgreement.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, long organizationId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(serviceLevelAgreement.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, long organizationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "organizations", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(serviceLevelAgreementId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the organization is removed.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, Organization organization, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(serviceLevelAgreement.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, long organizationId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(serviceLevelAgreement.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all organizations associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "organizations", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all organizations associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all organizations are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Person"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class PeopleClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PeopleClient"/> class.
            /// </summary>
            internal PeopleClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified service level agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(long serviceLevelAgreementId, PersonQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Person>(serviceLevelAgreementId, "people", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified service level agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, PersonQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified service level agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(long serviceLevelAgreementId, PersonQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Person>(serviceLevelAgreementId, "people", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified service level agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, PersonQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, long personId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceLevelAgreementId, "people", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(serviceLevelAgreementId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the person is removed.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, Person person, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(serviceLevelAgreement.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, long personId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(serviceLevelAgreement.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, long personId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "people", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(serviceLevelAgreementId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the person is removed.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, Person person, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(serviceLevelAgreement.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, long personId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(serviceLevelAgreement.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all people associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "people", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all people associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all people are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="RfcTypeActivityID"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed partial class RfcTypeActivityIDsClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RfcTypeActivityIDsClient"/> class.
            /// </summary>
            internal RfcTypeActivityIDsClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="RfcTypeActivityID"/> records for the specified service level agreement using an <see cref="RfcTypeActivityIDQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the rfc type activity i ds.</param>
            /// <param name="query">The query that defines which rfc type activity i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="RfcTypeActivityID"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<RfcTypeActivityID>> GetAsync(long serviceLevelAgreementId, RfcTypeActivityIDQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<RfcTypeActivityID>(serviceLevelAgreementId, "rfc_type_activityIDs", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="RfcTypeActivityID"/> records for the specified service level agreement using an <see cref="RfcTypeActivityIDQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the rfc type activity i ds.</param>
            /// <param name="query">The query that defines which rfc type activity i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="RfcTypeActivityID"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<RfcTypeActivityID>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, RfcTypeActivityIDQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="RfcTypeActivityID"/> items as an asynchronous stream for the specified service level agreement using an <see cref="RfcTypeActivityIDQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the rfc type activity i ds.</param>
            /// <param name="query">The query that defines which rfc type activity i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RfcTypeActivityID"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<RfcTypeActivityID> StreamAsync(long serviceLevelAgreementId, RfcTypeActivityIDQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<RfcTypeActivityID>(serviceLevelAgreementId, "rfc_type_activityIDs", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="RfcTypeActivityID"/> items as an asynchronous stream for the specified service level agreement using an <see cref="RfcTypeActivityIDQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the rfc type activity i ds.</param>
            /// <param name="query">The query that defines which rfc type activity i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RfcTypeActivityID"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<RfcTypeActivityID> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, RfcTypeActivityIDQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Remove a <see cref="RfcTypeActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="rfcTypeActivityIDId">The identifier of the rfc type activity identifier to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, long rfcTypeActivityIDId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "rfc_type_activityIDs", rfcTypeActivityIDId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="RfcTypeActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="rfcTypeActivityID">The rfc type activity identifier to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, RfcTypeActivityID rfcTypeActivityID, CancellationToken ct = default)
            {
                if (rfcTypeActivityID is null)
                    throw new ArgumentNullException(nameof(rfcTypeActivityID));

                return await RemoveAsync(serviceLevelAgreementId, rfcTypeActivityID.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="RfcTypeActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the rfc type activity identifier is removed.</param>
            /// <param name="rfcTypeActivityID">The rfc type activity identifier to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, RfcTypeActivityID rfcTypeActivityID, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (rfcTypeActivityID is null)
                    throw new ArgumentNullException(nameof(rfcTypeActivityID));

                return await RemoveAsync(serviceLevelAgreement.Id, rfcTypeActivityID.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="RfcTypeActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the rfc type activity identifier is removed.</param>
            /// <param name="rfcTypeActivityIDId">The identifier of the rfc type activity identifier to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, long rfcTypeActivityIDId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(serviceLevelAgreement.Id, rfcTypeActivityIDId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all rfc type activity i ds associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "rfc_type_activityIDs", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all rfc type activity i ds associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all rfc type activity i ds are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ParentServiceInstance"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ParentServiceInstance"/> records for the specified service level agreement using an <see cref="ParentServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ParentServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ParentServiceInstance>> GetAsync(long serviceLevelAgreementId, ParentServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ParentServiceInstance>(serviceLevelAgreementId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ParentServiceInstance"/> records for the specified service level agreement using an <see cref="ParentServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ParentServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ParentServiceInstance>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, ParentServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ParentServiceInstance"/> items as an asynchronous stream for the specified service level agreement using an <see cref="ParentServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ParentServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ParentServiceInstance> StreamAsync(long serviceLevelAgreementId, ParentServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ParentServiceInstance>(serviceLevelAgreementId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ParentServiceInstance"/> items as an asynchronous stream for the specified service level agreement using an <see cref="ParentServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ParentServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ParentServiceInstance> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, ParentServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ParentServiceInstance"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="parentServiceInstanceId">The identifier of the parent service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, long parentServiceInstanceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceLevelAgreementId, "service_instances", parentServiceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ParentServiceInstance"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="parentServiceInstance">The parent service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, ParentServiceInstance parentServiceInstance, CancellationToken ct = default)
            {
                if (parentServiceInstance is null)
                    throw new ArgumentNullException(nameof(parentServiceInstance));

                return await AddAsync(serviceLevelAgreementId, parentServiceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ParentServiceInstance"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the parent service instance is removed.</param>
            /// <param name="parentServiceInstance">The parent service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, ParentServiceInstance parentServiceInstance, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (parentServiceInstance is null)
                    throw new ArgumentNullException(nameof(parentServiceInstance));

                return await AddAsync(serviceLevelAgreement.Id, parentServiceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ParentServiceInstance"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the parent service instance is removed.</param>
            /// <param name="parentServiceInstanceId">The identifier of the parent service instance to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, long parentServiceInstanceId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(serviceLevelAgreement.Id, parentServiceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ParentServiceInstance"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="parentServiceInstanceId">The identifier of the parent service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, long parentServiceInstanceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "service_instances", parentServiceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ParentServiceInstance"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="parentServiceInstance">The parent service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, ParentServiceInstance parentServiceInstance, CancellationToken ct = default)
            {
                if (parentServiceInstance is null)
                    throw new ArgumentNullException(nameof(parentServiceInstance));

                return await RemoveAsync(serviceLevelAgreementId, parentServiceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ParentServiceInstance"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the parent service instance is removed.</param>
            /// <param name="parentServiceInstance">The parent service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, ParentServiceInstance parentServiceInstance, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (parentServiceInstance is null)
                    throw new ArgumentNullException(nameof(parentServiceInstance));

                return await RemoveAsync(serviceLevelAgreement.Id, parentServiceInstance.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ParentServiceInstance"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the parent service instance is removed.</param>
            /// <param name="parentServiceInstanceId">The identifier of the parent service instance to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, long parentServiceInstanceId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(serviceLevelAgreement.Id, parentServiceInstanceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "service_instances", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service instances associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all service instances are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Site"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class SitesClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SitesClient"/> class.
            /// </summary>
            internal SitesClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Site"/> records for the specified service level agreement using an <see cref="SiteQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the sites.</param>
            /// <param name="query">The query that defines which sites to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Site"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Site>> GetAsync(long serviceLevelAgreementId, SiteQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Site>(serviceLevelAgreementId, "sites", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Site"/> records for the specified service level agreement using an <see cref="SiteQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the sites.</param>
            /// <param name="query">The query that defines which sites to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Site"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Site>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, SiteQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Site"/> items as an asynchronous stream for the specified service level agreement using an <see cref="SiteQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the sites.</param>
            /// <param name="query">The query that defines which sites to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Site"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Site> StreamAsync(long serviceLevelAgreementId, SiteQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Site>(serviceLevelAgreementId, "sites", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Site"/> items as an asynchronous stream for the specified service level agreement using an <see cref="SiteQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the sites.</param>
            /// <param name="query">The query that defines which sites to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Site"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Site> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, SiteQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Site"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="siteId">The identifier of the site to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, long siteId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceLevelAgreementId, "sites", siteId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Site"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="site">The site to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, Site site, CancellationToken ct = default)
            {
                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return await AddAsync(serviceLevelAgreementId, site.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Site"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the site is removed.</param>
            /// <param name="site">The site to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, Site site, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return await AddAsync(serviceLevelAgreement.Id, site.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Site"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the site is removed.</param>
            /// <param name="siteId">The identifier of the site to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, long siteId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(serviceLevelAgreement.Id, siteId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Site"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="siteId">The identifier of the site to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, long siteId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "sites", siteId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Site"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="site">The site to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, Site site, CancellationToken ct = default)
            {
                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return await RemoveAsync(serviceLevelAgreementId, site.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Site"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the site is removed.</param>
            /// <param name="site">The site to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, Site site, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (site is null)
                    throw new ArgumentNullException(nameof(site));

                return await RemoveAsync(serviceLevelAgreement.Id, site.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Site"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the site is removed.</param>
            /// <param name="siteId">The identifier of the site to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, long siteId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(serviceLevelAgreement.Id, siteId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all sites associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "sites", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all sites associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all sites are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SkillPool"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class SkillPoolsClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SkillPoolsClient"/> class.
            /// </summary>
            internal SkillPoolsClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SkillPool"/> records for the specified service level agreement using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SkillPool"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SkillPool>> GetAsync(long serviceLevelAgreementId, SkillPoolQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SkillPool>(serviceLevelAgreementId, "skill_pools", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SkillPool"/> records for the specified service level agreement using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SkillPool"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SkillPool>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, SkillPoolQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SkillPool"/> items as an asynchronous stream for the specified service level agreement using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SkillPool"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SkillPool> StreamAsync(long serviceLevelAgreementId, SkillPoolQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SkillPool>(serviceLevelAgreementId, "skill_pools", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SkillPool"/> items as an asynchronous stream for the specified service level agreement using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SkillPool"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SkillPool> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, SkillPoolQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, long skillPoolId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceLevelAgreementId, "skill_pools", skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="skillPool">The skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long serviceLevelAgreementId, SkillPool skillPool, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await AddAsync(serviceLevelAgreementId, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the skill pool is removed.</param>
            /// <param name="skillPool">The skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, SkillPool skillPool, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await AddAsync(serviceLevelAgreement.Id, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the skill pool is removed.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(ServiceLevelAgreement serviceLevelAgreement, long skillPoolId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(serviceLevelAgreement.Id, skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, long skillPoolId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "skill_pools", skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="skillPool">The skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceLevelAgreementId, SkillPool skillPool, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAsync(serviceLevelAgreementId, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the skill pool is removed.</param>
            /// <param name="skillPool">The skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, SkillPool skillPool, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAsync(serviceLevelAgreement.Id, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the skill pool is removed.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceLevelAgreement serviceLevelAgreement, long skillPoolId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(serviceLevelAgreement.Id, skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all skill pools associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "skill_pools", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all skill pools associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all skill pools are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="StandardServiceRequestActivityID"/> records related to an <see cref="ServiceLevelAgreement"/>.
        /// </summary>
        public sealed class StandardServiceRequestActivityIDsClient
        {
            private readonly ServiceLevelAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="StandardServiceRequestActivityIDsClient"/> class.
            /// </summary>
            internal StandardServiceRequestActivityIDsClient(ServiceLevelAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="StandardServiceRequestActivityID"/> records for the specified service level agreement using an <see cref="StandardServiceRequestActivityIDQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to retrieve the standard service request activity i ds.</param>
            /// <param name="query">The query that defines which standard service request activity i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="StandardServiceRequestActivityID"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<StandardServiceRequestActivityID>> GetAsync(long serviceLevelAgreementId, StandardServiceRequestActivityIDQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<StandardServiceRequestActivityID>(serviceLevelAgreementId, "standard_service_request_activityIDs", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="StandardServiceRequestActivityID"/> records for the specified service level agreement using an <see cref="StandardServiceRequestActivityIDQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the standard service request activity i ds.</param>
            /// <param name="query">The query that defines which standard service request activity i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="StandardServiceRequestActivityID"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<StandardServiceRequestActivityID>> GetAsync(ServiceLevelAgreement serviceLevelAgreement, StandardServiceRequestActivityIDQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="StandardServiceRequestActivityID"/> items as an asynchronous stream for the specified service level agreement using an <see cref="StandardServiceRequestActivityIDQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement for which to enumerate the standard service request activity i ds.</param>
            /// <param name="query">The query that defines which standard service request activity i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="StandardServiceRequestActivityID"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<StandardServiceRequestActivityID> StreamAsync(long serviceLevelAgreementId, StandardServiceRequestActivityIDQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<StandardServiceRequestActivityID>(serviceLevelAgreementId, "standard_service_request_activityIDs", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="StandardServiceRequestActivityID"/> items as an asynchronous stream for the specified service level agreement using an <see cref="StandardServiceRequestActivityIDQuery"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to enumerate the standard service request activity i ds.</param>
            /// <param name="query">The query that defines which standard service request activity i ds to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="StandardServiceRequestActivityID"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<StandardServiceRequestActivityID> StreamAsync(ServiceLevelAgreement serviceLevelAgreement, StandardServiceRequestActivityIDQuery query, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return StreamAsync(serviceLevelAgreement.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="StandardServiceRequestActivityID"/> by its unique identifier for the specified service level agreement.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The unique identifier of the service level agreement.</param>
            /// <param name="standardServiceRequestActivityIDId">The unique identifier of the standard service request activity identifier.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="StandardServiceRequestActivityID"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<StandardServiceRequestActivityID?> GetAsync(long serviceLevelAgreementId, long standardServiceRequestActivityIDId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<StandardServiceRequestActivityID>(serviceLevelAgreementId, "standard_service_request_activityIDs", new StandardServiceRequestActivityIDQuery().WithId(standardServiceRequestActivityIDId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="StandardServiceRequestActivityID"/> record for the specified service level agreement.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement for which to retrieve the standard service request activity identifier.</param>
            /// <param name="standardServiceRequestActivityIDId">The unique identifier of the standard service request activity identifier.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="StandardServiceRequestActivityID"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<StandardServiceRequestActivityID?> GetAsync(ServiceLevelAgreement serviceLevelAgreement, long standardServiceRequestActivityIDId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await GetAsync(serviceLevelAgreement.Id, standardServiceRequestActivityIDId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="StandardServiceRequestActivityID"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="standardServiceRequestActivityID">The standard service request activity identifier to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="StandardServiceRequestActivityID"/>.</returns>
            public async Task<StandardServiceRequestActivityID> CreateAsync(long serviceLevelAgreementId, StandardServiceRequestActivityID standardServiceRequestActivityID, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceLevelAgreementId, "standard_service_request_activityIDs", standardServiceRequestActivityID, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="StandardServiceRequestActivityID"/> to a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement to which the standard service request activity identifier is added.</param>
            /// <param name="standardServiceRequestActivityID">The standard service request activity identifier to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="StandardServiceRequestActivityID"/>.</returns>
            public async Task<StandardServiceRequestActivityID> CreateAsync(ServiceLevelAgreement serviceLevelAgreement, StandardServiceRequestActivityID standardServiceRequestActivityID, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await CreateAsync(serviceLevelAgreement.Id, standardServiceRequestActivityID, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="StandardServiceRequestActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="standardServiceRequestActivityID">The standard service request activity identifier to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="StandardServiceRequestActivityID"/>.</returns>
            public async Task<StandardServiceRequestActivityID> UpdateAsync(long serviceLevelAgreementId, StandardServiceRequestActivityID standardServiceRequestActivityID, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(serviceLevelAgreementId, "standard_service_request_activityIDs", standardServiceRequestActivityID, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="StandardServiceRequestActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement with which the standard service request activity identifier is associated.</param>
            /// <param name="standardServiceRequestActivityID">The standard service request activity identifier to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="StandardServiceRequestActivityID"/>.</returns>
            public async Task<StandardServiceRequestActivityID> UpdateAsync(ServiceLevelAgreement serviceLevelAgreement, StandardServiceRequestActivityID standardServiceRequestActivityID, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await UpdateAsync(serviceLevelAgreement.Id, standardServiceRequestActivityID, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="StandardServiceRequestActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="standardServiceRequestActivityIDId">The identifier of the standard service request activity identifier to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long serviceLevelAgreementId, long standardServiceRequestActivityIDId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceLevelAgreementId, "standard_service_request_activityIDs", standardServiceRequestActivityIDId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="StandardServiceRequestActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="standardServiceRequestActivityID">The standard service request activity identifier to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long serviceLevelAgreementId, StandardServiceRequestActivityID standardServiceRequestActivityID, CancellationToken ct = default)
            {
                if (standardServiceRequestActivityID is null)
                    throw new ArgumentNullException(nameof(standardServiceRequestActivityID));

                return await DeleteAsync(serviceLevelAgreementId, standardServiceRequestActivityID.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="StandardServiceRequestActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the standard service request activity identifier is removed.</param>
            /// <param name="standardServiceRequestActivityID">The standard service request activity identifier to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ServiceLevelAgreement serviceLevelAgreement, StandardServiceRequestActivityID standardServiceRequestActivityID, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                if (standardServiceRequestActivityID is null)
                    throw new ArgumentNullException(nameof(standardServiceRequestActivityID));

                return await DeleteAsync(serviceLevelAgreement.Id, standardServiceRequestActivityID.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="StandardServiceRequestActivityID"/> associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which the standard service request activity identifier is removed.</param>
            /// <param name="standardServiceRequestActivityIDId">The identifier of the standard service request activity identifier to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ServiceLevelAgreement serviceLevelAgreement, long standardServiceRequestActivityIDId, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await DeleteAsync(serviceLevelAgreement.Id, standardServiceRequestActivityIDId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all standard service request activity i ds associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceLevelAgreementId, "standard_service_request_activityIDs", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all standard service request activity i ds associated with a <see cref="ServiceLevelAgreement"/>.
            /// </summary>
            /// <param name="serviceLevelAgreement">The service level agreement from which all standard service request activity i ds are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await DeleteAllAsync(serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
