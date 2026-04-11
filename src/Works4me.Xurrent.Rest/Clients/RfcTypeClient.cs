using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="RfcType"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/rfc_types/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class RfcTypeClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RfcTypeClient"/> class.
        /// </summary>
        internal RfcTypeClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "rfc_types/"))
        {
        }

        /// <summary>
        /// Retrieves a collection of <see cref="RfcType"/> using the specified <see cref="RfcTypeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which rfc types to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="RfcType"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<RfcType>> GetAsync(RfcTypeQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<RfcType>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="RfcType"/> items as an asynchronous stream using the specified <see cref="RfcTypeQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which rfc types to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="RfcType"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<RfcType> StreamAsync(RfcTypeQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<RfcType>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="RfcType"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the rfc type.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="RfcType"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<RfcType?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<RfcType>(new RfcTypeQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="RfcType"/>.
        /// </summary>
        /// <param name="rfcType">The rfc type to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="RfcType"/>.</returns>
        public async Task<RfcType> CreateAsync(RfcType rfcType, CancellationToken ct = default)
        {
            return await PostItemAsync(rfcType, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="RfcType"/>.
        /// </summary>
        /// <param name="rfcType">The rfc type to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="RfcType"/>.</returns>
        public async Task<RfcType> UpdateAsync(RfcType rfcType, CancellationToken ct = default)
        {
            return await PatchItemAsync(rfcType, ct).ConfigureAwait(false);
        }
    }
}
