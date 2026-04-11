using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="HttpResponseMessage"/> to validate HTTP response status and content type.
    /// </summary>
    internal static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Throws a <see cref="XurrentException"/> if the HTTP response status is not successful.
        /// Throws a <see cref="XurrentException"/> if the response content type is not JSON (<c>application/json</c>).
        /// </summary>
        /// <param name="responseMessage">The HTTP response message to validate.</param>
        /// <exception cref="XurrentException">
        /// Thrown when the API returns a non-success HTTP status code. <br />
        /// The exception contains the HTTP status code,the raw response body, and the parsed JSON response body when available.
        /// </exception>
        /// <exception cref="XurrentException">Thrown when the response content type is not JSON (<c>application/json</c>).</exception>
        public async static Task ThrowIfInvalidResponse(this HttpResponseMessage responseMessage)
        {
            if (responseMessage is null)
                throw new ArgumentNullException(nameof(responseMessage));

            if (!responseMessage.IsSuccessStatusCode)
            {
                string? rawBody = null;

                if (responseMessage.Content is not null)
                    rawBody = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                JsonElement? jsonBody = default;
                if (rawBody.TryParseJsonElement(out JsonElement parsedJsonBody))
                    jsonBody = parsedJsonBody;

                throw new XurrentException(responseMessage.StatusCode, rawBody, jsonBody);
            }
        }
    }
}
