using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="FirstLineSupportAgreement"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/first_line_support_agreements/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class FirstLineSupportAgreementClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="FirstLineSupportAgreement"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Person"/> records related to an <see cref="FirstLineSupportAgreement"/>.
        /// </summary>
        public MajorIncidentManagersClient MajorIncidentManagers { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstLineSupportAgreementClient"/> class.
        /// </summary>
        internal FirstLineSupportAgreementClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "flsas/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            MajorIncidentManagers = new MajorIncidentManagersClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="FirstLineSupportAgreement"/> using the specified <see cref="FirstLineSupportAgreementQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which first line support agreements to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="FirstLineSupportAgreement"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<FirstLineSupportAgreement>> GetAsync(FirstLineSupportAgreementQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<FirstLineSupportAgreement>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="FirstLineSupportAgreement"/> items as an asynchronous stream using the specified <see cref="FirstLineSupportAgreementQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which first line support agreements to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="FirstLineSupportAgreement"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<FirstLineSupportAgreement> StreamAsync(FirstLineSupportAgreementQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<FirstLineSupportAgreement>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="FirstLineSupportAgreement"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the first line support agreement.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="FirstLineSupportAgreement"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<FirstLineSupportAgreement?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<FirstLineSupportAgreement>(new FirstLineSupportAgreementQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="FirstLineSupportAgreement"/>.
        /// </summary>
        /// <param name="firstLineSupportAgreement">The first line support agreement to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="FirstLineSupportAgreement"/>.</returns>
        public async Task<FirstLineSupportAgreement> CreateAsync(FirstLineSupportAgreement firstLineSupportAgreement, CancellationToken ct = default)
        {
            return await PostItemAsync(firstLineSupportAgreement, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="FirstLineSupportAgreement"/>.
        /// </summary>
        /// <param name="firstLineSupportAgreement">The first line support agreement to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="FirstLineSupportAgreement"/>.</returns>
        public async Task<FirstLineSupportAgreement> UpdateAsync(FirstLineSupportAgreement firstLineSupportAgreement, CancellationToken ct = default)
        {
            return await PatchItemAsync(firstLineSupportAgreement, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="FirstLineSupportAgreement"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly FirstLineSupportAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(FirstLineSupportAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified first line support agreement using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreementId">The unique identifier of the first line support agreement for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long firstLineSupportAgreementId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(firstLineSupportAgreementId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified first line support agreement using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreement">The first line support agreement for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(FirstLineSupportAgreement firstLineSupportAgreement, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (firstLineSupportAgreement is null)
                    throw new ArgumentNullException(nameof(firstLineSupportAgreement));

                return await GetAsync(firstLineSupportAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified first line support agreement using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreementId">The unique identifier of the first line support agreement for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long firstLineSupportAgreementId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(firstLineSupportAgreementId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified first line support agreement using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreement">The first line support agreement for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(FirstLineSupportAgreement firstLineSupportAgreement, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (firstLineSupportAgreement is null)
                    throw new ArgumentNullException(nameof(firstLineSupportAgreement));

                return StreamAsync(firstLineSupportAgreement.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Person"/> records related to an <see cref="FirstLineSupportAgreement"/>.
        /// </summary>
        public sealed class MajorIncidentManagersClient
        {
            private readonly FirstLineSupportAgreementClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="MajorIncidentManagersClient"/> class.
            /// </summary>
            internal MajorIncidentManagersClient(FirstLineSupportAgreementClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified first line support agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreementId">The unique identifier of the first line support agreement for which to retrieve the major incident managers.</param>
            /// <param name="query">The query that defines which major incident managers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(long firstLineSupportAgreementId, PersonQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Person>(firstLineSupportAgreementId, "major_incident_managers", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified first line support agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreement">The first line support agreement for which to retrieve the major incident managers.</param>
            /// <param name="query">The query that defines which major incident managers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(FirstLineSupportAgreement firstLineSupportAgreement, PersonQuery query, CancellationToken ct = default)
            {
                if (firstLineSupportAgreement is null)
                    throw new ArgumentNullException(nameof(firstLineSupportAgreement));

                return await GetAsync(firstLineSupportAgreement.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified first line support agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreementId">The unique identifier of the first line support agreement for which to enumerate the major incident managers.</param>
            /// <param name="query">The query that defines which major incident managers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(long firstLineSupportAgreementId, PersonQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Person>(firstLineSupportAgreementId, "major_incident_managers", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified first line support agreement using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreement">The first line support agreement for which to enumerate the major incident managers.</param>
            /// <param name="query">The query that defines which major incident managers to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(FirstLineSupportAgreement firstLineSupportAgreement, PersonQuery query, CancellationToken ct = default)
            {
                if (firstLineSupportAgreement is null)
                    throw new ArgumentNullException(nameof(firstLineSupportAgreement));

                return StreamAsync(firstLineSupportAgreement.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreementId">The identifier of the first line support agreement.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long firstLineSupportAgreementId, long personId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(firstLineSupportAgreementId, "major_incident_managers", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreementId">The identifier of the first line support agreement.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long firstLineSupportAgreementId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(firstLineSupportAgreementId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreement">The first line support agreement from which the person is removed.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(FirstLineSupportAgreement firstLineSupportAgreement, Person person, CancellationToken ct = default)
            {
                if (firstLineSupportAgreement is null)
                    throw new ArgumentNullException(nameof(firstLineSupportAgreement));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(firstLineSupportAgreement.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreement">The first line support agreement from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(FirstLineSupportAgreement firstLineSupportAgreement, long personId, CancellationToken ct = default)
            {
                if (firstLineSupportAgreement is null)
                    throw new ArgumentNullException(nameof(firstLineSupportAgreement));

                return await AddAsync(firstLineSupportAgreement.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreementId">The identifier of the first line support agreement.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long firstLineSupportAgreementId, long personId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(firstLineSupportAgreementId, "major_incident_managers", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreementId">The identifier of the first line support agreement.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long firstLineSupportAgreementId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(firstLineSupportAgreementId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreement">The first line support agreement from which the person is removed.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(FirstLineSupportAgreement firstLineSupportAgreement, Person person, CancellationToken ct = default)
            {
                if (firstLineSupportAgreement is null)
                    throw new ArgumentNullException(nameof(firstLineSupportAgreement));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(firstLineSupportAgreement.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreement">The first line support agreement from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(FirstLineSupportAgreement firstLineSupportAgreement, long personId, CancellationToken ct = default)
            {
                if (firstLineSupportAgreement is null)
                    throw new ArgumentNullException(nameof(firstLineSupportAgreement));

                return await RemoveAsync(firstLineSupportAgreement.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all major incident managers associated with a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreementId">The identifier of the first line support agreement.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long firstLineSupportAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(firstLineSupportAgreementId, "major_incident_managers", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all major incident managers associated with a <see cref="FirstLineSupportAgreement"/>.
            /// </summary>
            /// <param name="firstLineSupportAgreement">The first line support agreement from which all major incident managers are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(FirstLineSupportAgreement firstLineSupportAgreement, CancellationToken ct = default)
            {
                if (firstLineSupportAgreement is null)
                    throw new ArgumentNullException(nameof(firstLineSupportAgreement));

                return await RemoveAllAsync(firstLineSupportAgreement.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
