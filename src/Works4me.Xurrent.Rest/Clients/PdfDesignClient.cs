using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Client for <see cref="PdfDesign"/> resources in the Xurrent REST API.
    /// </summary>
    /// <remarks>
    /// For details, see the <see href="https://developer.xurrent.com/v1/pdf_designs/">Xurrent developer documentation</see>.
    /// </remarks>
    public sealed class PdfDesignClient : XurrentHttpClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfDesignClient"/> class.
        /// </summary>
        internal PdfDesignClient(IXurrentClientContext context)
            : base(context, new Uri(context.BaseUrl, "pdf_designs/"))
        {
        }

        /// <summary>
        /// Retrieves a collection of <see cref="PdfDesign"/> using the specified <see cref="PdfDesignQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which pdf designs to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A collection of <see cref="PdfDesign"/> records.</returns>
        public async Task<ReadOnlyKeyedDataCollection<PdfDesign>> GetAsync(PdfDesignQuery query, CancellationToken ct = default)
        {
            return await GetListAsync<PdfDesign>(query, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Enumerates <see cref="PdfDesign"/> items as an asynchronous stream using the specified <see cref="PdfDesignQuery"/>.
        /// </summary>
        /// <param name="query">The query that defines which pdf designs to enumerate.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> that yields <see cref="PdfDesign"/> items as they are retrieved.</returns>
        public IAsyncEnumerable<PdfDesign> StreamAsync(PdfDesignQuery query, CancellationToken ct = default)
        {
            return StreamListAsync<PdfDesign>(query, ct);
        }

        /// <summary>
        /// Retrieves a single <see cref="PdfDesign"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the pdf design.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="PdfDesign"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<PdfDesign?> GetAsync(long id, CancellationToken ct = default)
        {
            return await GetItemAsync<PdfDesign>(new PdfDesignQuery().WithId(id), ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new <see cref="PdfDesign"/>.
        /// </summary>
        /// <param name="pdfDesign">The pdf design to create.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The newly created <see cref="PdfDesign"/>.</returns>
        public async Task<PdfDesign> CreateAsync(PdfDesign pdfDesign, CancellationToken ct = default)
        {
            return await PostItemAsync(pdfDesign, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a <see cref="PdfDesign"/>.
        /// </summary>
        /// <param name="pdfDesign">The pdf design to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The updated <see cref="PdfDesign"/>.</returns>
        public async Task<PdfDesign> UpdateAsync(PdfDesign pdfDesign, CancellationToken ct = default)
        {
            return await PatchItemAsync(pdfDesign, ct).ConfigureAwait(false);
        }
    }
}
