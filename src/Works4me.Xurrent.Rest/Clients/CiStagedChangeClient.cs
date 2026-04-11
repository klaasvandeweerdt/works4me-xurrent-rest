using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="CiStagedChange"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/ci_staged_changes/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class CiStagedChangeClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CiStagedChangeClient"/> class.
        /// </summary>
        internal CiStagedChangeClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "ci_staged_changes/"))
        {
        }

        /// <summary>
        /// Retrieves a collection of <see cref="CiStagedChange"/> using the specified <see cref="CiStagedChangeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which configuration item staged changes to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="CiStagedChange"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<CiStagedChange>> GetAsync(CiStagedChangeQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<CiStagedChange>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="CiStagedChange"/> items as an asynchronous stream using the specified <see cref="CiStagedChangeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which configuration item staged changes to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="CiStagedChange"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<CiStagedChange> StreamAsync(CiStagedChangeQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<CiStagedChange>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="CiStagedChange"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the configuration item staged change.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="CiStagedChange"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<CiStagedChange?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<CiStagedChange>(new CiStagedChangeQuery().WithId(id), ct).ConfigureAwait(false);
        }
    }
}
