using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Works4me.Xurrent.Rest
{
    partial class XurrentHttpClient
    {
        /// <summary>
        /// Uploads a file stream as an attachment to Xurrent AWS S3 storage. 
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> containing the file data to upload. Must not be <c>null</c> and must support seeking in order to determine the HTTP Content-Length header.</param>
        /// <param name="fileName">The name of the file, including its extension.</param>
        /// <param name="contentType">The MIME content type of the file.</param>
        /// <param name="attachmentStorage">The Xurrent attachment storage object.</param>
        /// <param name="attachmentAvailabilityDelay">Time to wait after upload to allow the attachment to become available for referencing due to eventual consistency in storage.
        /// </param>
        /// <param name="ct">The <see cref="CancellationToken"/> for request cancellation.</param>
        /// <returns>A <see cref="Task{AttachmentUploadResponse}"/> representing the asynchronous operation, containing the storage key and the size (in bytes) of the uploaded file.</returns>
        internal async Task<AttachmentUploadResponse> UploadAttachmentAsync(Stream stream, string fileName, string contentType, AttachmentStorage? attachmentStorage, TimeSpan attachmentAvailabilityDelay, CancellationToken ct = default)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            if (!stream.CanSeek)
                throw new XurrentException("The stream needs to support seeking in order to determine the HTTP Content-Length header.");

            if (attachmentStorage is null || attachmentStorage.AllowedExtensions is null)
                throw new XurrentException("No AttachmentStorage object returned by the Xurrent REST API.");

            string fileExtension = Path.GetExtension(fileName).TrimStart('.');
            if (attachmentStorage.AllowedExtensions.Count > 0 && !attachmentStorage.AllowedExtensions.Contains(fileExtension, StringComparer.InvariantCultureIgnoreCase))
                throw new XurrentException($"File extension \"{fileExtension}\" is not allowed.");

            if (stream.Length >= attachmentStorage.SizeLimit)
                throw new XurrentException($"File size exceeded, the maximum size is {attachmentStorage.SizeLimit} bytes.");

            if (attachmentStorage.UploadParameters is null)
                throw new XurrentException("File upload failed, invalid AttachmentStorage.UploadParameters value.");

            using (MultipartFormDataContent multipartContent = new())
            {
                multipartContent.Add(new StringContent(contentType), "Content-Type");
                multipartContent.Add(new StringContent(attachmentStorage.UploadParameters.Acl), "acl");
                multipartContent.Add(new StringContent(attachmentStorage.UploadParameters.Key), "key");
                multipartContent.Add(new StringContent(attachmentStorage.UploadParameters.Policy), "policy");
                multipartContent.Add(new StringContent(attachmentStorage.UploadParameters.SuccessActionStatus.ToString(CultureInfo.InvariantCulture)), "success_action_status");
                multipartContent.Add(new StringContent(attachmentStorage.UploadParameters.XAmzAlgorithm), "x-amz-algorithm");
                multipartContent.Add(new StringContent(attachmentStorage.UploadParameters.XAmzCredential), "x-amz-credential");
                multipartContent.Add(new StringContent(attachmentStorage.UploadParameters.XAmzDate), "x-amz-date");
                multipartContent.Add(new StringContent(attachmentStorage.UploadParameters.XAmzServerSideEncryption), "x-amz-server-side-encryption");
                multipartContent.Add(new StringContent(attachmentStorage.UploadParameters.XAmzSignature), "x-amz-signature");
                multipartContent.Add(new StreamContent(stream), "file", fileName);

                using (HttpRequestMessage requestMessage = new(HttpMethod.Post, attachmentStorage.UploadUri) { Content = multipartContent })
                {
                    Guid logId = Guid.NewGuid();
                    WriteDebug(logId, requestMessage, "***");

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    using (HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage, ct).ConfigureAwait(false))
                    {
                        if (attachmentAvailabilityDelay > TimeSpan.Zero)
                            await Task.Delay(attachmentAvailabilityDelay, ct).ConfigureAwait(false);

                        stopwatch.Stop();
                        WriteDebug(logId, requestMessage, null, stopwatch.Elapsed, responseMessage);

#if NET5_0_OR_GREATER
                        using (StreamReader reader = new(await responseMessage.Content.ReadAsStreamAsync(ct).ConfigureAwait(false)))
                        {
                            string data = await reader.ReadToEndAsync(ct).ConfigureAwait(false);
#else
                        using (StreamReader reader = new(await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                        {
                            string data = await reader.ReadToEndAsync().ConfigureAwait(false);
#endif
                            if (XDocument.Parse(data).Descendants("Key").FirstOrDefault() is XElement keyElement)
                            {
                                return new AttachmentUploadResponse
                                {
                                    Key = keyElement.Value,
                                    Size = stream.Length
                                };
                            }
                            throw new XurrentException($"Upload succeeded but no <Key> element found in response:{Environment.NewLine}{data}");
                        }
                    }
                }
            }
        }
    }
}
