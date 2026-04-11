using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="OutOfOfficePeriod"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/out_of_office_periods/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class OutOfOfficePeriodClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="OutOfOfficePeriod"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutOfOfficePeriodClient"/> class.
        /// </summary>
        internal OutOfOfficePeriodClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "out_of_office_periods/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="OutOfOfficePeriod"/> using the specified <see cref="OutOfOfficePeriodQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which out of office periods to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="OutOfOfficePeriod"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<OutOfOfficePeriod>> GetAsync(OutOfOfficePeriodQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<OutOfOfficePeriod>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="OutOfOfficePeriod"/> items as an asynchronous stream using the specified <see cref="OutOfOfficePeriodQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which out of office periods to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="OutOfOfficePeriod"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<OutOfOfficePeriod> StreamAsync(OutOfOfficePeriodQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<OutOfOfficePeriod>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="OutOfOfficePeriod"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the out of office period.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="OutOfOfficePeriod"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<OutOfOfficePeriod?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<OutOfOfficePeriod>(new OutOfOfficePeriodQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="OutOfOfficePeriod"/>.
        /// </summary>
        /// <param name="outOfOfficePeriod">The out of office period to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="OutOfOfficePeriod"/>.</returns>
        public async Task<OutOfOfficePeriod> CreateAsync(OutOfOfficePeriod outOfOfficePeriod, CancellationToken ct = default)
        {
            return await PostItemAsync(outOfOfficePeriod, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an <see cref="OutOfOfficePeriod"/>.
        /// </summary>
        /// <param name="outOfOfficePeriod">The out of office period to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="OutOfOfficePeriod"/>.</returns>
        public async Task<OutOfOfficePeriod> UpdateAsync(OutOfOfficePeriod outOfOfficePeriod, CancellationToken ct = default)
        {
            return await PatchItemAsync(outOfOfficePeriod, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an <see cref="OutOfOfficePeriod"/>.
        /// </summary>
            /// <param name="outOfOfficePeriodId">The identifier of the out of office period to delete.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns><see langword="true"/> if the operation succeeds; otherwise, <see langword="false"/>.</returns>
            public async Task<bool> DeleteAsync(long outOfOfficePeriodId, CancellationToken ct = default)
            {
                return await DeleteItemAsync(outOfOfficePeriodId, ct).ConfigureAwait(false);
            }

        /// <summary>
        /// Delete an <see cref="OutOfOfficePeriod"/>.
        /// </summary>
        /// <param name="outOfOfficePeriod">The out of office period to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="OutOfOfficePeriod"/>.</returns>
        public async Task<bool> DeleteAsync(OutOfOfficePeriod outOfOfficePeriod, CancellationToken ct = default)
        {
            if (outOfOfficePeriod is null)
                throw new ArgumentNullException(nameof(outOfOfficePeriod));

            return await DeleteAsync(outOfOfficePeriod.Id, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="OutOfOfficePeriod"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly OutOfOfficePeriodClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(OutOfOfficePeriodClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified out of office period using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="outOfOfficePeriodId">The unique identifier of the out of office period for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long outOfOfficePeriodId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(outOfOfficePeriodId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified out of office period using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="outOfOfficePeriod">The out of office period for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(OutOfOfficePeriod outOfOfficePeriod, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (outOfOfficePeriod is null)
                    throw new ArgumentNullException(nameof(outOfOfficePeriod));

                return await GetAsync(outOfOfficePeriod.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified out of office period using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="outOfOfficePeriodId">The unique identifier of the out of office period for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long outOfOfficePeriodId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(outOfOfficePeriodId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified out of office period using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="outOfOfficePeriod">The out of office period for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(OutOfOfficePeriod outOfOfficePeriod, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (outOfOfficePeriod is null)
                    throw new ArgumentNullException(nameof(outOfOfficePeriod));

                return StreamAsync(outOfOfficePeriod.Id, query, ct);
            }
        }
    }
}
