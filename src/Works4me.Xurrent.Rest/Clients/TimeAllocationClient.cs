using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="TimeAllocation"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/time_allocations/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class TimeAllocationClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="TimeAllocation"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Organization"/> records related to an <see cref="TimeAllocation"/>.
        /// </summary>
        public CustomersClient Customers { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Organization"/> records related to an <see cref="TimeAllocation"/>.
        /// </summary>
        public OrganizationsClient Organizations { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Service"/> records related to an <see cref="TimeAllocation"/>.
        /// </summary>
        public ServicesClient Services { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeAllocationClient"/> class.
        /// </summary>
        internal TimeAllocationClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "time_allocations/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Customers = new CustomersClient(this);
            Organizations = new OrganizationsClient(this);
            Services = new ServicesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="TimeAllocation"/> using the specified <see cref="TimeAllocationQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which time allocations to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="TimeAllocation"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<TimeAllocation>> GetAsync(TimeAllocationQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<TimeAllocation>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="TimeAllocation"/> items as an asynchronous stream using the specified <see cref="TimeAllocationQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which time allocations to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="TimeAllocation"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<TimeAllocation> StreamAsync(TimeAllocationQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<TimeAllocation>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="TimeAllocation"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the time allocation.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="TimeAllocation"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<TimeAllocation?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<TimeAllocation>(new TimeAllocationQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="TimeAllocation"/>.
        /// </summary>
        /// <param name="timeAllocation">The time allocation to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="TimeAllocation"/>.</returns>
        public async Task<TimeAllocation> CreateAsync(TimeAllocation timeAllocation, CancellationToken ct = default)
        {
            return await PostItemAsync(timeAllocation, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="TimeAllocation"/>.
        /// </summary>
        /// <param name="timeAllocation">The time allocation to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="TimeAllocation"/>.</returns>
        public async Task<TimeAllocation> UpdateAsync(TimeAllocation timeAllocation, CancellationToken ct = default)
        {
            return await PatchItemAsync(timeAllocation, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="TimeAllocation"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly TimeAllocationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(TimeAllocationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified time allocation using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="timeAllocationId">The unique identifier of the time allocation for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long timeAllocationId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(timeAllocationId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified time allocation using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(TimeAllocation timeAllocation, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await GetAsync(timeAllocation.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified time allocation using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="timeAllocationId">The unique identifier of the time allocation for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long timeAllocationId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(timeAllocationId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified time allocation using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(TimeAllocation timeAllocation, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return StreamAsync(timeAllocation.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Organization"/> records related to an <see cref="TimeAllocation"/>.
        /// </summary>
        public sealed class CustomersClient
        {
            private readonly TimeAllocationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomersClient"/> class.
            /// </summary>
            internal CustomersClient(TimeAllocationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified time allocation using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="timeAllocationId">The unique identifier of the time allocation for which to retrieve the customers.</param>
            /// <param name="query">The query that defines which customers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(long timeAllocationId, OrganizationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Organization>(timeAllocationId, "customers", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified time allocation using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation for which to retrieve the customers.</param>
            /// <param name="query">The query that defines which customers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(TimeAllocation timeAllocation, OrganizationQuery query, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await GetAsync(timeAllocation.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified time allocation using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="timeAllocationId">The unique identifier of the time allocation for which to enumerate the customers.</param>
            /// <param name="query">The query that defines which customers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(long timeAllocationId, OrganizationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Organization>(timeAllocationId, "customers", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified time allocation using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation for which to enumerate the customers.</param>
            /// <param name="query">The query that defines which customers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(TimeAllocation timeAllocation, OrganizationQuery query, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return StreamAsync(timeAllocation.Id, query, ct);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long timeAllocationId, long organizationId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(timeAllocationId, "customers", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long timeAllocationId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(timeAllocationId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the organization is removed.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(TimeAllocation timeAllocation, Organization organization, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(timeAllocation.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(TimeAllocation timeAllocation, long organizationId, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await AddAsync(timeAllocation.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long timeAllocationId, long organizationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(timeAllocationId, "customers", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long timeAllocationId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(timeAllocationId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the organization is removed.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(TimeAllocation timeAllocation, Organization organization, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(timeAllocation.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(TimeAllocation timeAllocation, long organizationId, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await RemoveAsync(timeAllocation.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all customers associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long timeAllocationId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(timeAllocationId, "customers", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all customers associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which all customers are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(TimeAllocation timeAllocation, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await RemoveAllAsync(timeAllocation.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Organization"/> records related to an <see cref="TimeAllocation"/>.
        /// </summary>
        public sealed class OrganizationsClient
        {
            private readonly TimeAllocationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="OrganizationsClient"/> class.
            /// </summary>
            internal OrganizationsClient(TimeAllocationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified time allocation using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="timeAllocationId">The unique identifier of the time allocation for which to retrieve the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(long timeAllocationId, OrganizationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Organization>(timeAllocationId, "organizations", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified time allocation using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation for which to retrieve the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(TimeAllocation timeAllocation, OrganizationQuery query, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await GetAsync(timeAllocation.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified time allocation using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="timeAllocationId">The unique identifier of the time allocation for which to enumerate the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(long timeAllocationId, OrganizationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Organization>(timeAllocationId, "organizations", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified time allocation using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation for which to enumerate the organizations.</param>
            /// <param name="query">The query that defines which organizations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(TimeAllocation timeAllocation, OrganizationQuery query, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return StreamAsync(timeAllocation.Id, query, ct);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long timeAllocationId, long organizationId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(timeAllocationId, "organizations", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long timeAllocationId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(timeAllocationId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the organization is removed.</param>
            /// <param name="organization">The organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(TimeAllocation timeAllocation, Organization organization, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(timeAllocation.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="Organization"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(TimeAllocation timeAllocation, long organizationId, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await AddAsync(timeAllocation.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long timeAllocationId, long organizationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(timeAllocationId, "organizations", organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long timeAllocationId, Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(timeAllocationId, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the organization is removed.</param>
            /// <param name="organization">The organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(TimeAllocation timeAllocation, Organization organization, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(timeAllocation.Id, organization.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="Organization"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the organization is removed.</param>
            /// <param name="organizationId">The identifier of the organization to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(TimeAllocation timeAllocation, long organizationId, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await RemoveAsync(timeAllocation.Id, organizationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all organizations associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long timeAllocationId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(timeAllocationId, "organizations", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all organizations associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which all organizations are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(TimeAllocation timeAllocation, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await RemoveAllAsync(timeAllocation.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Service"/> records related to an <see cref="TimeAllocation"/>.
        /// </summary>
        public sealed class ServicesClient
        {
            private readonly TimeAllocationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServicesClient"/> class.
            /// </summary>
            internal ServicesClient(TimeAllocationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Service"/> records for the specified time allocation using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="timeAllocationId">The unique identifier of the time allocation for which to retrieve the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Service"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Service>> GetAsync(long timeAllocationId, ServiceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Service>(timeAllocationId, "services", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Service"/> records for the specified time allocation using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation for which to retrieve the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Service"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Service>> GetAsync(TimeAllocation timeAllocation, ServiceQuery query, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await GetAsync(timeAllocation.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Service"/> items as an asynchronous stream for the specified time allocation using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="timeAllocationId">The unique identifier of the time allocation for which to enumerate the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Service"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Service> StreamAsync(long timeAllocationId, ServiceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Service>(timeAllocationId, "services", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Service"/> items as an asynchronous stream for the specified time allocation using an <see cref="ServiceQuery"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation for which to enumerate the services.</param>
            /// <param name="query">The query that defines which services to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Service"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Service> StreamAsync(TimeAllocation timeAllocation, ServiceQuery query, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return StreamAsync(timeAllocation.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="serviceId">The identifier of the service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long timeAllocationId, long serviceId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(timeAllocationId, "services", serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="service">The service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long timeAllocationId, Service service, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await AddAsync(timeAllocationId, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the service is removed.</param>
            /// <param name="service">The service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(TimeAllocation timeAllocation, Service service, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await AddAsync(timeAllocation.Id, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Service"/> to a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the service is removed.</param>
            /// <param name="serviceId">The identifier of the service to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(TimeAllocation timeAllocation, long serviceId, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await AddAsync(timeAllocation.Id, serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="serviceId">The identifier of the service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long timeAllocationId, long serviceId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(timeAllocationId, "services", serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="service">The service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long timeAllocationId, Service service, CancellationToken ct = default)
            {
                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await RemoveAsync(timeAllocationId, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the service is removed.</param>
            /// <param name="service">The service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(TimeAllocation timeAllocation, Service service, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                if (service is null)
                    throw new ArgumentNullException(nameof(service));

                return await RemoveAsync(timeAllocation.Id, service.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Service"/> associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which the service is removed.</param>
            /// <param name="serviceId">The identifier of the service to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(TimeAllocation timeAllocation, long serviceId, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await RemoveAsync(timeAllocation.Id, serviceId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all services associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocationId">The identifier of the time allocation.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long timeAllocationId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(timeAllocationId, "services", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all services associated with a <see cref="TimeAllocation"/>.
            /// </summary>
            /// <param name="timeAllocation">The time allocation from which all services are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(TimeAllocation timeAllocation, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await RemoveAllAsync(timeAllocation.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
