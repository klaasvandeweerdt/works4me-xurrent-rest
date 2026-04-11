using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Attributes;
using Works4me.Xurrent.Rest.Extensions;
using Works4me.Xurrent.Rest.Utilities;

namespace Works4me.Xurrent.Rest
{
    partial class XurrentHttpClient
    {
        /// <summary>
        /// Starts an import operation for the specified entity type using the provided stream and file name.
        /// </summary>
        /// <param name="accountId">The account identifier associated with this client.</param>
        /// <param name="stream">The stream containing the file data to import.</param>
        /// <param name="type">The entity type to import.</param>
        /// <param name="filename">The name of the file being imported (not the full path).</param>
        /// <param name="allowRetry">If <c>true</c>, the method will automatically retry the request once after a 429 Too Many Requests response, honoring the server's <c>Retry-After</c> header. If <c>false</c>, no further retries are attempted.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the import token as a string.</returns>
        /// <exception cref="XurrentException">Thrown when the HTTP request fails, the response status is invalid, or the response cannot be processed.</exception>
        internal async Task<string> StartImportAsync(string accountId, Stream stream, string type, string filename, bool allowRetry, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));

            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException($"'{nameof(filename)}' cannot be null or whitespace.", nameof(filename));

            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            using (MultipartFormDataContent content = new())
            {
                content.Add(new StringContent(type), "type");
                content.Add(new StreamContent(stream), "file", filename);

                AuthenticationToken token = await GetAuthenticationTokenAsync(ct).ConfigureAwait(false);

                using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Post, new Uri(EndpointUrl, "import"), accountId, token))
                {
                    requestMessage.Content = content;

                    Guid logId = Guid.NewGuid();
                    WriteDebug(logId, requestMessage,
                        JsonSerializer.Serialize(new
                        {
                            multipart_form_data = new
                            {
                                type,
                                filename
                            }
                        }));

                    await _rateLimiter.WaitForToken(token, ct).ConfigureAwait(false);

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    using (HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage, ct).ConfigureAwait(false))
                    {
                        stopwatch.Stop();
                        WriteDebug(logId, requestMessage, null, stopwatch.Elapsed, responseMessage);

                        if ((int)responseMessage.StatusCode == 429)
                        {
                            token.UpdateRetryAfter(responseMessage.Headers);
                            if (allowRetry)
                                return await StartImportAsync(accountId, stream, type, filename, false, ct).ConfigureAwait(false);
                        }

                        token.UpdateLimitsFromHeaders(responseMessage.Headers);
                        await responseMessage.ThrowIfInvalidResponse().ConfigureAwait(false);

#if NET5_0_OR_GREATER
                        using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync(ct).ConfigureAwait(false))
#else
                        using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
#endif
                        {
                            JsonDocument document = await JsonDocument.ParseAsync(responseStream, default, ct).ConfigureAwait(false);
                            if (document.RootElement.TryGetProperty("token", out JsonElement importTokenElement) && importTokenElement.GetString() is string exportToken)
                                return exportToken;
                            throw new XurrentException("The response could not be processed.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Starts an export operation for the specified account and export parameters.
        /// </summary>
        /// <param name="accountId">The account identifier associated with this client.</param>
        /// <param name="from">The optional starting date from which to export data.</param>
        /// <param name="exportFormat">The format of the export (for example, "csv").</param>
        /// <param name="lineSeparator">The optional line separator to use in the export, for CSV format.</param>
        /// <param name="types">The list of entity types to export. Must contain at least one value.</param>
        /// <param name="allowRetry">If <c>true</c>, the method will automatically retry the request once after a 429 Too Many Requests response, honoring the server's <c>Retry-After</c> header. If <c>false</c>, no further retries are attempted.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>The export token as a string.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="types"/> collection is empty.</exception>
        /// <exception cref="XurrentException">Thrown when the HTTP request fails, the response status is invalid, or the response cannot be processed.</exception>
        internal async Task<string> StartExportAsync(string accountId, DateTime? from, string exportFormat, ExportLineSeparator? lineSeparator, IEnumerable<string> types, bool allowRetry, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(exportFormat))
                throw new ArgumentException($"'{nameof(exportFormat)}' cannot be null or whitespace.", nameof(exportFormat));

            if (types is null)
                throw new ArgumentNullException(nameof(types));

            if (!types.Any())
                throw new ArgumentException("At least one type must be specified.", nameof(types));

            using (MultipartFormDataContent content = new())
            {
                string? separator = null;
                if (lineSeparator is not null && lineSeparator.Value.TryGetXurrentEnumAttribute(out XurrentEnumAttribute? attributeValue) && attributeValue?.Value is not null)
                    separator = attributeValue.Value;

                content.Add(new StringContent(string.Join(",", types)), "type");
                content.Add(new StringContent(exportFormat), "export_format");

                if (exportFormat == "csv" && separator is not null)
                    content.Add(new StringContent(separator), "line_separator");

                if (from.HasValue)
                    content.Add(new StringContent(from.Value.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture)), "from");


                AuthenticationToken token = await GetAuthenticationTokenAsync(ct).ConfigureAwait(false);

                using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Post, new Uri(EndpointUrl, "export"), accountId, token))
                {
                    requestMessage.Content = content;

                    Guid logId = Guid.NewGuid();
                    WriteDebug(logId, requestMessage,
                        JsonSerializer.Serialize(new
                        {
                            multipart_form_data = new
                            {
                                type = string.Join(",", types),
                                export_format = exportFormat,
                                line_separator = exportFormat == "csv" && separator is not null ? separator : null,
                                from
                            }
                        }));

                    await _rateLimiter.WaitForToken(token, ct).ConfigureAwait(false);

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    using (HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage, ct).ConfigureAwait(false))
                    {
                        stopwatch.Stop();
                        WriteDebug(logId, requestMessage, null, stopwatch.Elapsed, responseMessage);

                        if ((int)responseMessage.StatusCode == 429)
                        {
                            token.UpdateRetryAfter(responseMessage.Headers);
                            if (allowRetry)
                                return await StartExportAsync(accountId, from, exportFormat, lineSeparator, types, false, ct).ConfigureAwait(false);
                        }

                        token.UpdateLimitsFromHeaders(responseMessage.Headers);
                        await responseMessage.ThrowIfInvalidResponse().ConfigureAwait(false);

#if NET5_0_OR_GREATER
                        using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync(ct).ConfigureAwait(false))
