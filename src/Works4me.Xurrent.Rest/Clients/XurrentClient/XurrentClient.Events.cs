using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class XurrentClient
    {
        /// <summary>
        /// Creates a new event for a request using the Xurrent Events REST API.
        /// </summary>
        /// <param name="requestEventCreateInput">The event payload to send. Build this using <see cref="RequestEventCreateInput"/>; only fields with non-null and meaningful values are serialized into the request body.</param>
        /// <param name="ct">The <see cref="CancellationToken"/> for request cancellation.</param>
        /// <returns>A <see cref="Task{Request}"/> that represents the asynchronous operation. The returned <see cref="Request"/> reflects the request as returned by the API after the event was created.</returns>
        public async Task<Request> CreateEventAsync(RequestEventCreateInput requestEventCreateInput, CancellationToken ct = default)
        {
            return await GetInternalClient<XurrentEventsClient>().CreateAsync(requestEventCreateInput, ct).ConfigureAwait(false);
        }
    }
}
