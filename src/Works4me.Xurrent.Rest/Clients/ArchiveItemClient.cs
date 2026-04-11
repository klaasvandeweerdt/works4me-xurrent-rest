using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="ArchiveItem"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/archive/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class ArchiveItemClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArchiveItemClient"/> class.
        /// </summary>
        internal ArchiveItemClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "archive/"))
        {
        }

        /// <summary>
        /// Retrieves a collection of <see cref="ArchiveItem"/> using the specified <see cref="ArchiveItemQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which archive to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="ArchiveItem"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<ArchiveItem>> GetAsync(ArchiveItemQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<ArchiveItem>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="ArchiveItem"/> items as an asynchronous stream using the specified <see cref="ArchiveItemQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which archive to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="ArchiveItem"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<ArchiveItem> StreamAsync(ArchiveItemQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<ArchiveItem>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="ArchiveItem"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the archive item.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="ArchiveItem"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<ArchiveItem?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<ArchiveItem>(new ArchiveItemQuery().WithId(id), ct).ConfigureAwait(false);
        }
    }
}
