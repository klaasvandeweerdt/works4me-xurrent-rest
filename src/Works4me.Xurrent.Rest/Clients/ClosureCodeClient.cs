using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ClosureCode"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/closure_codes/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ClosureCodeClient : XurrentHttpClient
    {
        /// <summary>
        /// Gets the client for operations on <see cref="AuditEntry"/> records related to an <see cref="ClosureCode"/>.
        /// </summary>
        public AuditEntriesClient AuditEntries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClosureCodeClient"/> class.
        /// </summary>
        internal ClosureCodeClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "closure_codes/"))
        {
            AuditEntries = new AuditEntriesClient(this);
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ClosureCode"/> using the specified <see cref="ClosureCodeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which closure codes to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ClosureCode"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ClosureCode>> GetAsync(ClosureCodeQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ClosureCode>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ClosureCode"/> items as an asynchronous stream using the specified <see cref="ClosureCodeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which closure codes to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ClosureCode"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ClosureCode> StreamAsync(ClosureCodeQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ClosureCode>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ClosureCode"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the closure code.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ClosureCode"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ClosureCode?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ClosureCode>(new ClosureCodeQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="ClosureCode"/>.
        /// </summary>
        /// <param name="closureCode">The closure code to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="ClosureCode"/>.</returns>
        public async Task<ClosureCode> CreateAsync(ClosureCode closureCode, CancellationToken ct = default)
        {
            return await PostItemAsync(closureCode, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="ClosureCode"/>.
        /// </summary>
        /// <param name="closureCode">The closure code to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="ClosureCode"/>.</returns>
        public async Task<ClosureCode> UpdateAsync(ClosureCode closureCode, CancellationToken ct = default)
        {
            return await PatchItemAsync(closureCode, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Provides client functionality for operations on <see cref="AuditEntry"/> records related to an <see cref="ClosureCode"/>.
        /// </summary>
        public sealed class AuditEntriesClient
        {
            private readonly ClosureCodeClient _client;

            /// <summary>
            /// Initializes a new instance of the <see cref="AuditEntriesClient"/> class.
            /// </summary>
            internal AuditEntriesClient(ClosureCodeClient client)
            {
                _client = client;
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified closure code using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="closureCodeId">The unique identifier of the closure code for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(long closureCodeId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return await _client.GetListAsync<AuditEntry>(closureCodeId, "audit", query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns a collection of <see cref="AuditEntry"/> records for the specified closure code using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="closureCode">The closure code for which to retrieve the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>A collection of <see cref="AuditEntry"/> records.</returns>
            public async Task<ReadOnlyKeyedDataCollection<AuditEntry>> GetAsync(ClosureCode closureCode, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (closureCode is null)
                    throw new ArgumentNullException(nameof(closureCode));

                return await GetAsync(closureCode.Id, query, ct).ConfigureAwait(false);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified closure code using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="closureCodeId">The unique identifier of the closure code for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(long closureCodeId, AuditEntryQuery query, CancellationToken ct = default)
            {
                return _client.StreamListAsync<AuditEntry>(closureCodeId, "audit", query, ct);
            }

            /// <summary>
            /// Enumerates <see cref="AuditEntry"/> items as an asynchronous stream for the specified closure code using an <see cref="AuditEntryQuery"/>.
            /// </summary>
            /// <param name="closureCode">The closure code for which to enumerate the audit entries.</param>
            /// <param name="query">The query that defines which audit entries to retrieve.</param>
            /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
            /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditEntry"/> items as they are retrieved.</returns>
            public IAsyncEnumerable<AuditEntry> StreamAsync(ClosureCode closureCode, AuditEntryQuery query, CancellationToken ct = default)
            {
                if (closureCode is null)
                    throw new ArgumentNullException(nameof(closureCode));

                return StreamAsync(closureCode.Id, query, ct);
            }
        }
    }
}
