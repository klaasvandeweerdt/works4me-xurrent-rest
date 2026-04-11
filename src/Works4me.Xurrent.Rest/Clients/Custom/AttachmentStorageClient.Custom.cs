using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class AttachmentStorageClient
    {
        /// <summary>
        /// Retrieves a single <see cref="AttachmentStorage"/> using the specified query.
        /// </summary>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>The requested <see cref="AttachmentStorage"/>, or <see langword="null"/> if no matching record is found.</returns>
        public async Task<AttachmentStorage?> CreateAsync(CancellationToken ct = default)
        {
            return await GetItemAsync<AttachmentStorage>(new AttachmentStorageQuery(), ct).ConfigureAwait(false);
        }
    }
}
