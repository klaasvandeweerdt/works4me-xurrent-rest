using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="Team"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/teams/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class TeamClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="Team"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Person"/> records related to an <see cref="Team"/>.
        /// </summary>
        public MembersClient Members { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceInstance"/> records related to an <see cref="Team"/>.
        /// </summary>
        public ServiceInstancesClient ServiceInstances { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamClient"/> class.
        /// </summary>
        internal TeamClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "teams/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            Members = new MembersClient(this);
            ServiceInstances = new ServiceInstancesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Team"/> using the specified <see cref="TeamQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which teams to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="Team"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<Team>> GetAsync(TeamQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<Team>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="Team"/> items as an asynchronous stream using the specified <see cref="TeamQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which teams to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Team"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<Team> StreamAsync(TeamQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<Team>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="Team"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the team.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="Team"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<Team?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<Team>(new TeamQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="Team"/>.
        /// </summary>
        /// <param name="team">The team to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="Team"/>.</returns>
        public async Task<Team> CreateAsync(Team team, CancellationToken ct = default)
        {
            return await PostItemAsync(team, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="Team"/>.
        /// </summary>
        /// <param name="team">The team to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="Team"/>.</returns>
        public async Task<Team> UpdateAsync(Team team, CancellationToken ct = default)
        {
            return await PatchItemAsync(team, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="Team"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly TeamClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(TeamClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified team using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="teamId">The unique identifier of the team for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long teamId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(teamId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified team using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="team">The team for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(Team team, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await GetAsync(team.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified team using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="teamId">The unique identifier of the team for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long teamId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(teamId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified team using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="team">The team for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(Team team, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return StreamAsync(team.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Person"/> records related to an <see cref="Team"/>.
        /// </summary>
        public sealed class MembersClient
        {
            private readonly TeamClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="MembersClient"/> class.
            /// </summary>
            internal MembersClient(TeamClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified team using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="teamId">The unique identifier of the team for which to retrieve the members.</param>
            /// <param name="query">The query that defines which members to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(long teamId, PersonQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Person>(teamId, "members", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified team using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="team">The team for which to retrieve the members.</param>
            /// <param name="query">The query that defines which members to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(Team team, PersonQuery query, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await GetAsync(team.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified team using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="teamId">The unique identifier of the team for which to enumerate the members.</param>
            /// <param name="query">The query that defines which members to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(long teamId, PersonQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Person>(teamId, "members", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified team using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="team">The team for which to enumerate the members.</param>
            /// <param name="query">The query that defines which members to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(Team team, PersonQuery query, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return StreamAsync(team.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="Team"/>.
            /// </summary>
            /// <param name="teamId">The identifier of the team.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long teamId, long personId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(teamId, "members", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="Team"/>.
            /// </summary>
            /// <param name="teamId">The identifier of the team.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long teamId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(teamId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="Team"/>.
            /// </summary>
            /// <param name="team">The team from which the person is removed.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Team team, Person person, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(team.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="Team"/>.
            /// </summary>
            /// <param name="team">The team from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(Team team, long personId, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await AddAsync(team.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="Team"/>.
            /// </summary>
            /// <param name="teamId">The identifier of the team.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long teamId, long personId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(teamId, "members", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="Team"/>.
            /// </summary>
            /// <param name="teamId">The identifier of the team.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long teamId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(teamId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="Team"/>.
            /// </summary>
            /// <param name="team">The team from which the person is removed.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Team team, Person person, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(team.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="Team"/>.
            /// </summary>
            /// <param name="team">The team from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(Team team, long personId, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await RemoveAsync(team.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all members associated with a <see cref="Team"/>.
            /// </summary>
            /// <param name="teamId">The identifier of the team.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long teamId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(teamId, "members", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all members associated with a <see cref="Team"/>.
            /// </summary>
            /// <param name="team">The team from which all members are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(Team team, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await RemoveAllAsync(team.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceInstance"/> records related to an <see cref="Team"/>.
        /// </summary>
        public sealed class ServiceInstancesClient
        {
            private readonly TeamClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceInstancesClient"/> class.
            /// </summary>
            internal ServiceInstancesClient(TeamClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified team using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="teamId">The unique identifier of the team for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(long teamId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceInstance>(teamId, "service_instances", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceInstance"/> records for the specified team using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="team">The team for which to retrieve the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceInstance"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceInstance>> GetAsync(Team team, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return await GetAsync(team.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified team using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="teamId">The unique identifier of the team for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(long teamId, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceInstance>(teamId, "service_instances", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceInstance"/> items as an asynchronous stream for the specified team using an <see cref="ServiceInstanceQuery"/>.
            /// </summary>
            /// <param name="team">The team for which to enumerate the service instances.</param>
            /// <param name="query">The query that defines which service instances to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceInstance"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceInstance> StreamAsync(Team team, ServiceInstanceQuery query, CancellationToken ct = default)
            {
                if (team is null)
                    throw new ArgumentNullException(nameof(team));

                return StreamAsync(team.Id, query, ct);
            }
        }
    }
}