#else
                        using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
#endif
                        {
                            JsonDocument document = await JsonDocument.ParseAsync(responseStream, default, ct).ConfigureAwait(false);
                            if (document.RootElement.TryGetProperty("token", out JsonElement exportTokenElement) && exportTokenElement.GetString() is string exportToken)
                                return exportToken;
                            throw new XurrentException("The response could not be processed.");
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Retrieves the status of an import or export operation using the specified token.
        /// </summary>
        /// <typeparam name="T">The expected response type. Must be either <see cref="BulkExportResponse"/> or <see cref="BulkImportResponse"/>.</typeparam>
        /// <param name="accountId">The account identifier associated with this client.</param>
        /// <param name="importExportToken">The token identifying the import or export operation.</param>
        /// <param name="allowRetry">If <c>true</c>, the method will automatically retry the request once after a 429 Too Many Requests response, honoring the server's <c>Retry-After</c> header. If <c>false</c>, no further retries are attempted.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the status response as an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if <typeparamref name="T"/> is not <see cref="BulkExportResponse"/> or <see cref="BulkImportResponse"/>.</exception>
        /// <exception cref="XurrentException">Thrown when the HTTP request fails, the response status is invalid, the content type is not supported, or the response cannot be processed.</exception>
        internal async Task<T> GetImportExportStatusAsync<T>(string accountId, string importExportToken, bool allowRetry, CancellationToken ct) where T : class
        {
            string endpoint = typeof(T) == typeof(BulkExportResponse) ? "export" :
                              typeof(T) == typeof(BulkImportResponse) ? "import" :
                              throw new ArgumentException($"Type {typeof(T).Name} is not supported. Only {nameof(BulkExportResponse)} and {nameof(BulkImportResponse)} are supported.");

            AuthenticationToken token = await GetAuthenticationTokenAsync(ct).ConfigureAwait(false);

            using (HttpRequestMessage requestMessage = CreateHttpRequest(HttpMethod.Get, new Uri(EndpointUrl, $"{endpoint}/{importExportToken}"), accountId, token))
            {
                requestMessage.Method = HttpMethod.Get;

                Guid logId = Guid.NewGuid();
                WriteDebug(logId, requestMessage, null);

                await _rateLimiter.WaitForToken(token, ct).ConfigureAwait(false);

                Stopwatch stopwatch = Stopwatch.StartNew();
                using (HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage, ct).ConfigureAwait(false))
                {
                    stopwatch.Stop();
                    WriteDebug(logId, requestMessage, null, stopwatch.Elapsed, responseMessage);

                    if ((int)responseMessage.StatusCode == 429)
                    {
                        token.UpdateRetryAfter(responseMessage.Headers);
                        if (allowRetry)
                            return await GetImportExportStatusAsync<T>(accountId, importExportToken, false, ct).ConfigureAwait(false);
                    }

                    token.UpdateLimitsFromHeaders(responseMessage.Headers);
                    await responseMessage.ThrowIfInvalidResponse().ConfigureAwait(false);

#if NET5_0_OR_GREATER
                    using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync(ct).ConfigureAwait(false))
#else
                    using (Stream responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
#endif
                    {
                        T? result = await JsonSerializer.DeserializeAsync<T>(responseStream, _jsonOptions, ct).ConfigureAwait(false);
                        if (result is not null)
                            return result;
                        throw new XurrentException("The response could not be processed.");
                    }
                }
            }
        }

        /// <summary>
        /// Downloads the exported file as a stream. The caller is responsible for disposing the returned stream.
        /// </summary>
        /// <param name="importExportClient">The http client used for import and export.</param>
        /// <param name="exportState">The export status containing the download URL.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the downloaded file as a stream.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="exportState"/> is null.</exception>
        /// <exception cref="XurrentException">Thrown when the export is in a failed or incomplete state, or the URL is missing, or the HTTP request fails.</exception>
        internal static async Task<Stream> DownloadAsync(HttpClient importExportClient, BulkExportResponse exportState, CancellationToken ct = default)
        {
            if (importExportClient is null)
                throw new ArgumentNullException(nameof(importExportClient));

            if (exportState is null)
                throw new ArgumentNullException(nameof(exportState));
            
            if (exportState.State == ImportExportStatus.Failed || exportState.State == ImportExportStatus.Error)
                throw new XurrentException("The export process failed.");

            if (exportState.State != ImportExportStatus.Done)
                throw new XurrentException("The export process is not yet completed.");

            if (exportState.Url is null)
                throw new XurrentException("The export URL cannot be null.");

            HttpResponseMessage response = await importExportClient.GetAsync(exportState.Url, HttpCompletionOption.ResponseHeadersRead, ct).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

#if NET5_0_OR_GREATER
            Stream stream = await response.Content.ReadAsStreamAsync(ct).ConfigureAwait(false);
#else
            Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif
            return new FileDownloadStream(response, stream);
        }

    }
}
