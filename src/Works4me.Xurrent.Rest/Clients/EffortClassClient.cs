using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="EffortClass"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/effort_classes/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class EffortClassClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="EffortClass"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceOffering"/> records related to an <see cref="EffortClass"/>.
        /// </summary>
        public ServiceOfferingsClient ServiceOfferings { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="SkillPool"/> records related to an <see cref="EffortClass"/>.
        /// </summary>
        public SkillPoolsClient SkillPools { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="TimesheetSetting"/> records related to an <see cref="EffortClass"/>.
        /// </summary>
        public TimesheetSettingsClient TimesheetSettings { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EffortClassClient"/> class.
        /// </summary>
        internal EffortClassClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "effort_classes/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            ServiceOfferings = new ServiceOfferingsClient(this);
            SkillPools = new SkillPoolsClient(this);
            TimesheetSettings = new TimesheetSettingsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="EffortClass"/> using the specified <see cref="EffortClassQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which effort classes to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="EffortClass"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<EffortClass>> GetAsync(EffortClassQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<EffortClass>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="EffortClass"/> items as an asynchronous stream using the specified <see cref="EffortClassQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which effort classes to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="EffortClass"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<EffortClass> StreamAsync(EffortClassQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<EffortClass>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="EffortClass"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the effort class.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="EffortClass"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<EffortClass?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<EffortClass>(new EffortClassQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="EffortClass"/>.
        /// </summary>
        /// <param name="effortClass">The effort class to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="EffortClass"/>.</returns>
        public async Task<EffortClass> CreateAsync(EffortClass effortClass, CancellationToken ct = default)
        {
            return await PostItemAsync(effortClass, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="EffortClass"/>.
        /// </summary>
        /// <param name="effortClass">The effort class to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="EffortClass"/>.</returns>
        public async Task<EffortClass> UpdateAsync(EffortClass effortClass, CancellationToken ct = default)
        {
            return await PatchItemAsync(effortClass, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="EffortClass"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly EffortClassClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(EffortClassClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified effort class using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="effortClassId">The unique identifier of the effort class for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long effortClassId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(effortClassId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified effort class using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="effortClass">The effort class for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(EffortClass effortClass, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await GetAsync(effortClass.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified effort class using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="effortClassId">The unique identifier of the effort class for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long effortClassId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(effortClassId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified effort class using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="effortClass">The effort class for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(EffortClass effortClass, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return StreamAsync(effortClass.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceOffering"/> records related to an <see cref="EffortClass"/>.
        /// </summary>
        public sealed class ServiceOfferingsClient
        {
            private readonly EffortClassClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceOfferingsClient"/> class.
            /// </summary>
            internal ServiceOfferingsClient(EffortClassClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceOffering"/> records for the specified effort class using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="effortClassId">The unique identifier of the effort class for which to retrieve the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceOffering>> GetAsync(long effortClassId, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceOffering>(effortClassId, "service_offerings", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceOffering"/> records for the specified effort class using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="effortClass">The effort class for which to retrieve the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceOffering"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceOffering>> GetAsync(EffortClass effortClass, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await GetAsync(effortClass.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceOffering"/> items as an asynchronous stream for the specified effort class using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="effortClassId">The unique identifier of the effort class for which to enumerate the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceOffering> StreamAsync(long effortClassId, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceOffering>(effortClassId, "service_offerings", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceOffering"/> items as an asynchronous stream for the specified effort class using an <see cref="ServiceOfferingQuery"/>.
            /// </summary>
            /// <param name="effortClass">The effort class for which to enumerate the service offerings.</param>
            /// <param name="query">The query that defines which service offerings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceOffering"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceOffering> StreamAsync(EffortClass effortClass, ServiceOfferingQuery query, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return StreamAsync(effortClass.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceOffering"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="serviceOfferingId">The identifier of the service offering to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long effortClassId, long serviceOfferingId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(effortClassId, "service_offerings", serviceOfferingId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceOffering"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="serviceOffering">The service offering to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long effortClassId, ServiceOffering serviceOffering, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await AddAsync(effortClassId, serviceOffering.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceOffering"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the service offering is removed.</param>
            /// <param name="serviceOffering">The service offering to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(EffortClass effortClass, ServiceOffering serviceOffering, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await AddAsync(effortClass.Id, serviceOffering.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceOffering"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the service offering is removed.</param>
            /// <param name="serviceOfferingId">The identifier of the service offering to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(EffortClass effortClass, long serviceOfferingId, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await AddAsync(effortClass.Id, serviceOfferingId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceOffering"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="serviceOfferingId">The identifier of the service offering to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long effortClassId, long serviceOfferingId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(effortClassId, "service_offerings", serviceOfferingId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceOffering"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="serviceOffering">The service offering to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long effortClassId, ServiceOffering serviceOffering, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await RemoveAsync(effortClassId, serviceOffering.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceOffering"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the service offering is removed.</param>
            /// <param name="serviceOffering">The service offering to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(EffortClass effortClass, ServiceOffering serviceOffering, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await RemoveAsync(effortClass.Id, serviceOffering.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceOffering"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the service offering is removed.</param>
            /// <param name="serviceOfferingId">The identifier of the service offering to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(EffortClass effortClass, long serviceOfferingId, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await RemoveAsync(effortClass.Id, serviceOfferingId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service offerings associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long effortClassId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(effortClassId, "service_offerings", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service offerings associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which all service offerings are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(EffortClass effortClass, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await RemoveAllAsync(effortClass.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="SkillPool"/> records related to an <see cref="EffortClass"/>.
        /// </summary>
        public sealed class SkillPoolsClient
        {
            private readonly EffortClassClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="SkillPoolsClient"/> class.
            /// </summary>
            internal SkillPoolsClient(EffortClassClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="SkillPool"/> records for the specified effort class using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="effortClassId">The unique identifier of the effort class for which to retrieve the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SkillPool"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SkillPool>> GetAsync(long effortClassId, SkillPoolQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<SkillPool>(effortClassId, "skill_pools", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="SkillPool"/> records for the specified effort class using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="effortClass">The effort class for which to retrieve the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="SkillPool"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<SkillPool>> GetAsync(EffortClass effortClass, SkillPoolQuery query, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await GetAsync(effortClass.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="SkillPool"/> items as an asynchronous stream for the specified effort class using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="effortClassId">The unique identifier of the effort class for which to enumerate the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SkillPool"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SkillPool> StreamAsync(long effortClassId, SkillPoolQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<SkillPool>(effortClassId, "skill_pools", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="SkillPool"/> items as an asynchronous stream for the specified effort class using an <see cref="SkillPoolQuery"/>.
            /// </summary>
            /// <param name="effortClass">The effort class for which to enumerate the skill pools.</param>
            /// <param name="query">The query that defines which skill pools to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SkillPool"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<SkillPool> StreamAsync(EffortClass effortClass, SkillPoolQuery query, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return StreamAsync(effortClass.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long effortClassId, long skillPoolId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(effortClassId, "skill_pools", skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="skillPool">The skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long effortClassId, SkillPool skillPool, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await AddAsync(effortClassId, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the skill pool is removed.</param>
            /// <param name="skillPool">The skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(EffortClass effortClass, SkillPool skillPool, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await AddAsync(effortClass.Id, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="SkillPool"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the skill pool is removed.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(EffortClass effortClass, long skillPoolId, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await AddAsync(effortClass.Id, skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long effortClassId, long skillPoolId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(effortClassId, "skill_pools", skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="skillPool">The skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long effortClassId, SkillPool skillPool, CancellationToken ct = default)
            {
                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAsync(effortClassId, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the skill pool is removed.</param>
            /// <param name="skillPool">The skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(EffortClass effortClass, SkillPool skillPool, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                if (skillPool is null)
                    throw new ArgumentNullException(nameof(skillPool));

                return await RemoveAsync(effortClass.Id, skillPool.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="SkillPool"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the skill pool is removed.</param>
            /// <param name="skillPoolId">The identifier of the skill pool to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(EffortClass effortClass, long skillPoolId, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await RemoveAsync(effortClass.Id, skillPoolId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all skill pools associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long effortClassId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(effortClassId, "skill_pools", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all skill pools associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which all skill pools are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(EffortClass effortClass, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await RemoveAllAsync(effortClass.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="TimesheetSetting"/> records related to an <see cref="EffortClass"/>.
        /// </summary>
        public sealed class TimesheetSettingsClient
        {
            private readonly EffortClassClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="TimesheetSettingsClient"/> class.
            /// </summary>
            internal TimesheetSettingsClient(EffortClassClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="TimesheetSetting"/> records for the specified effort class using an <see cref="TimesheetSettingQuery"/>.
            /// </summary>
            /// <param name="effortClassId">The unique identifier of the effort class for which to retrieve the timesheet settings.</param>
            /// <param name="query">The query that defines which timesheet settings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="TimesheetSetting"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<TimesheetSetting>> GetAsync(long effortClassId, TimesheetSettingQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<TimesheetSetting>(effortClassId, "timesheet_settings", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="TimesheetSetting"/> records for the specified effort class using an <see cref="TimesheetSettingQuery"/>.
            /// </summary>
            /// <param name="effortClass">The effort class for which to retrieve the timesheet settings.</param>
            /// <param name="query">The query that defines which timesheet settings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="TimesheetSetting"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<TimesheetSetting>> GetAsync(EffortClass effortClass, TimesheetSettingQuery query, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await GetAsync(effortClass.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="TimesheetSetting"/> items as an asynchronous stream for the specified effort class using an <see cref="TimesheetSettingQuery"/>.
            /// </summary>
            /// <param name="effortClassId">The unique identifier of the effort class for which to enumerate the timesheet settings.</param>
            /// <param name="query">The query that defines which timesheet settings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="TimesheetSetting"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<TimesheetSetting> StreamAsync(long effortClassId, TimesheetSettingQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<TimesheetSetting>(effortClassId, "timesheet_settings", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="TimesheetSetting"/> items as an asynchronous stream for the specified effort class using an <see cref="TimesheetSettingQuery"/>.
            /// </summary>
            /// <param name="effortClass">The effort class for which to enumerate the timesheet settings.</param>
            /// <param name="query">The query that defines which timesheet settings to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="TimesheetSetting"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<TimesheetSetting> StreamAsync(EffortClass effortClass, TimesheetSettingQuery query, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return StreamAsync(effortClass.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="TimesheetSetting"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="timesheetSettingId">The identifier of the timesheet setting to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long effortClassId, long timesheetSettingId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(effortClassId, "timesheet_settings", timesheetSettingId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="TimesheetSetting"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="timesheetSetting">The timesheet setting to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long effortClassId, TimesheetSetting timesheetSetting, CancellationToken ct = default)
            {
                if (timesheetSetting is null)
                    throw new ArgumentNullException(nameof(timesheetSetting));

                return await AddAsync(effortClassId, timesheetSetting.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="TimesheetSetting"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the timesheet setting is removed.</param>
            /// <param name="timesheetSetting">The timesheet setting to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(EffortClass effortClass, TimesheetSetting timesheetSetting, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                if (timesheetSetting is null)
                    throw new ArgumentNullException(nameof(timesheetSetting));

                return await AddAsync(effortClass.Id, timesheetSetting.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="TimesheetSetting"/> to an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the timesheet setting is removed.</param>
            /// <param name="timesheetSettingId">The identifier of the timesheet setting to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(EffortClass effortClass, long timesheetSettingId, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await AddAsync(effortClass.Id, timesheetSettingId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="TimesheetSetting"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="timesheetSettingId">The identifier of the timesheet setting to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long effortClassId, long timesheetSettingId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(effortClassId, "timesheet_settings", timesheetSettingId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="TimesheetSetting"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="timesheetSetting">The timesheet setting to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long effortClassId, TimesheetSetting timesheetSetting, CancellationToken ct = default)
            {
                if (timesheetSetting is null)
                    throw new ArgumentNullException(nameof(timesheetSetting));

                return await RemoveAsync(effortClassId, timesheetSetting.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="TimesheetSetting"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the timesheet setting is removed.</param>
            /// <param name="timesheetSetting">The timesheet setting to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(EffortClass effortClass, TimesheetSetting timesheetSetting, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                if (timesheetSetting is null)
                    throw new ArgumentNullException(nameof(timesheetSetting));

                return await RemoveAsync(effortClass.Id, timesheetSetting.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="TimesheetSetting"/> associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which the timesheet setting is removed.</param>
            /// <param name="timesheetSettingId">The identifier of the timesheet setting to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(EffortClass effortClass, long timesheetSettingId, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await RemoveAsync(effortClass.Id, timesheetSettingId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all timesheet settings associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClassId">The identifier of the effort class.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long effortClassId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(effortClassId, "timesheet_settings", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all timesheet settings associated with an <see cref="EffortClass"/>.
            /// </summary>
            /// <param name="effortClass">The effort class from which all timesheet settings are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(EffortClass effortClass, CancellationToken ct = default)
            {
                if (effortClass is null)
                    throw new ArgumentNullException(nameof(effortClass));

                return await RemoveAllAsync(effortClass.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
