using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Person"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/people/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed partial class PersonClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="Address"/> records related to an <see cref="Person"/>.
        /// </summary>
        public AddressesClient Addresses { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Person"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Person"/>.
        /// </summary>
        public ConfigurationItemCoveragesClient ConfigurationItemCoverages { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Person"/>.
        /// </summary>
        public ConfigurationItemsClient ConfigurationItems { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Contact"/> records related to an <see cref="Person"/>.
        /// </summary>
        public ContactsClient Contacts { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="OutOfOfficePeriod"/> records related to an <see cref="Person"/>.
        /// </summary>
        public OutOfOfficePeriodsClient OutOfOfficePeriods { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Permission"/> records related to an <see cref="Person"/>.
        /// </summary>
        public PermissionsClient Permissions { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="Person"/>.
        /// </summary>
        public ServiceCoveragesClient ServiceCoverages { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="Person"/>.
        /// </summary>
        public ServiceInstanceCoveragesClient ServiceInstanceCoverages { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="Person"/>.
        /// </summary>
        public ServiceLevelAgreementCoveragesClient ServiceLevelAgreementCoverages { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SkillPool"/> records related to an <see cref="Person"/>.
        /// </summary>
        public SkillPoolsClient SkillPools { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Team"/> records related to an <see cref="Person"/>.
        /// </summary>
        public TeamsClient Teams { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonClient"/> class.
        /// </summary>
        internal PersonClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "people/"))
        {
            Addresses = new AddressesClient(this);
            AuditEntries = new AuditEntriesClient(this);
            ConfigurationItemCoverages = new ConfigurationItemCoveragesClient(this);
            ConfigurationItems = new ConfigurationItemsClient(this);
            Contacts = new ContactsClient(this);
            OutOfOfficePeriods = new OutOfOfficePeriodsClient(this);
            Permissions = new PermissionsClient(this);
            ServiceCoverages = new ServiceCoveragesClient(this);
            ServiceInstanceCoverages = new ServiceInstanceCoveragesClient(this);
            ServiceLevelAgreementCoverages = new ServiceLevelAgreementCoveragesClient(this);
            SkillPools = new SkillPoolsClient(this);
            Teams = new TeamsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Person"/> using the specified <see cref="PersonQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which people to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Person"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(PersonQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Person>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Person"/> items as an asynchronous stream using the specified <see cref="PersonQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which people to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Person> StreamAsync(PersonQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Person>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Person"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the person.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Person"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Person?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Person>(new PersonQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Archive a <see cref="Person"/>.<br />
        /// The person must be disabled.
        /// </summary>
        /// <param name="person">The person to archive.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The archived <see cref="Person"/>.</returns>
        public async Task<Person> ArchiveAsync(Person person, CancellationToken ct = default)
        {
            return await PostItemAsync(person, "archive", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Person"/>.
        /// </summary>
        /// <param name="person">The person to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Person"/>.</returns>
        public async Task<Person> CreateAsync(Person person, CancellationToken ct = default)
        {
            return await PostItemAsync(person, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Person"/>.
        /// </summary>
        /// <param name="personId">The identifier of the person to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Person"/>.</returns>
        public async Task<Person> RestoreAsync(long personId, CancellationToken ct = default)
        {
            return await PostItemAsync(new Person(personId), "restore", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Restore a <see cref="Person"/>.
        /// </summary>
        /// <param name="reference">The reference to the person to restore.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The restored <see cref="Person"/>.</returns>
        public async Task<Person> RestoreAsync(ResourceReference reference, CancellationToken ct = default)
        {
            if (reference is null)
                throw new ArgumentNullException(nameof(reference));

            if (!reference.Id.HasValue)
                throw new ArgumentException("The archive reference must have a valid identifier.", nameof(reference));

            return await RestoreAsync(reference.Id.Value, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Trash a <see cref="Person"/>.<br />
        /// The person must be disabled.
        /// </summary>
        /// <param name="person">The person to trash.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The trashed <see cref="Person"/>.</returns>
        public async Task<Person> TrashAsync(Person person, CancellationToken ct = default)
        {
            return await PostItemAsync(person, "trash", ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Person"/>.
        /// </summary>
        /// <param name="person">The person to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Person"/>.</returns>
        public async Task<Person> UpdateAsync(Person person, CancellationToken ct = default)
        {
            return await PatchItemAsync(person, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Address"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class AddressesClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AddressesClient"/> class.
            /// </summary>
            internal AddressesClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Address"/> records for the specified person using an <see cref="AddressQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the addresses.</param>
            /// <param name="query">The query that defines which addresses to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Address"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Address>> GetAsync(long personId, AddressQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Address>(personId, "addresses", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Address"/> records for the specified person using an <see cref="AddressQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the addresses.</param>
            /// <param name="query">The query that defines which addresses to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Address"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Address>> GetAsync(Person person, AddressQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Address"/> items as an asynchronous stream for the specified person using an <see cref="AddressQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the addresses.</param>
            /// <param name="query">The query that defines which addresses to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Address"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Address> StreamAsync(long personId, AddressQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Address>(personId, "addresses", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Address"/> items as an asynchronous stream for the specified person using an <see cref="AddressQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the addresses.</param>
            /// <param name="query">The query that defines which addresses to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Address"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Address> StreamAsync(Person person, AddressQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="Address"/> by its unique identifier for the specified person.
            /// </summary>
            /// <param name="personId">The unique identifier of the person.</param>
            /// <param name="addressId">The unique identifier of the address.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="Address"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<Address?> GetAsync(long personId, long addressId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<Address>(personId, "addresses", new AddressQuery().WithId(addressId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="Address"/> record for the specified person.
            /// </summary>
            /// <param name="person">The person for which to retrieve the address.</param>
            /// <param name="addressId">The unique identifier of the address.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="Address"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<Address?> GetAsync(Person person, long addressId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, addressId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="Address"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="address">The address to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Address"/>.</returns>
            public async Task<Address> CreateAsync(long personId, Address address, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(personId, "addresses", address, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="Address"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person to which the address is added.</param>
            /// <param name="address">The address to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Address"/>.</returns>
            public async Task<Address> CreateAsync(Person person, Address address, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await CreateAsync(person.Id, address, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="Address"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="address">The address to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Address"/>.</returns>
            public async Task<Address> UpdateAsync(long personId, Address address, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(personId, "addresses", address, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="Address"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person with which the address is associated.</param>
            /// <param name="address">The address to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Address"/>.</returns>
            public async Task<Address> UpdateAsync(Person person, Address address, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await UpdateAsync(person.Id, address, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="Address"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="addressId">The identifier of the address to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long personId, long addressId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(personId, "addresses", addressId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="Address"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="address">The address to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long personId, Address address, CancellationToken ct = default)
            {
                if (address is null)
                    throw new ArgumentNullException(nameof(address));

                return await DeleteAsync(personId, address.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="Address"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the address is removed.</param>
            /// <param name="address">The address to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Person person, Address address, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (address is null)
                    throw new ArgumentNullException(nameof(address));

                return await DeleteAsync(person.Id, address.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="Address"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the address is removed.</param>
            /// <param name="addressId">The identifier of the address to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Person person, long addressId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await DeleteAsync(person.Id, addressId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all addresses associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long personId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(personId, "addresses", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all addresses associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which all addresses are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await DeleteAllAsync(person.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified person using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long personId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(personId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified person using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Person person, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified person using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long personId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(personId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified person using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Person person, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class ConfigurationItemCoveragesClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemCoveragesClient"/> class.
            /// </summary>
            internal ConfigurationItemCoveragesClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified person using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the configuration item coverages.</param>
            /// <param name="query">The query that defines which configuration item coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long personId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(personId, "ci_coverages", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified person using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the configuration item coverages.</param>
            /// <param name="query">The query that defines which configuration item coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(Person person, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified person using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the configuration item coverages.</param>
            /// <param name="query">The query that defines which configuration item coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long personId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(personId, "ci_coverages", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified person using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the configuration item coverages.</param>
            /// <param name="query">The query that defines which configuration item coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(Person person, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ConfigurationItem"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class ConfigurationItemsClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigurationItemsClient"/> class.
            /// </summary>
            internal ConfigurationItemsClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified person using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(long personId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ConfigurationItem>(personId, "cis", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ConfigurationItem"/> records for the specified person using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ConfigurationItem"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ConfigurationItem>> GetAsync(Person person, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified person using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(long personId, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ConfigurationItem>(personId, "cis", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ConfigurationItem"/> items as an asynchronous stream for the specified person using an <see cref="ConfigurationItemQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the configuration items.</param>
            /// <param name="query">The query that defines which configuration items to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ConfigurationItem"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ConfigurationItem> StreamAsync(Person person, ConfigurationItemQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long personId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(personId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long personId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(personId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Person person, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await AddAsync(person.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ConfigurationItem"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Person person, long configurationItemId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(person.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long personId, long configurationItemId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(personId, "cis", configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long personId, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(personId, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the configuration item is removed.</param>
            /// <param name="configurationItem">The configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Person person, ConfigurationItem configurationItem, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (configurationItem is null)
                    throw new ArgumentNullException(nameof(configurationItem));

                return await RemoveAsync(person.Id, configurationItem.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ConfigurationItem"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the configuration item is removed.</param>
            /// <param name="configurationItemId">The identifier of the configuration item to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Person person, long configurationItemId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(person.Id, configurationItemId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long personId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(personId, "cis", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all configuration items associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which all configuration items are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAllAsync(person.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Contact"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class ContactsClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ContactsClient"/> class.
            /// </summary>
            internal ContactsClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Contact"/> records for the specified person using an <see cref="ContactQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the contacts.</param>
            /// <param name="query">The query that defines which contacts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Contact"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Contact>> GetAsync(long personId, ContactQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Contact>(personId, "contacts", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Contact"/> records for the specified person using an <see cref="ContactQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the contacts.</param>
            /// <param name="query">The query that defines which contacts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Contact"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Contact>> GetAsync(Person person, ContactQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Contact"/> items as an asynchronous stream for the specified person using an <see cref="ContactQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the contacts.</param>
            /// <param name="query">The query that defines which contacts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Contact"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Contact> StreamAsync(long personId, ContactQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Contact>(personId, "contacts", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Contact"/> items as an asynchronous stream for the specified person using an <see cref="ContactQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the contacts.</param>
            /// <param name="query">The query that defines which contacts to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Contact"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Contact> StreamAsync(Person person, ContactQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }

            /// <summary>
            /// Create a <see cref="Contact"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="contact">The contact to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Contact"/>.</returns>
            public async Task<Contact> CreateAsync(long personId, Contact contact, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(personId, "contacts", contact, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create a <see cref="Contact"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person to which the contact is added.</param>
            /// <param name="contact">The contact to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Contact"/>.</returns>
            public async Task<Contact> CreateAsync(Person person, Contact contact, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await CreateAsync(person.Id, contact, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="contact">The contact to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Contact"/>.</returns>
            public async Task<Contact> UpdateAsync(long personId, Contact contact, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(personId, "contacts", contact, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person with which the contact is associated.</param>
            /// <param name="contact">The contact to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="Contact"/>.</returns>
            public async Task<Contact> UpdateAsync(Person person, Contact contact, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await UpdateAsync(person.Id, contact, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="contactId">The identifier of the contact to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long personId, long contactId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(personId, "contacts", contactId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="contact">The contact to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long personId, Contact contact, CancellationToken ct = default)
            {
                if (contact is null)
                    throw new ArgumentNullException(nameof(contact));

                return await DeleteAsync(personId, contact.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the contact is removed.</param>
            /// <param name="contact">The contact to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Person person, Contact contact, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (contact is null)
                    throw new ArgumentNullException(nameof(contact));

                return await DeleteAsync(person.Id, contact.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the contact is removed.</param>
            /// <param name="contactId">The identifier of the contact to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(Person person, long contactId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await DeleteAsync(person.Id, contactId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="contactId">The identifier of the contact to delete all.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long personId, long contactId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(personId, "contacts", contactId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="contact">The contact to delete all.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long personId, Contact contact, CancellationToken ct = default)
            {
                if (contact is null)
                    throw new ArgumentNullException(nameof(contact));

                return await DeleteAllAsync(personId, contact.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the contact is removed.</param>
            /// <param name="contact">The contact to delete all.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Person person, Contact contact, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (contact is null)
                    throw new ArgumentNullException(nameof(contact));

                return await DeleteAllAsync(person.Id, contact.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all a <see cref="Contact"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the contact is removed.</param>
            /// <param name="contactId">The identifier of the contact to delete all.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(Person person, long contactId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await DeleteAllAsync(person.Id, contactId, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="OutOfOfficePeriod"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class OutOfOfficePeriodsClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="OutOfOfficePeriodsClient"/> class.
            /// </summary>
            internal OutOfOfficePeriodsClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="OutOfOfficePeriod"/> records for the specified person using an <see cref="OutOfOfficePeriodQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the out of office periods.</param>
            /// <param name="query">The query that defines which out of office periods to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="OutOfOfficePeriod"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<OutOfOfficePeriod>> GetAsync(long personId, OutOfOfficePeriodQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<OutOfOfficePeriod>(personId, "out_of_office_periods", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="OutOfOfficePeriod"/> records for the specified person using an <see cref="OutOfOfficePeriodQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the out of office periods.</param>
            /// <param name="query">The query that defines which out of office periods to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="OutOfOfficePeriod"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<OutOfOfficePeriod>> GetAsync(Person person, OutOfOfficePeriodQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="OutOfOfficePeriod"/> items as an asynchronous stream for the specified person using an <see cref="OutOfOfficePeriodQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the out of office periods.</param>
            /// <param name="query">The query that defines which out of office periods to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="OutOfOfficePeriod"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<OutOfOfficePeriod> StreamAsync(long personId, OutOfOfficePeriodQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<OutOfOfficePeriod>(personId, "out_of_office_periods", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="OutOfOfficePeriod"/> items as an asynchronous stream for the specified person using an <see cref="OutOfOfficePeriodQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the out of office periods.</param>
            /// <param name="query">The query that defines which out of office periods to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="OutOfOfficePeriod"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<OutOfOfficePeriod> StreamAsync(Person person, OutOfOfficePeriodQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Permission"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed partial class PermissionsClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="PermissionsClient"/> class.
            /// </summary>
            internal PermissionsClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Permission"/> records for the specified person using an <see cref="PermissionQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the permissions.</param>
            /// <param name="query">The query that defines which permissions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Permission"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Permission>> GetAsync(long personId, PermissionQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Permission>(personId, "permissions", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Permission"/> records for the specified person using an <see cref="PermissionQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the permissions.</param>
            /// <param name="query">The query that defines which permissions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Permission"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Permission>> GetAsync(Person person, PermissionQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Permission"/> items as an asynchronous stream for the specified person using an <see cref="PermissionQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the permissions.</param>
            /// <param name="query">The query that defines which permissions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Permission"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Permission> StreamAsync(long personId, PermissionQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Permission>(personId, "permissions", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Permission"/> items as an asynchronous stream for the specified person using an <see cref="PermissionQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the permissions.</param>
            /// <param name="query">The query that defines which permissions to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Permission"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Permission> StreamAsync(Person person, PermissionQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class ServiceCoveragesClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceCoveragesClient"/> class.
            /// </summary>
            internal ServiceCoveragesClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified person using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the service coverages.</param>
            /// <param name="query">The query that defines which service coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long personId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(personId, "service_coverages", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified person using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the service coverages.</param>
            /// <param name="query">The query that defines which service coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(Person person, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified person using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the service coverages.</param>
            /// <param name="query">The query that defines which service coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long personId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(personId, "service_coverages", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified person using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the service coverages.</param>
            /// <param name="query">The query that defines which service coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(Person person, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class ServiceInstanceCoveragesClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstanceCoveragesClient"/> class.
            /// </summary>
            internal ServiceInstanceCoveragesClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified person using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the service instance coverages.</param>
            /// <param name="query">The query that defines which service instance coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long personId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(personId, "service_instance_coverages", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified person using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the service instance coverages.</param>
            /// <param name="query">The query that defines which service instance coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(Person person, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified person using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the service instance coverages.</param>
            /// <param name="query">The query that defines which service instance coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long personId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(personId, "service_instance_coverages", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified person using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the service instance coverages.</param>
            /// <param name="query">The query that defines which service instance coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(Person person, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class ServiceLevelAgreementCoveragesClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceLevelAgreementCoveragesClient"/> class.
            /// </summary>
            internal ServiceLevelAgreementCoveragesClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified person using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the service level agreement coverages.</param>
            /// <param name="query">The query that defines which service level agreement coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(long personId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceLevelAgreement>(personId, "sla_coverages", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified person using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the service level agreement coverages.</param>
            /// <param name="query">The query that defines which service level agreement coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(Person person, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified person using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the service level agreement coverages.</param>
            /// <param name="query">The query that defines which service level agreement coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(long personId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceLevelAgreement>(personId, "sla_coverages", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified person using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the service level agreement coverages.</param>
            /// <param name="query">The query that defines which service level agreement coverages to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(Person person, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SkillPool"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class SkillPoolsClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SkillPoolsClient"/> class.
            /// </summary>
            internal SkillPoolsClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SkillPool"/> records for the specified person using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SkillPool"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SkillPool>> GetAsync(long personId, SkillPoolQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SkillPool>(personId, "skill_pools", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SkillPool"/> records for the specified person using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SkillPool"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SkillPool>> GetAsync(Person person, SkillPoolQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SkillPool"/> items as an asynchronous stream for the specified person using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SkillPool"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SkillPool> StreamAsync(long personId, SkillPoolQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SkillPool>(personId, "skill_pools", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SkillPool"/> items as an asynchronous stream for the specified person using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SkillPool"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SkillPool> StreamAsync(Person person, SkillPoolQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long personId, long skillPoolId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(personId, "skill_pools", skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="skillPool">The skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long personId, SkillPool skillPool, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await AddAsync(personId, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the skill pool is removed.</param>
            /// <param name="skillPool">The skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Person person, SkillPool skillPool, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await AddAsync(person.Id, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the skill pool is removed.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Person person, long skillPoolId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(person.Id, skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long personId, long skillPoolId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(personId, "skill_pools", skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="skillPool">The skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long personId, SkillPool skillPool, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAsync(personId, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the skill pool is removed.</param>
            /// <param name="skillPool">The skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Person person, SkillPool skillPool, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAsync(person.Id, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the skill pool is removed.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Person person, long skillPoolId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(person.Id, skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all skill pools associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long personId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(personId, "skill_pools", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all skill pools associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which all skill pools are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAllAsync(person.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Team"/> records related to an <see cref="Person"/>.
        /// </summary>
        public sealed class TeamsClient
        {
            private readonly PersonClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TeamsClient"/> class.
            /// </summary>
            internal TeamsClient(PersonClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Team"/> records for the specified person using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to retrieve the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Team"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Team>> GetAsync(long personId, TeamQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Team>(personId, "teams", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Team"/> records for the specified person using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to retrieve the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Team"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Team>> GetAsync(Person person, TeamQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await GetAsync(person.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Team"/> items as an asynchronous stream for the specified person using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="personId">The unique identifier of the person for which to enumerate the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Team"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Team> StreamAsync(long personId, TeamQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Team>(personId, "teams", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Team"/> items as an asynchronous stream for the specified person using an <see cref="TeamQuery"/>.
            /// </summary>
            /// <param name="person">The person for which to enumerate the teams.</param>
            /// <param name="query">The query that defines which teams to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Team"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Team> StreamAsync(Person person, TeamQuery query, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return StreamAsync(person.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Team"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="teamId">The identifier of the team to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long personId, long teamId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(personId, "teams", teamId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Team"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="team">The team to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long personId, Team team, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await AddAsync(personId, team.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Team"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the team is removed.</param>
            /// <param name="team">The team to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Person person, Team team, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await AddAsync(person.Id, team.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Team"/> to a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the team is removed.</param>
            /// <param name="teamId">The identifier of the team to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Person person, long teamId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(person.Id, teamId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Team"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="teamId">The identifier of the team to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long personId, long teamId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(personId, "teams", teamId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Team"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="team">The team to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long personId, Team team, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await RemoveAsync(personId, team.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Team"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the team is removed.</param>
            /// <param name="team">The team to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Person person, Team team, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await RemoveAsync(person.Id, team.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Team"/> associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which the team is removed.</param>
            /// <param name="teamId">The identifier of the team to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Person person, long teamId, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(person.Id, teamId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all teams associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="personId">The identifier of the person.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long personId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(personId, "teams", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all teams associated with a <see cref="Person"/>.
            /// </summary>
            /// <param name="person">The person from which all teams are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAllAsync(person.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
