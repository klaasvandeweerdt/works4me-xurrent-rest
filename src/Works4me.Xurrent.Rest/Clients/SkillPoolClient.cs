using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="SkillPool"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/skill_pools/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class SkillPoolClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="SkillPool"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="EffortClass"/> records related to an <see cref="SkillPool"/>.
        /// </summary>
        public EffortClassesClient EffortClasses { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="Person"/> records related to an <see cref="SkillPool"/>.
        /// </summary>
        public MembersClient Members { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillPoolClient"/> class.
        /// </summary>
        internal SkillPoolClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "skill_pools/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            EffortClasses = new EffortClassesClient(this);
            Members = new MembersClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="SkillPool"/> using the specified <see cref="SkillPoolQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which skill pools to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="SkillPool"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<SkillPool>> GetAsync(SkillPoolQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<SkillPool>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="SkillPool"/> items as an asynchronous stream using the specified <see cref="SkillPoolQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which skill pools to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SkillPool"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<SkillPool> StreamAsync(SkillPoolQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<SkillPool>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="SkillPool"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the skill pool.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="SkillPool"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<SkillPool?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<SkillPool>(new SkillPoolQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="SkillPool"/>.
        /// </summary>
        /// <param name="skillPool">The skill pool to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="SkillPool"/>.</returns>
        public async Task<SkillPool> CreateAsync(SkillPool skillPool, CancellationToken ct = default)
        {
            return await PostItemAsync(skillPool, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="SkillPool"/>.
        /// </summary>
        /// <param name="skillPool">The skill pool to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="SkillPool"/>.</returns>
        public async Task<SkillPool> UpdateAsync(SkillPool skillPool, CancellationToken ct = default)
        {
            return await PatchItemAsync(skillPool, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="SkillPool"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly SkillPoolClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(SkillPoolClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified skill pool using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="skillPoolId">The unique identifier of the skill pool for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long skillPoolId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(skillPoolId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified skill pool using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(SkillPool skillPool, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await GetAsync(skillPool.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified skill pool using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="skillPoolId">The unique identifier of the skill pool for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long skillPoolId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(skillPoolId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified skill pool using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(SkillPool skillPool, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return StreamAsync(skillPool.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="EffortClass"/> records related to an <see cref="SkillPool"/>.
        /// </summary>
        public sealed class EffortClassesClient
        {
            private readonly SkillPoolClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="EffortClassesClient"/> class.
            /// </summary>
            internal EffortClassesClient(SkillPoolClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="EffortClass"/> records for the specified skill pool using an <see cref="EffortClassQuery"/>.
            /// </summary>
            /// <param name="skillPoolId">The unique identifier of the skill pool for which to retrieve the effort classes.</param>
            /// <param name="query">The query that defines which effort classes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="EffortClass"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<EffortClass>> GetAsync(long skillPoolId, EffortClassQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<EffortClass>(skillPoolId, "effort_classes", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="EffortClass"/> records for the specified skill pool using an <see cref="EffortClassQuery"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool for which to retrieve the effort classes.</param>
            /// <param name="query">The query that defines which effort classes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="EffortClass"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<EffortClass>> GetAsync(SkillPool skillPool, EffortClassQuery query, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await GetAsync(skillPool.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="EffortClass"/> items as an asynchronous stream for the specified skill pool using an <see cref="EffortClassQuery"/>.
            /// </summary>
            /// <param name="skillPoolId">The unique identifier of the skill pool for which to enumerate the effort classes.</param>
            /// <param name="query">The query that defines which effort classes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="EffortClass"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<EffortClass> StreamAsync(long skillPoolId, EffortClassQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<EffortClass>(skillPoolId, "effort_classes", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="EffortClass"/> items as an asynchronous stream for the specified skill pool using an <see cref="EffortClassQuery"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool for which to enumerate the effort classes.</param>
            /// <param name="query">The query that defines which effort classes to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="EffortClass"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<EffortClass> StreamAsync(SkillPool skillPool, EffortClassQuery query, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return StreamAsync(skillPool.Id, query, ct);
            }

            /// <summary>
            /// Add an <see cref="EffortClass"/> to a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="effortClassId">The identifier of the effort class to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long skillPoolId, long effortClassId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(skillPoolId, "effort_classes", effortClassId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="EffortClass"/> to a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="effortClass">The effort class to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long skillPoolId, EffortClass effortClass, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await AddAsync(skillPoolId, effortClass.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="EffortClass"/> to a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which the effort class is removed.</param>
            /// <param name="effortClass">The effort class to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(SkillPool skillPool, EffortClass effortClass, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await AddAsync(skillPool.Id, effortClass.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add an <see cref="EffortClass"/> to a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which the effort class is removed.</param>
            /// <param name="effortClassId">The identifier of the effort class to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(SkillPool skillPool, long effortClassId, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await AddAsync(skillPool.Id, effortClassId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="EffortClass"/> associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="effortClassId">The identifier of the effort class to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long skillPoolId, long effortClassId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(skillPoolId, "effort_classes", effortClassId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="EffortClass"/> associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="effortClass">The effort class to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long skillPoolId, EffortClass effortClass, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await RemoveAsync(skillPoolId, effortClass.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="EffortClass"/> associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which the effort class is removed.</param>
            /// <param name="effortClass">The effort class to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(SkillPool skillPool, EffortClass effortClass, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await RemoveAsync(skillPool.Id, effortClass.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove an <see cref="EffortClass"/> associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which the effort class is removed.</param>
            /// <param name="effortClassId">The identifier of the effort class to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(SkillPool skillPool, long effortClassId, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAsync(skillPool.Id, effortClassId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all effort classes associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long skillPoolId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(skillPoolId, "effort_classes", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all effort classes associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which all effort classes are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(SkillPool skillPool, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAllAsync(skillPool.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="Person"/> records related to an <see cref="SkillPool"/>.
        /// </summary>
        public sealed class MembersClient
        {
            private readonly SkillPoolClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="MembersClient"/> class.
            /// </summary>
            internal MembersClient(SkillPoolClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified skill pool using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="skillPoolId">The unique identifier of the skill pool for which to retrieve the members.</param>
            /// <param name="query">The query that defines which members to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(long skillPoolId, PersonQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<Person>(skillPoolId, "members", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="Person"/> records for the specified skill pool using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool for which to retrieve the members.</param>
            /// <param name="query">The query that defines which members to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="Person"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<Person>> GetAsync(SkillPool skillPool, PersonQuery query, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await GetAsync(skillPool.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified skill pool using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="skillPoolId">The unique identifier of the skill pool for which to enumerate the members.</param>
            /// <param name="query">The query that defines which members to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(long skillPoolId, PersonQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<Person>(skillPoolId, "members", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="Person"/> items as an asynchronous stream for the specified skill pool using an <see cref="PersonQuery"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool for which to enumerate the members.</param>
            /// <param name="query">The query that defines which members to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="Person"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<Person> StreamAsync(SkillPool skillPool, PersonQuery query, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return StreamAsync(skillPool.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long skillPoolId, long personId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(skillPoolId, "members", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long skillPoolId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(skillPoolId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which the person is removed.</param>
            /// <param name="person">The person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(SkillPool skillPool, Person person, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await AddAsync(skillPool.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="Person"/> to a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(SkillPool skillPool, long personId, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await AddAsync(skillPool.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long skillPoolId, long personId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(skillPoolId, "members", personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long skillPoolId, Person person, CancellationToken ct = default)
            {
                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(skillPoolId, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which the person is removed.</param>
            /// <param name="person">The person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(SkillPool skillPool, Person person, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                if (person is null)
                    throw new ArgumentNullException(nameof(person));

                return await RemoveAsync(skillPool.Id, person.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="Person"/> associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which the person is removed.</param>
            /// <param name="personId">The identifier of the person to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(SkillPool skillPool, long personId, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAsync(skillPool.Id, personId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all members associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPoolId">The identifier of the skill pool.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long skillPoolId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(skillPoolId, "members", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all members associated with a <see cref="SkillPool"/>.
            /// </summary>
            /// <param name="skillPool">The skill pool from which all members are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(SkillPool skillPool, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAllAsync(skillPool.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
