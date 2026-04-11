using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="AuditLine"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/audit_entries/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class AuditLineClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLineClient"/> class.
        /// </summary>
        internal AuditLineClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "audit_lines/"))
        {
        }

        /// <summary>
        /// Retrieves a collection of <see cref="AuditLine"/> using the specified <see cref="AuditLineQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which audit lines to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="AuditLine"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<AuditLine>> GetAsync(AuditLineQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<AuditLine>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="AuditLine"/> items as an asynchronous stream using the specified <see cref="AuditLineQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which audit lines to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AuditLine"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<AuditLine> StreamAsync(AuditLineQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<AuditLine>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="AuditLine"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the audit line.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="AuditLine"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<AuditLine?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<AuditLine>(new AuditLineQuery().WithId(id), ct).ConfigureAwait(false);
        }
    }
}
