using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="AffectedSla"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/affected_slas/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class AffectedSlaClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AffectedSlaClient"/> class.
        /// </summary>
        internal AffectedSlaClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "affected_slas/"))
        {
        }

        /// <summary>
        /// Retrieves a collection of <see cref="AffectedSla"/> using the specified <see cref="AffectedSlaQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which affected service level agreements to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="AffectedSla"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<AffectedSla>> GetAsync(AffectedSlaQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<AffectedSla>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="AffectedSla"/> items as an asynchronous stream using the specified <see cref="AffectedSlaQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which affected service level agreements to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="AffectedSla"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<AffectedSla> StreamAsync(AffectedSlaQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<AffectedSla>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="AffectedSla"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the affected service level agreement.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="AffectedSla"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<AffectedSla?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<AffectedSla>(new AffectedSlaQuery().WithId(id), ct).ConfigureAwait(false);
        }
    }
}
