using System;
using System.Net;
using System.Text.Json.Serialization;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a trace message used to log HTTP request and response details.
    /// </summary>
    public sealed class XurrentTraceMessage
    {
        /// <summary>
        /// Gets or sets the identifier for this trace entry.
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the HTTP method of the request.
        /// </summary>
        [JsonPropertyName("method")]
        public string? Method { get; set; }

        /// <summary>
        /// Gets or sets the absolute URI of the HTTP request.
        /// </summary>
        [JsonPropertyName("uri")]
        public Uri? Uri { get; set; }

        /// <summary>
        /// Gets or sets the HTTP request content.
        /// </summary>
        [JsonPropertyName("content")]
        public string? Content { get; set; }

        /// <summary>
        /// Gets or sets the Xurrent account identifier associated with this request.
        /// </summary>
        [JsonPropertyName("account_id")]
        public string? AccountId { get; set; }

        /// <summary>
        /// Gets or sets the HTTP response code returned by the server.
        /// </summary>
        [JsonPropertyName("response_code")]
        public HttpStatusCode? ResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the <c>retry-after</c> value returned by the server, representing the number of milliseconds to wait before retrying the request after receiving a <c>429 Too Many Requests</c> response.
        /// </summary>
        [JsonPropertyName("retry_after_in_ms")]
        public int? RetryAfterInMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets the total response time for the HTTP request in milliseconds.
        /// </summary>
        [JsonPropertyName("response_time_in_ms")]
        public int? ResponseTimeInMilliseconds { get; set; }
    }
}
