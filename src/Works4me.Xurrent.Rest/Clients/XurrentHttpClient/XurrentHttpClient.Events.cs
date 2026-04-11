using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class XurrentHttpClient
    {
        /// <summary>
        /// Creates a new event for a request using the Xurrent Events REST API.
        /// </summary>
        /// <param name="requestEventCreateInput">The event payload to send. Build this using <see cref="RequestEventCreateInput"/>; only fields with non-null and meaningful values are serialized into the request body.</param>
        /// <param name="ct">The <see cref="CancellationToken"/> for request cancellation.</param>
        /// <returns>A <see cref="Task{Request}"/> that represents the asynchronous operation. The returned <see cref="Request"/> reflects the request as returned by the API after the event was created.</returns>
        internal async Task<Request> CreateEventAsync(RequestEventCreateInput requestEventCreateInput, CancellationToken ct)
        {
            if (requestEventCreateInput is null)
                throw new ArgumentNullException(nameof(requestEventCreateInput));

            AuthenticationToken token = await GetAuthenticationTokenAsync(ct).ConfigureAwait(false);

            using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Post, new Uri(EndpointUrl, "events"), AccountId, token))
            {
                using (HttpResponseMessage responseMessage = await SendHttpRequestAsync(requestMessage, requestEventCreateInput.GetHttpRequestBody(), token, false, ct).ConfigureAwait(false))
                {
#if NET5_0_OR_GREATER
                    using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync(ct).ConfigureAwait(false))
#else
                    using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
#endif
                    {
                        using (JsonDocument document = await JsonDocument.ParseAsync(responseStream, default, ct).ConfigureAwait(false))
                        {
                            JsonElement root = document.RootElement;

                            if (root.ValueKind == JsonValueKind.Object && root.Deserialize<Request>(_jsonOptions) is Request result)
                            {
                                return result;
                            }
                        }
                    }
                }
            }
            throw new XurrentException("Failed to create a request event via the Xurrent Events API.");
        }
    }
}
