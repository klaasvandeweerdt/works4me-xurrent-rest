using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Interfaces;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides client functionality for bulk operations.
    /// </summary>
    public sealed class XurrentBulkClient : XurrentHttpClient
    {
        private readonly HttpClient _httpBulkClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentBulkClient"/> class.
        /// </summary>
        internal XurrentBulkClient(IXurrentClientContext context)
            : base(context, context.BaseUrl)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            _httpBulkClient = context.BulkHttpClient ?? throw new ArgumentException($"{nameof(context.BulkHttpClient)} must not be null.", nameof(context));
        }

        /// <summary>
        /// Starts a CSV export operation for the specified types using the given line separator.
        /// <para>Note: More details and the supported types can be found on the <see href="https://developer.xurrent.com/v1/export/#parameters">Xurrent developer pages</see>.</para>
        /// </summary>
        /// <param name="types">The collection of entity types to export.</param>
        /// <param name="lineSeparator">The line separator to use in the exported CSV.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the export token as a string.</returns>
        public async Task<string> StartCsvExportAsync(IEnumerable<string> types, ExportLineSeparator lineSeparator, CancellationToken ct = default)
        {
            return await StartExportAsync(AccountId, null, "csv", lineSeparator, types, true, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a CSV export operation for the specified types and date range using the given line separator.
        /// <para>Note: More details and the supported types can be found on the <see href="https://developer.xurrent.com/v1/export/#parameters">Xurrent developer pages</see>.</para>
        /// </summary>
        /// <param name="types">The collection of entity types to export.</param>
        /// <param name="lineSeparator">The line separator to use in the exported CSV.</param>
        /// <param name="from">The start date from which to export data.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the export token as a string.</returns>
        public async Task<string> StartCsvExportAsync(IEnumerable<string> types, ExportLineSeparator lineSeparator, DateTime from, CancellationToken ct = default)
        {
            return await StartExportAsync(AccountId, from, "csv", lineSeparator, types, true, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts an Excel (XLSX) export operation for the specified types.
        /// <para>Note: More details and the supported types can be found on the <see href="https://developer.xurrent.com/v1/export/#parameters">Xurrent developer pages</see>.</para>
        /// </summary>
        /// <param name="types">The collection of entity types to export.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the export token as a string.</returns>
        public async Task<string> StartExcelExportAsync(IEnumerable<string> types, CancellationToken ct = default)
        {
            return await StartExportAsync(AccountId, null, "xlsx", null, types, true, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts an Excel (XLSX) export operation for the specified types and date range.
        /// <para>Note: More details and the supported types can be found on the <see href="https://developer.xurrent.com/v1/export/#parameters">Xurrent developer pages</see>.</para>
        /// </summary>
        /// <param name="types">The collection of entity types to export.</param>
        /// <param name="from">The start date from which to export data.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the export token as a string.</returns>
        public async Task<string> StartExcelExportAsync(IEnumerable<string> types, DateTime from, CancellationToken ct = default)
        {
            return await StartExportAsync(AccountId, from, "xlsx", null, types, true, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the status of a bulk export operation using the specified export token.
        /// </summary>
        /// <param name="exportToken">The token identifying the export operation.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the export status as a <see cref="BulkExportResponse"/>.</returns>
        public async Task<BulkExportResponse> GetExportStatusAsync(string exportToken, CancellationToken ct = default)
        {
            return await GetImportExportStatusAsync<BulkExportResponse>(AccountId, exportToken, true, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Polls the status of a bulk export operation until it completes or fails.
        /// </summary>
        /// <remarks>
        /// Be mindful of the API rate limit when setting the polling interval. <br />
        /// The <paramref name="pollingInterval"/> should be selected based on the expected number of objects to be exported, as frequent polling can potentially exceed the API rate limit.
        /// </remarks>
        /// <param name="exportToken">The token identifying the export operation.</param>
        /// <param name="pollingInterval">The interval between each poll. Must be between 2 seconds and 15 minutes (900 seconds).</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the completed <see cref="BulkExportResponse"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pollingInterval"/> is less than 2 seconds or greater than 15 minutes.</exception>
        public async Task<BulkExportResponse> AwaitExportAsync(string exportToken, TimeSpan pollingInterval, CancellationToken ct = default)
        {
            string accountId = AccountId;

            if (pollingInterval.TotalSeconds < 2 || pollingInterval.TotalMinutes > 15)
                throw new ArgumentOutOfRangeException(nameof(pollingInterval), "Polling interval must be between 2 seconds and 900 seconds.");

            BulkExportResponse response = await GetImportExportStatusAsync<BulkExportResponse>(accountId, exportToken, true, ct).ConfigureAwait(false);
            while (response.State != ImportExportStatus.Done)
            {
                ct.ThrowIfCancellationRequested();

                if (response.State == ImportExportStatus.Failed || response.State == ImportExportStatus.Error)
                    throw new XurrentException("The export process failed.");

                await Task.Delay(pollingInterval, ct).ConfigureAwait(false);
                response = await GetImportExportStatusAsync<BulkExportResponse>(accountId, exportToken, true, ct).ConfigureAwait(false);
            }
            return response;
        }

        /// <summary>
        /// Downloads the exported file as a stream. The caller is responsible for disposing the returned stream.
        /// </summary>
        /// <param name="exportState">The export status containing the download URL.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the downloaded file as a stream.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="exportState"/> is null.</exception>
        /// <exception cref="XurrentException">Thrown when the export is in a failed or incomplete state, or the URL is missing, or the HTTP request fails.</exception>
        internal async Task<Stream> DownloadAsync(BulkExportResponse exportState, CancellationToken ct = default)
        {
            return await DownloadAsync(_httpBulkClient, exportState, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Waits for the completion of an export operation and downloads the exported file as a stream. The caller is responsible for disposing the returned stream.
        /// </summary>
        /// <remarks>
        /// Be mindful of the API rate limit when setting the polling interval. <br />
        /// The <paramref name="pollingInterval"/> should be selected based on the expected number of objects to be exported, as frequent polling can potentially exceed the API rate limit.
        /// </remarks>
        /// <param name="exportToken">The token identifying the export operation.</param>
        /// <param name="pollingInterval">The interval between each poll. Must be between 2 seconds and 15 minutes (900 seconds).</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the downloaded file as a stream.</returns>
        public async Task<Stream> AwaitDownloadAsync(string exportToken, TimeSpan pollingInterval, CancellationToken ct = default)
        {
            BulkExportResponse exportState = await AwaitExportAsync(exportToken, pollingInterval, ct).ConfigureAwait(false);
            return await DownloadAsync(_httpBulkClient, exportState, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Waits for the completion of an export operation, downloads the exported file, and saves it to the specified file path.
        /// </summary>
        /// <remarks>
        /// Be mindful of the API rate limit when setting the polling interval. <br />
        /// The <paramref name="pollingInterval"/> should be selected based on the expected number of objects to be exported, as frequent polling can potentially exceed the API rate limit.
        /// </remarks>
        /// <param name="filePath">The full path where the downloaded file will be saved.</param>
        /// <param name="exportToken">The token identifying the export operation.</param>
        /// <param name="pollingInterval">The interval between each poll. Must be between 2 seconds and 15 minutes (900 seconds).</param>
        /// <param name="ct">The cancellation token to observe.</param>
        public async Task AwaitDownloadAndSaveAsync(string filePath, string exportToken, TimeSpan pollingInterval, CancellationToken ct = default)
        {
            using (Stream inputStream = await AwaitDownloadAsync(exportToken, pollingInterval, ct).ConfigureAwait(false))
            {
                using (FileStream outputStream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await inputStream.CopyToAsync(outputStream, 81920, ct).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Starts an import operation for the specified entity type using a file at the given path.
        /// <para>Note: More details and the supported types can be found on the <see href="https://developer.xurrent.com/v1/export/#parameters">Xurrent developer pages</see>.</para>
        /// </summary>
        /// <param name="filePath">The full path to the file to import.</param>
        /// <param name="type">The entity type to import.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the import token as a string.</returns>
        public async Task<string> StartImportAsync(string filePath, string type, CancellationToken ct = default)
        {
            using (FileStream stream = new(filePath, FileMode.Open, FileAccess.Read))
                return await StartImportAsync(AccountId, stream, type, Path.GetFileName(filePath), true, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts an import operation for the specified entity type using the provided stream and file name.
        /// <para>Note: More details and the supported types can be found on the <see href="https://developer.xurrent.com/v1/export/#parameters">Xurrent developer pages</see>.</para>
        /// </summary>
        /// <param name="stream">The stream containing the file data to import.</param>
        /// <param name="type">The entity type to import.</param>
        /// <param name="filename">The name of the file being imported (not the full path).</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the import token as a string.</returns>
        /// <exception cref="XurrentException">Thrown when the HTTP request fails, the response status is invalid, or the response cannot be processed.</exception>
        public async Task<string> StartImportAsync(Stream stream, string type, string filename, CancellationToken ct = default)
        {
            return await StartImportAsync(AccountId, stream, type, filename, true, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the status of a bulk import operation using the specified export token.
        /// </summary>
        /// <param name="importToken">The token identifying the import operation.</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the export status as a <see cref="BulkExportResponse"/>.</returns>
        public async Task<BulkImportResponse> GetImportStatusAsync(string importToken, CancellationToken ct = default)
        {
            return await GetImportExportStatusAsync<BulkImportResponse>(AccountId, importToken, true, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Polls the status of a bulk import operation until it completes, fails, or enters an error state.
        /// </summary>
        /// <remarks>
        /// Be mindful of the API rate limit when setting the polling interval. <br />
        /// The <paramref name="pollingInterval"/> should be selected based on the expected number of objects to be imported, as frequent polling can potentially exceed the API rate limit.
        /// </remarks>
        /// <param name="importToken">The token identifying the import operation.</param>
        /// <param name="pollingInterval">The interval between each poll. Must be between 2 seconds and 15 minutes (900 seconds).</param>
        /// <param name="ct">The cancellation token to observe.</param>
        /// <returns>A task representing the asynchronous operation, with the final <see cref="BulkImportResponse"/> result.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pollingInterval"/> is less than 2 seconds or greater than 15 minutes.</exception>
        public async Task<BulkImportResponse> AwaitImportAsync(string importToken, TimeSpan pollingInterval, CancellationToken ct = default)
        {
            string accountId = AccountId;

            if (pollingInterval.TotalSeconds < 2 || pollingInterval.TotalMinutes > 15)
                throw new ArgumentOutOfRangeException(nameof(pollingInterval), "Polling interval must be between 2 seconds and 900 seconds.");

            BulkImportResponse response = await GetImportExportStatusAsync<BulkImportResponse>(accountId, importToken, true, ct).ConfigureAwait(false);
            while (response.State != ImportExportStatus.Done && response.State != ImportExportStatus.Failed && response.State != ImportExportStatus.Error)
            {
                ct.ThrowIfCancellationRequested();

                await Task.Delay(pollingInterval, ct).ConfigureAwait(false);
                response = await GetImportExportStatusAsync<BulkImportResponse>(accountId, importToken, true, ct).ConfigureAwait(false);
            }
            return response;
        }
    }
}
