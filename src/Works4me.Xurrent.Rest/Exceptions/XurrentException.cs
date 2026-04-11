using System;
using System.Net;
using System.Text.Json;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents a Xurrent exception, including the HTTP status code and the raw response body in case of an API exception. <br />
    /// When the response body contains valid JSON, a parsed <see cref="JsonElement"/> is also available for inspection.
    /// </summary>
    [Serializable]
    public class XurrentException : Exception
    {
        private readonly HttpStatusCode? _statusCode;
        private readonly string? _rawBody;
        private readonly JsonElement? _jsonBody;

        /// <summary>
        /// Gets the HTTP status code returned by the API.
        /// </summary>
        public HttpStatusCode? StatusCode
        {
            get => _statusCode;
        }

        /// <summary>
        /// Gets the raw response body returned by the API, if available.
        /// </summary>
        public string? RawBody
        {
            get => _rawBody;
        }

        /// <summary>
        /// Gets the parsed JSON response body returned by the API, if available.
        /// </summary>
        public JsonElement? JsonBody
        {
            get => _jsonBody;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentException"/> class.
        /// </summary>
        public XurrentException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public XurrentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentException"/> class with a specified 
        /// error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public XurrentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentException"/> class with the specified HTTP status code
        /// and error response payload.
        /// </summary>
        /// <param name="statusCode">The HTTP status code returned by the API.</param>
        /// <param name="rawBody">The raw response body returned by the API, if available.</param>
        /// <param name="jsonBody">The parsed JSON response body returned by the API, if available.</param>
        public XurrentException(HttpStatusCode statusCode, string? rawBody, JsonElement? jsonBody)
            : base($"HTTP request failed with status code {(int)statusCode} ({statusCode}).")
        {
            _statusCode = statusCode;
            _rawBody = rawBody;
            _jsonBody = jsonBody;
        }


#if NETFRAMEWORK
        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected XurrentException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            _statusCode = (HttpStatusCode)info.GetValue(nameof(StatusCode), typeof(HttpStatusCode))!;
            _rawBody = info.GetString(nameof(RawBody));
            _jsonBody = (JsonElement?)info.GetValue(nameof(JsonBody), typeof(JsonElement));
        }
#endif
    }
}
