using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ServiceOffering"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/service_offerings/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed partial class ServiceOfferingClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ServiceOffering"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="EffortClassRate"/> records related to an <see cref="ServiceOffering"/>.
        /// </summary>
        public EffortClassRatesClient EffortClassRates { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="RfcTypeRate"/> records related to an <see cref="ServiceOffering"/>.
        /// </summary>
        public RfcTypeRatesClient RfcTypeRates { get; }

        /// <summary>
        /// Gets the client for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="ServiceOffering"/>.
        /// </summary>
        public ServiceLevelAgreementsClient ServiceLevelAgreements { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceOfferingClient"/> class.
        /// </summary>
        internal ServiceOfferingClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "service_offerings/"))
        {
            AuditEntries = new AuditEntriesClient(this);
            EffortClassRates = new EffortClassRatesClient(this);
            RfcTypeRates = new RfcTypeRatesClient(this);
            ServiceLevelAgreements = new ServiceLevelAgreementsClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ServiceOffering"/> using the specified <see cref="ServiceOfferingQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service offerings to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ServiceOffering"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ServiceOffering>> GetAsync(ServiceOfferingQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ServiceOffering>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ServiceOffering"/> items as an asynchronous stream using the specified <see cref="ServiceOfferingQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which service offerings to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceOffering"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ServiceOffering> StreamAsync(ServiceOfferingQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ServiceOffering>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ServiceOffering"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the service offering.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ServiceOffering"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ServiceOffering?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ServiceOffering>(new ServiceOfferingQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ServiceOffering"/>.
        /// </summary>
        /// <param name="serviceOffering">The service offering to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ServiceOffering"/>.</returns>
        public async Task<ServiceOffering> CreateAsync(ServiceOffering serviceOffering, CancellationToken ct = default)
        {
            return await PostItemAsync(serviceOffering, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ServiceOffering"/>.
        /// </summary>
        /// <param name="serviceOffering">The service offering to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ServiceOffering"/>.</returns>
        public async Task<ServiceOffering> UpdateAsync(ServiceOffering serviceOffering, CancellationToken ct = default)
        {
            return await PatchItemAsync(serviceOffering, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ServiceOffering"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ServiceOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ServiceOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The unique identifier of the service offering for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long serviceOfferingId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(serviceOfferingId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified service offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ServiceOffering serviceOffering, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await GetAsync(serviceOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The unique identifier of the service offering for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long serviceOfferingId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(serviceOfferingId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified service offering using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ServiceOffering serviceOffering, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return StreamAsync(serviceOffering.Id, query, ct);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="EffortClassRate"/> records related to an <see cref="ServiceOffering"/>.
        /// </summary>
        public sealed class EffortClassRatesClient
        {
            private readonly ServiceOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="EffortClassRatesClient"/> class.
            /// </summary>
            internal EffortClassRatesClient(ServiceOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="EffortClassRate"/> records for the specified service offering using an <see cref="EffortClassRateQuery"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The unique identifier of the service offering for which to retrieve the effort class rates.</param>
            /// <param name="query">The query that defines which effort class rates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="EffortClassRate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<EffortClassRate>> GetAsync(long serviceOfferingId, EffortClassRateQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<EffortClassRate>(serviceOfferingId, "effort_class_rates", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="EffortClassRate"/> records for the specified service offering using an <see cref="EffortClassRateQuery"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering for which to retrieve the effort class rates.</param>
            /// <param name="query">The query that defines which effort class rates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="EffortClassRate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<EffortClassRate>> GetAsync(ServiceOffering serviceOffering, EffortClassRateQuery query, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await GetAsync(serviceOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="EffortClassRate"/> items as an asynchronous stream for the specified service offering using an <see cref="EffortClassRateQuery"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The unique identifier of the service offering for which to enumerate the effort class rates.</param>
            /// <param name="query">The query that defines which effort class rates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="EffortClassRate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<EffortClassRate> StreamAsync(long serviceOfferingId, EffortClassRateQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<EffortClassRate>(serviceOfferingId, "effort_class_rates", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="EffortClassRate"/> items as an asynchronous stream for the specified service offering using an <see cref="EffortClassRateQuery"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering for which to enumerate the effort class rates.</param>
            /// <param name="query">The query that defines which effort class rates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="EffortClassRate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<EffortClassRate> StreamAsync(ServiceOffering serviceOffering, EffortClassRateQuery query, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return StreamAsync(serviceOffering.Id, query, ct);
            }

            /// <summary>
            /// Returns a single <see cref="EffortClassRate"/> by its unique identifier for the specified service offering.
            /// </summary>
            /// <param name="serviceOfferingId">The unique identifier of the service offering.</param>
            /// <param name="effortClassRateId">The unique identifier of the effort class rate.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="EffortClassRate"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<EffortClassRate?> GetAsync(long serviceOfferingId, long effortClassRateId, CancellationToken ct = default)
            {
                return await _client.GetItemAsync<EffortClassRate>(serviceOfferingId, "effort_class_rates", new EffortClassRateQuery().WithId(effortClassRateId), ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a single <see cref="EffortClassRate"/> record for the specified service offering.
            /// </summary>
            /// <param name="serviceOffering">The service offering for which to retrieve the effort class rate.</param>
            /// <param name="effortClassRateId">The unique identifier of the effort class rate.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The requested <see cref="EffortClassRate"/>, or <see langword="null"/> if no matching record is found.</returns>
            public async Task<EffortClassRate?> GetAsync(ServiceOffering serviceOffering, long effortClassRateId, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await GetAsync(serviceOffering.Id, effortClassRateId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="EffortClassRate"/> to a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="effortClassRate">The effort class rate to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="EffortClassRate"/>.</returns>
            public async Task<EffortClassRate> CreateAsync(long serviceOfferingId, EffortClassRate effortClassRate, CancellationToken ct = default)
            {
                return await _client.PostItemAsync(serviceOfferingId, "effort_class_rates", effortClassRate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Create an <see cref="EffortClassRate"/> to a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering to which the effort class rate is added.</param>
            /// <param name="effortClassRate">The effort class rate to create.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="EffortClassRate"/>.</returns>
            public async Task<EffortClassRate> CreateAsync(ServiceOffering serviceOffering, EffortClassRate effortClassRate, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await CreateAsync(serviceOffering.Id, effortClassRate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="EffortClassRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="effortClassRate">The effort class rate to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="EffortClassRate"/>.</returns>
            public async Task<EffortClassRate> UpdateAsync(long serviceOfferingId, EffortClassRate effortClassRate, CancellationToken ct = default)
            {
                return await _client.PatchItemAsync(serviceOfferingId, "effort_class_rates", effortClassRate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Update an <see cref="EffortClassRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering with which the effort class rate is associated.</param>
            /// <param name="effortClassRate">The effort class rate to update.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>The resulting <see cref="EffortClassRate"/>.</returns>
            public async Task<EffortClassRate> UpdateAsync(ServiceOffering serviceOffering, EffortClassRate effortClassRate, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await UpdateAsync(serviceOffering.Id, effortClassRate, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="EffortClassRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="effortClassRateId">The identifier of the effort class rate to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long serviceOfferingId, long effortClassRateId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceOfferingId, "effort_class_rates", effortClassRateId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="EffortClassRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="effortClassRate">The effort class rate to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long serviceOfferingId, EffortClassRate effortClassRate, CancellationToken ct = default)
            {
                if (effortClassRate is null)
                    throw new ArgumentNullException(nameof(effortClassRate));

                return await DeleteAsync(serviceOfferingId, effortClassRate.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="EffortClassRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering from which the effort class rate is removed.</param>
            /// <param name="effortClassRate">The effort class rate to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ServiceOffering serviceOffering, EffortClassRate effortClassRate, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                if (effortClassRate is null)
                    throw new ArgumentNullException(nameof(effortClassRate));

                return await DeleteAsync(serviceOffering.Id, effortClassRate.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete an <see cref="EffortClassRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering from which the effort class rate is removed.</param>
            /// <param name="effortClassRateId">The identifier of the effort class rate to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(ServiceOffering serviceOffering, long effortClassRateId, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await DeleteAsync(serviceOffering.Id, effortClassRateId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all effort class rates associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(long serviceOfferingId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceOfferingId, "effort_class_rates", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete all effort class rates associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering from which all effort class rates are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAllAsync(ServiceOffering serviceOffering, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await DeleteAllAsync(serviceOffering.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="RfcTypeRate"/> records related to an <see cref="ServiceOffering"/>.
        /// </summary>
        public sealed partial class RfcTypeRatesClient
        {
            private readonly ServiceOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="RfcTypeRatesClient"/> class.
            /// </summary>
            internal RfcTypeRatesClient(ServiceOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="RfcTypeRate"/> records for the specified service offering using an <see cref="RfcTypeRateQuery"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The unique identifier of the service offering for which to retrieve the rfc type rates.</param>
            /// <param name="query">The query that defines which rfc type rates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="RfcTypeRate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<RfcTypeRate>> GetAsync(long serviceOfferingId, RfcTypeRateQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<RfcTypeRate>(serviceOfferingId, "rfc_type_rates", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="RfcTypeRate"/> records for the specified service offering using an <see cref="RfcTypeRateQuery"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering for which to retrieve the rfc type rates.</param>
            /// <param name="query">The query that defines which rfc type rates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="RfcTypeRate"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<RfcTypeRate>> GetAsync(ServiceOffering serviceOffering, RfcTypeRateQuery query, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await GetAsync(serviceOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="RfcTypeRate"/> items as an asynchronous stream for the specified service offering using an <see cref="RfcTypeRateQuery"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The unique identifier of the service offering for which to enumerate the rfc type rates.</param>
            /// <param name="query">The query that defines which rfc type rates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RfcTypeRate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<RfcTypeRate> StreamAsync(long serviceOfferingId, RfcTypeRateQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<RfcTypeRate>(serviceOfferingId, "rfc_type_rates", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="RfcTypeRate"/> items as an asynchronous stream for the specified service offering using an <see cref="RfcTypeRateQuery"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering for which to enumerate the rfc type rates.</param>
            /// <param name="query">The query that defines which rfc type rates to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RfcTypeRate"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<RfcTypeRate> StreamAsync(ServiceOffering serviceOffering, RfcTypeRateQuery query, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return StreamAsync(serviceOffering.Id, query, ct);
            }

            /// <summary>
            /// Remove a <see cref="RfcTypeRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="rfcTypeRateId">The identifier of the rfc type rate to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceOfferingId, long rfcTypeRateId, CancellationToken ct = default)
            {
                return await _client.DeleteItemAsync(serviceOfferingId, "rfc_type_rates", rfcTypeRateId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="RfcTypeRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="rfcTypeRate">The rfc type rate to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(long serviceOfferingId, RfcTypeRate rfcTypeRate, CancellationToken ct = default)
            {
                if (rfcTypeRate is null)
                    throw new ArgumentNullException(nameof(rfcTypeRate));

                return await RemoveAsync(serviceOfferingId, rfcTypeRate.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="RfcTypeRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering from which the rfc type rate is removed.</param>
            /// <param name="rfcTypeRate">The rfc type rate to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceOffering serviceOffering, RfcTypeRate rfcTypeRate, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                if (rfcTypeRate is null)
                    throw new ArgumentNullException(nameof(rfcTypeRate));

                return await RemoveAsync(serviceOffering.Id, rfcTypeRate.Id, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove a <see cref="RfcTypeRate"/> associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering from which the rfc type rate is removed.</param>
            /// <param name="rfcTypeRateId">The identifier of the rfc type rate to remove.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAsync(ServiceOffering serviceOffering, long rfcTypeRateId, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await RemoveAsync(serviceOffering.Id, rfcTypeRateId, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all rfc type rates associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The identifier of the service offering.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(long serviceOfferingId, CancellationToken ct = default)
            {
                return await _client.DeleteAllItemsAsync(serviceOfferingId, "rfc_type_rates", ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Remove all rfc type rates associated with a <see cref="ServiceOffering"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering from which all rfc type rates are removed.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> RemoveAllAsync(ServiceOffering serviceOffering, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await RemoveAllAsync(serviceOffering.Id, ct).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="ServiceLevelAgreement"/> records related to an <see cref="ServiceOffering"/>.
        /// </summary>
        public sealed class ServiceLevelAgreementsClient
        {
            private readonly ServiceOfferingClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceLevelAgreementsClient"/> class.
            /// </summary>
            internal ServiceLevelAgreementsClient(ServiceOfferingClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified service offering using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The unique identifier of the service offering for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(long serviceOfferingId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<ServiceLevelAgreement>(serviceOfferingId, "slas", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="ServiceLevelAgreement"/> records for the specified service offering using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering for which to retrieve the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="ServiceLevelAgreement"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<ServiceLevelAgreement>> GetAsync(ServiceOffering serviceOffering, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return await GetAsync(serviceOffering.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified service offering using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceOfferingId">The unique identifier of the service offering for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(long serviceOfferingId, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<ServiceLevelAgreement>(serviceOfferingId, "slas", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="ServiceLevelAgreement"/> items as an asynchronous stream for the specified service offering using an <see cref="ServiceLevelAgreementQuery"/>.
            /// </summary>
            /// <param name="serviceOffering">The service offering for which to enumerate the service level agreements.</param>
            /// <param name="query">The query that defines which service level agreements to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ServiceLevelAgreement"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<ServiceLevelAgreement> StreamAsync(ServiceOffering serviceOffering, ServiceLevelAgreementQuery query, CancellationToken ct = default)
            {
                if (serviceOffering is null)
                    throw new ArgumentNullException(nameof(serviceOffering));

                return StreamAsync(serviceOffering.Id, query, ct);
            }
        }
    }
}
