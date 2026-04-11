using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Organization"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/organizations/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class OrganizationClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="Address"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public AddressesClient Addresses { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Organization"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public ChilderenClient Childeren { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Contact"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public ContactsClient Contacts { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Contract"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public ContractsClient Contracts { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Person"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public PeopleClient People { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Risk"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public RisksClient Risks { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public ServiceLevelAgreementsClient ServiceLevelAgreements { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="TimeAllocation"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public TimeAllocationsClient TimeAllocations { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationClient"/> class.
        /// </summary>
        internal OrganizationClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "organizations/"))
        {
            Addresses = new AddressesClient(this);
            AuditEntries = new AuditEntriesClient(this);
            Childeren = new ChilderenClient(this);
            Contacts = new ContactsClient(this);
            Contracts = new ContractsClient(this);
            People = new PeopleClient(this);
            Risks = new RisksClient(this);
            ServiceLevelAgreements = new ServiceLevelAgreementsClient(this);
            TimeAllocations = new TimeAllocationsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Organization"/> using the specified <see cref="OrganizationQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which organizations to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Organization"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(OrganizationQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Organization>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Organization"/> items as an asynchronous stream using the specified <see cref="OrganizationQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which organizations to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Organization> StreamAsync(OrganizationQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Organization>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Organization"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the organization.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Organization"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Organization?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Organization>(new OrganizationQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Organization"/>.
        /// </summary>
        /// <param name="organization">The organization to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Organization"/>.</returns>
        public async Task<Organization> CreateAsync(Organization organization, CancellationToken ct = default)
        {
            return await PostItemAsync(organization, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="Organization"/>.
        /// </summary>
        /// <param name="organization">The organization to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Organization"/>.</returns>
        public async Task<Organization> UpdateAsync(Organization organization, CancellationToken ct = default)
        {
            return await PatchItemAsync(organization, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Address"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public sealed class AddressesClient
        {
            private readonly OrganizationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AddressesClient"/> class.
            /// </summary>
            internal AddressesClient(OrganizationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Address"/> records for the specified organization using an <see cref="AddressQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to retrieve the addresses.</param>
            /// <param name="query">The query that defines which addresses to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Address"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Address>> GetAsync(long organizationId, AddressQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Address>(organizationId, "addresses", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Address"/> records for the specified organization using an <see cref="AddressQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the addresses.</param>
            /// <param name="query">The query that defines which addresses to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Address"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Address>> GetAsync(Organization organization, AddressQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Address"/> items as an asynchronous stream for the specified organization using an <see cref="AddressQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to enumerate the addresses.</param>
            /// <param name="query">The query that defines which addresses to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Address"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Address> StreamAsync(long organizationId, AddressQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Address>(organizationId, "addresses", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Address"/> items as an asynchronous stream for the specified organization using an <see cref="AddressQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to enumerate the addresses.</param>
            /// <param name="query">The query that defines which addresses to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Address"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Address> StreamAsync(Organization organization, AddressQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return StreamAsync(organization.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="Address"/> by its unique identifier for the specified organization.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization.</param>
            /// <param name="addressId">The unique identifier of the address.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="Address"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<Address?> GetAsync(long organizationId, long addressId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<Address>(organizationId, "addresses", new AddressQuery().WithId(addressId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="Address"/> record for the specified organization.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the address.</param>
            /// <param name="addressId">The unique identifier of the address.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="Address"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<Address?> GetAsync(Organization organization, long addressId, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, addressId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="Address"/> to an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="address">The address to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Address"/>.</returns>
            public async Task<Address> CreateAsync(long organizationId, Address address, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(organizationId, "addresses", address, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="Address"/> to an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization to which the address is added.</param>
            /// <param name="address">The address to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Address"/>.</returns>
            public async Task<Address> CreateAsync(Organization organization, Address address, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await CreateAsync(organization.Id, address, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="Address"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="address">The address to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Address"/>.</returns>
            public async Task<Address> UpdateAsync(long organizationId, Address address, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(organizationId, "addresses", address, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="Address"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization with which the address is associated.</param>
            /// <param name="address">The address to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Address"/>.</returns>
            public async Task<Address> UpdateAsync(Organization organization, Address address, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await UpdateAsync(organization.Id, address, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="Address"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="addressId">The identifier of the address to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long organizationId, long addressId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(organizationId, "addresses", addressId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="Address"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="address">The address to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long organizationId, Address address, CancellationToken ct = default)
            {
                if (address is null)
                    throw new ArgumentNullException(nameof(address));

                return await DeleteAsync(organizationId, address.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="Address"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which the address is removed.</param>
            /// <param name="address">The address to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Organization organization, Address address, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                if (address is null)
                    throw new ArgumentNullException(nameof(address));

                return await DeleteAsync(organization.Id, address.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="Address"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which the address is removed.</param>
            /// <param name="addressId">The identifier of the address to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Organization organization, long addressId, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await DeleteAsync(organization.Id, addressId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all addresses associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long organizationId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(organizationId, "addresses", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all addresses associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which all addresses are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await DeleteAllAsync(organization.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly OrganizationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(OrganizationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified organization using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long organizationId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(organizationId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified organization using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Organization organization, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified organization using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long organizationId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(organizationId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified organization using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Organization organization, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return StreamAsync(organization.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Organization"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public sealed class ChilderenClient
        {
            private readonly OrganizationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ChilderenClient"/> class.
            /// </summary>
            internal ChilderenClient(OrganizationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified organization using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to retrieve the childeren.</param>
            /// <param name="query">The query that defines which childeren to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(long organizationId, OrganizationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Organization>(organizationId, "children", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Organization"/> records for the specified organization using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the childeren.</param>
            /// <param name="query">The query that defines which childeren to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Organization"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Organization>> GetAsync(Organization organization, OrganizationQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified organization using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to enumerate the childeren.</param>
            /// <param name="query">The query that defines which childeren to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(long organizationId, OrganizationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Organization>(organizationId, "children", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Organization"/> items as an asynchronous stream for the specified organization using an <see cref="OrganizationQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to enumerate the childeren.</param>
            /// <param name="query">The query that defines which childeren to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Organization"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Organization> StreamAsync(Organization organization, OrganizationQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return StreamAsync(organization.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Contact"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public sealed class ContactsClient
        {
            private readonly OrganizationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ContactsClient"/> class.
            /// </summary>
            internal ContactsClient(OrganizationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Contact"/> records for the specified organization using an <see cref="ContactQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to retrieve the contacts.</param>
            /// <param name="query">The query that defines which contacts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Contact"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Contact>> GetAsync(long organizationId, ContactQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Contact>(organizationId, "contacts", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Contact"/> records for the specified organization using an <see cref="ContactQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the contacts.</param>
            /// <param name="query">The query that defines which contacts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Contact"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Contact>> GetAsync(Organization organization, ContactQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Contact"/> items as an asynchronous stream for the specified organization using an <see cref="ContactQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to enumerate the contacts.</param>
            /// <param name="query">The query that defines which contacts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Contact"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Contact> StreamAsync(long organizationId, ContactQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Contact>(organizationId, "contacts", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Contact"/> items as an asynchronous stream for the specified organization using an <see cref="ContactQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to enumerate the contacts.</param>
            /// <param name="query">The query that defines which contacts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Contact"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Contact> StreamAsync(Organization organization, ContactQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return StreamAsync(organization.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="Contact"/> by its unique identifier for the specified organization.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization.</param>
            /// <param name="contactId">The unique identifier of the contact.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="Contact"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<Contact?> GetAsync(long organizationId, long contactId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<Contact>(organizationId, "contacts", new ContactQuery().WithId(contactId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="Contact"/> record for the specified organization.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the contact.</param>
            /// <param name="contactId">The unique identifier of the contact.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="Contact"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<Contact?> GetAsync(Organization organization, long contactId, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, contactId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="Contact"/> to an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="contact">The contact to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Contact"/>.</returns>
            public async Task<Contact> CreateAsync(long organizationId, Contact contact, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(organizationId, "contacts", contact, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="Contact"/> to an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization to which the contact is added.</param>
            /// <param name="contact">The contact to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Contact"/>.</returns>
            public async Task<Contact> CreateAsync(Organization organization, Contact contact, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await CreateAsync(organization.Id, contact, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="Contact"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="contact">The contact to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Contact"/>.</returns>
            public async Task<Contact> UpdateAsync(long organizationId, Contact contact, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(organizationId, "contacts", contact, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="Contact"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization with which the contact is associated.</param>
            /// <param name="contact">The contact to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Contact"/>.</returns>
            public async Task<Contact> UpdateAsync(Organization organization, Contact contact, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await UpdateAsync(organization.Id, contact, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Contact"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="contactId">The identifier of the contact to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long organizationId, long contactId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(organizationId, "contacts", contactId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Contact"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="contact">The contact to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long organizationId, Contact contact, CancellationToken ct = default)
            {
                if (contact is null)
                    throw new ArgumentNullException(nameof(contact));

                return await DeleteAsync(organizationId, contact.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Contact"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which the contact is removed.</param>
            /// <param name="contact">The contact to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Organization organization, Contact contact, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                if (contact is null)
                    throw new ArgumentNullException(nameof(contact));

                return await DeleteAsync(organization.Id, contact.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Contact"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which the contact is removed.</param>
            /// <param name="contactId">The identifier of the contact to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Organization organization, long contactId, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await DeleteAsync(organization.Id, contactId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all contacts associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long organizationId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(organizationId, "contacts", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all contacts associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which all contacts are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await DeleteAllAsync(organization.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Contract"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public sealed class ContractsClient
        {
            private readonly OrganizationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ContractsClient"/> class.
            /// </summary>
            internal ContractsClient(OrganizationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Contract"/> records for the specified organization using an <see cref="ContractQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to retrieve the contracts.</param>
            /// <param name="query">The query that defines which contracts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Contract"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Contract>> GetAsync(long organizationId, ContractQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Contract>(organizationId, "contracts", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Contract"/> records for the specified organization using an <see cref="ContractQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the contracts.</param>
            /// <param name="query">The query that defines which contracts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Contract"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Contract>> GetAsync(Organization organization, ContractQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Contract"/> items as an asynchronous stream for the specified organization using an <see cref="ContractQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to enumerate the contracts.</param>
            /// <param name="query">The query that defines which contracts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Contract"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Contract> StreamAsync(long organizationId, ContractQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Contract>(organizationId, "contracts", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Contract"/> items as an asynchronous stream for the specified organization using an <see cref="ContractQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to enumerate the contracts.</param>
            /// <param name="query">The query that defines which contracts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Contract"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Contract> StreamAsync(Organization organization, ContractQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return StreamAsync(organization.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Person"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public sealed class PeopleClient
        {
            private readonly OrganizationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PeopleClient"/> class.
            /// </summary>
            internal PeopleClient(OrganizationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified organization using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to retrieve the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(long organizationId, PersonQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Person>(organizationId, "people", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified organization using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(Organization organization, PersonQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified organization using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to enumerate the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(long organizationId, PersonQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Person>(organizationId, "people", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified organization using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to enumerate the people.</param>
            /// <param name="query">The query that defines which people to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(Organization organization, PersonQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return StreamAsync(organization.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Risk"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public sealed class RisksClient
        {
            private readonly OrganizationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RisksClient"/> class.
            /// </summary>
            internal RisksClient(OrganizationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Risk"/> records for the specified organization using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to retrieve the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Risk"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Risk>> GetAsync(long organizationId, RiskQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Risk>(organizationId, "risks", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Risk"/> records for the specified organization using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Risk"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Risk>> GetAsync(Organization organization, RiskQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Risk"/> items as an asynchronous stream for the specified organization using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to enumerate the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Risk"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Risk> StreamAsync(long organizationId, RiskQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Risk>(organizationId, "risks", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Risk"/> items as an asynchronous stream for the specified organization using an <see cref="RiskQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to enumerate the risks.</param>
            /// <param name="query">The query that defines which risks to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Risk"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Risk> StreamAsync(Organization organization, RiskQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return StreamAsync(organization.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public sealed class ServiceLevelAgreementsClient
        {
            private readonly OrganizationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceLevelAgreementsClient"/> class.
            /// </summary>
            internal ServiceLevelAgreementsClient(OrganizationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified organization using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(long organizationId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceLevelAgreement>(organizationId, "slas", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified organization using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(Organization organization, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified organization using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(long organizationId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceLevelAgreement>(organizationId, "slas", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified organization using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(Organization organization, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return StreamAsync(organization.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="TimeAllocation"/> records related to an <see cref="Organization"/>.
        /// </summary>
        public sealed class TimeAllocationsClient
        {
            private readonly OrganizationClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TimeAllocationsClient"/> class.
            /// </summary>
            internal TimeAllocationsClient(OrganizationClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="TimeAllocation"/> records for the specified organization using an <see cref="TimeAllocationQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to retrieve the time allocations.</param>
            /// <param name="query">The query that defines which time allocations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="TimeAllocation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<TimeAllocation>> GetAsync(long organizationId, TimeAllocationQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<TimeAllocation>(organizationId, "time_allocations", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="TimeAllocation"/> records for the specified organization using an <see cref="TimeAllocationQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to retrieve the time allocations.</param>
            /// <param name="query">The query that defines which time allocations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="TimeAllocation"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<TimeAllocation>> GetAsync(Organization organization, TimeAllocationQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await GetAsync(organization.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="TimeAllocation"/> items as an asynchronous stream for the specified organization using an <see cref="TimeAllocationQuery"/>.
            /// </summary>
            /// <param name="organizationId">The unique identifier of the organization for which to enumerate the time allocations.</param>
            /// <param name="query">The query that defines which time allocations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="TimeAllocation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<TimeAllocation> StreamAsync(long organizationId, TimeAllocationQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<TimeAllocation>(organizationId, "time_allocations", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="TimeAllocation"/> items as an asynchronous stream for the specified organization using an <see cref="TimeAllocationQuery"/>.
            /// </summary>
            /// <param name="organization">The organization for which to enumerate the time allocations.</param>
            /// <param name="query">The query that defines which time allocations to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="TimeAllocation"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<TimeAllocation> StreamAsync(Organization organization, TimeAllocationQuery query, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return StreamAsync(organization.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="TimeAllocation"/> to an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="timeAllocationId">The identifier of the time allocation to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long organizationId, long timeAllocationId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(organizationId, "time_allocations", timeAllocationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="TimeAllocation"/> to an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="timeAllocation">The time allocation to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long organizationId, TimeAllocation timeAllocation, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await AddAsync(organizationId, timeAllocation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="TimeAllocation"/> to an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which the time allocation is removed.</param>
            /// <param name="timeAllocation">The time allocation to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Organization organization, TimeAllocation timeAllocation, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await AddAsync(organization.Id, timeAllocation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="TimeAllocation"/> to an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which the time allocation is removed.</param>
            /// <param name="timeAllocationId">The identifier of the time allocation to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Organization organization, long timeAllocationId, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await AddAsync(organization.Id, timeAllocationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="TimeAllocation"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="timeAllocationId">The identifier of the time allocation to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long organizationId, long timeAllocationId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(organizationId, "time_allocations", timeAllocationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="TimeAllocation"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="timeAllocation">The time allocation to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long organizationId, TimeAllocation timeAllocation, CancellationToken ct = default)
            {
                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await RemoveAsync(organizationId, timeAllocation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="TimeAllocation"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which the time allocation is removed.</param>
            /// <param name="timeAllocation">The time allocation to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Organization organization, TimeAllocation timeAllocation, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                if (timeAllocation is null)
                    throw new ArgumentNullException(nameof(timeAllocation));

                return await RemoveAsync(organization.Id, timeAllocation.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="TimeAllocation"/> associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which the time allocation is removed.</param>
            /// <param name="timeAllocationId">The identifier of the time allocation to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Organization organization, long timeAllocationId, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAsync(organization.Id, timeAllocationId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all time allocations associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organizationId">The identifier of the organization.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long organizationId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(organizationId, "time_allocations", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all time allocations associated with an <see cref="Organization"/>.
            /// </summary>
            /// <param name="organization">The organization from which all time allocations are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Organization organization, CancellationToken ct = default)
            {
                if (organization is null)
                    throw new ArgumentNullException(nameof(organization));

                return await RemoveAllAsync(organization.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
