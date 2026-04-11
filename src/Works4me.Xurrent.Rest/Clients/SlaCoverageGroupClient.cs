using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="SlaCoverageGroup"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/sla_coverage_groups/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class SlaCoverageGroupClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="SlaCoverageGroup"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="SlaCoverageGroup"/>.
        /// </summary>
        public ServiceLevelAgreementsClient ServiceLevelAgreements { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SlaCoverageGroupClient"/> class.
        /// </summary>
        internal SlaCoverageGroupClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "sla_coverage_groups/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            ServiceLevelAgreements = new ServiceLevelAgreementsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="SlaCoverageGroup"/> using the specified <see cref="SlaCoverageGroupQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service level agreement coverage groups to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="SlaCoverageGroup"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<SlaCoverageGroup>> GetAsync(SlaCoverageGroupQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<SlaCoverageGroup>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="SlaCoverageGroup"/> items as an asynchronous stream using the specified <see cref="SlaCoverageGroupQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service level agreement coverage groups to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="SlaCoverageGroup"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<SlaCoverageGroup> StreamAsync(SlaCoverageGroupQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<SlaCoverageGroup>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="SlaCoverageGroup"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service level agreement coverage group.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="SlaCoverageGroup"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<SlaCoverageGroup?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<SlaCoverageGroup>(new SlaCoverageGroupQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="SlaCoverageGroup"/>.
        /// </summary>
        /// <param name="slaCoverageGroup">The service level agreement coverage group to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="SlaCoverageGroup"/>.</returns>
        public async Task<SlaCoverageGroup> CreateAsync(SlaCoverageGroup slaCoverageGroup, CancellationToken ct = default)
        {
            return await PostItemAsync(slaCoverageGroup, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="SlaCoverageGroup"/>.
        /// </summary>
        /// <param name="slaCoverageGroup">The service level agreement coverage group to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="SlaCoverageGroup"/>.</returns>
        public async Task<SlaCoverageGroup> UpdateAsync(SlaCoverageGroup slaCoverageGroup, CancellationToken ct = default)
        {
            return await PatchItemAsync(slaCoverageGroup, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="SlaCoverageGroup"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly SlaCoverageGroupClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(SlaCoverageGroupClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service level agreement coverage group using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="slaCoverageGroupId">The unique identifier of the service level agreement coverage group for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long slaCoverageGroupId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(slaCoverageGroupId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service level agreement coverage group using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="slaCoverageGroup">The service level agreement coverage group for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(SlaCoverageGroup slaCoverageGroup, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return await GetAsync(slaCoverageGroup.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service level agreement coverage group using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="slaCoverageGroupId">The unique identifier of the service level agreement coverage group for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long slaCoverageGroupId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(slaCoverageGroupId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service level agreement coverage group using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="slaCoverageGroup">The service level agreement coverage group for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(SlaCoverageGroup slaCoverageGroup, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return StreamAsync(slaCoverageGroup.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="SlaCoverageGroup"/>.
        /// </summary>
        public sealed class ServiceLevelAgreementsClient
        {
            private readonly SlaCoverageGroupClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceLevelAgreementsClient"/> class.
            /// </summary>
            internal ServiceLevelAgreementsClient(SlaCoverageGroupClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified service level agreement coverage group using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="slaCoverageGroupId">The unique identifier of the service level agreement coverage group for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(long slaCoverageGroupId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceLevelAgreement>(slaCoverageGroupId, "slas", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified service level agreement coverage group using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="slaCoverageGroup">The service level agreement coverage group for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(SlaCoverageGroup slaCoverageGroup, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return await GetAsync(slaCoverageGroup.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified service level agreement coverage group using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="slaCoverageGroupId">The unique identifier of the service level agreement coverage group for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(long slaCoverageGroupId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceLevelAgreement>(slaCoverageGroupId, "slas", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified service level agreement coverage group using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="slaCoverageGroup">The service level agreement coverage group for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(SlaCoverageGroup slaCoverageGroup, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return StreamAsync(slaCoverageGroup.Id, query, ct);
            }

            /// <summary>
            /// Add a <see cref="ServiceLevelAgreement"/> to a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroupId">The identifier of the service level agreement coverage group.</param>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long slaCoverageGroupId, long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(slaCoverageGroupId, "slas", serviceLevelAgreementId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceLevelAgreement"/> to a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroupId">The identifier of the service level agreement coverage group.</param>
            /// <param name="serviceLevelAgreement">The service level agreement to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(long slaCoverageGroupId, ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(slaCoverageGroupId, serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceLevelAgreement"/> to a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroup">The service level agreement coverage group from which the service level agreement is removed.</param>
            /// <param name="serviceLevelAgreement">The service level agreement to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(SlaCoverageGroup slaCoverageGroup, ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await AddAsync(slaCoverageGroup.Id, serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Add a <see cref="ServiceLevelAgreement"/> to a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroup">The service level agreement coverage group from which the service level agreement is removed.</param>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement to add.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> AddAsync(SlaCoverageGroup slaCoverageGroup, long serviceLevelAgreementId, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return await AddAsync(slaCoverageGroup.Id, serviceLevelAgreementId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceLevelAgreement"/> associated with a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroupId">The identifier of the service level agreement coverage group.</param>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long slaCoverageGroupId, long serviceLevelAgreementId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(slaCoverageGroupId, "slas", serviceLevelAgreementId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceLevelAgreement"/> associated with a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroupId">The identifier of the service level agreement coverage group.</param>
            /// <param name="serviceLevelAgreement">The service level agreement to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long slaCoverageGroupId, ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(slaCoverageGroupId, serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceLevelAgreement"/> associated with a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroup">The service level agreement coverage group from which the service level agreement is removed.</param>
            /// <param name="serviceLevelAgreement">The service level agreement to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(SlaCoverageGroup slaCoverageGroup, ServiceLevelAgreement serviceLevelAgreement, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                if (serviceLevelAgreement is null)
                    throw new ArgumentNullException(nameof(serviceLevelAgreement));

                return await RemoveAsync(slaCoverageGroup.Id, serviceLevelAgreement.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="ServiceLevelAgreement"/> associated with a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroup">The service level agreement coverage group from which the service level agreement is removed.</param>
            /// <param name="serviceLevelAgreementId">The identifier of the service level agreement to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(SlaCoverageGroup slaCoverageGroup, long serviceLevelAgreementId, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return await RemoveAsync(slaCoverageGroup.Id, serviceLevelAgreementId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service level agreements associated with a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroupId">The identifier of the service level agreement coverage group.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long slaCoverageGroupId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(slaCoverageGroupId, "slas", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all service level agreements associated with a <see cref="SlaCoverageGroup"/>.
            /// </summary>
            /// <param name="slaCoverageGroup">The service level agreement coverage group from which all service level agreements are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(SlaCoverageGroup slaCoverageGroup, CancellationToken ct = default)
            {
                if (slaCoverageGroup is null)
                    throw new ArgumentNullException(nameof(slaCoverageGroup));

                return await RemoveAllAsync(slaCoverageGroup.Id, ct).ConfigureAwait(false);
            }
        }
    }
}
