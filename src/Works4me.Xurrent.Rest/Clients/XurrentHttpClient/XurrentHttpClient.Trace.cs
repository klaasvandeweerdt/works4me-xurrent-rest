using System;
using System.Net.Http;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Works4me.Xurrent.Rest.Utilities;
using Microsoft.Extensions.Logging;
using Works4me.Xurrent.Rest.Extensions;

namespace Works4me.Xurrent.Rest
{
    partial class XurrentHttpClient
    {
        private readonly ILogger<XurrentClient>? _logger;
        private static readonly Action<ILogger, Guid, XurrentTraceMessage, Exception?> _logInfo = LoggerMessage.Define<Guid, XurrentTraceMessage>(LogLevel.Information, default, "{TraceId}: {@Trace}");
        private static readonly Action<ILogger, Guid, XurrentTraceMessage, Exception?> _logError = LoggerMessage.Define<Guid, XurrentTraceMessage>(LogLevel.Error, default, "{TraceId}: {@Trace}");

        /// <summary>
        /// Writes a trace message containing details of the HTTP request or response for diagnostic purposes.
        /// </summary>
        /// <param name="logIdentifier">The unique identifier for the log entry.</param>
        /// <param name="requestMessage">The <see cref="HttpRequestMessage"/> to log.</param>
        /// <param name="content">The optional HTTP content to include in the trace.</param>
        /// <param name="responseTime">The optional duration representing the response time, in milliseconds.</param>
        /// <param name="responseMessage">The optional <see cref="HttpResponseMessage"/> to log.</param>
        private void WriteDebug(Guid logIdentifier, HttpRequestMessage requestMessage, string? content = null, TimeSpan? responseTime = null, HttpResponseMessage? responseMessage = null)
        {
            if (_logger is null)
                return;

            bool isResponse = responseTime is not null;
            XurrentTraceMessage message = new()
            {
                Id = logIdentifier,
                AccountId = isResponse ? null : (requestMessage.Headers.TryGetValues(Constants.AccountHeader, out IEnumerable<string>? headerValues) ? headerValues.FirstOrDefault() : null),
                Method = isResponse ? null : requestMessage.Method.ToString(),
                Uri = isResponse ? null : requestMessage.RequestUri,
                Content = isResponse ? null : content,
                ResponseCode = isResponse ? responseMessage?.StatusCode : null,
                RetryAfterInMilliseconds = isResponse && responseMessage is not null && (int)responseMessage.StatusCode == 429 ? responseMessage.Headers.GetInt("retry-after") is int retryAfter ? retryAfter * 1000 : null : null,
                ResponseTimeInMilliseconds = isResponse ? (int?)responseTime?.TotalMilliseconds : null
            };

            try
            {
                if (responseMessage is not null)
                {
                    int statusCode = (int)responseMessage.StatusCode;
                    if (statusCode >= 200 && statusCode < 300)
                        _logInfo(_logger, logIdentifier, message, null);
                    else
                        _logError(_logger, logIdentifier, message, null);
                }
                else
                {
                    _logInfo(_logger, logIdentifier, message, null);
                }
            }
            catch (Exception ex) when (ex is JsonException or IOException or UnauthorizedAccessException)
            {
                _logError(_logger, logIdentifier, message, ex);
            }
        }
    }
}
