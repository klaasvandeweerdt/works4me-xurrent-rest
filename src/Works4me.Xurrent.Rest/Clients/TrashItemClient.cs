using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="TrashItem"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/trash/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class TrashItemClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrashItemClient"/> class.
        /// </summary>
        internal TrashItemClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "trash/"))
        {
        }

        /// <summary>
        /// Retrieves a collection of <see cref="TrashItem"/> using the specified <see cref="TrashItemQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which trash to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="TrashItem"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<TrashItem>> GetAsync(TrashItemQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<TrashItem>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="TrashItem"/> items as an asynchronous stream using the specified <see cref="TrashItemQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which trash to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="TrashItem"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<TrashItem> StreamAsync(TrashItemQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<TrashItem>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="TrashItem"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the trash item.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="TrashItem"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<TrashItem?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<TrashItem>(new TrashItemQuery().WithId(id), ct).ConfigureAwait(false);
        }
    }
}
