using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Works4me.Xurrent.Rest
{
    partial class XurrentClient
    {
        /// <summary>
        /// Uploads a file at the specified file system path to the Xurrent AWS S3 storage.
        /// </summary>
        /// <param name="path">The full file-system path of the file to upload.</param>
        /// <param name="contentType">The MIME content type of the file.</param>
        /// <param name="ct">The <see cref="CancellationToken"/> for request cancellation.</param>
        /// <returns>A <see cref="Task{AttachmentUploadResponse}"/> representing the asynchronous operation, containing the storage key and the size (in bytes) of the uploaded file.</returns>
        public async Task<AttachmentUploadResponse> UploadAttachmentAsync(string path, string contentType, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException($"'{nameof(path)}' cannot be null or whitespace.", nameof(path));

            return await UploadAttachmentAsync(new FileInfo(path), contentType, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads a file at the specified file system path to the Xurrent AWS S3 storage.
        /// </summary>
        /// <param name="path">The full file-system path of the file to upload.</param>
        /// <param name="contentType">The MIME content type of the file.</param>
        /// <param name="attachmentAvailabilityDelay">Time to wait after upload to allow the attachment to become available for referencing.</param>
        /// <param name="ct">The <see cref="CancellationToken"/> for request cancellation.</param>
        /// <returns>A <see cref="Task{AttachmentUploadResponse}"/> representing the asynchronous operation, containing the storage key and the size (in bytes) of the uploaded file.</returns>
        public async Task<AttachmentUploadResponse> UploadAttachmentAsync(string path, string contentType, TimeSpan attachmentAvailabilityDelay, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException($"'{nameof(path)}' cannot be null or whitespace.", nameof(path));

            return await UploadAttachmentAsync(new FileInfo(path), contentType, attachmentAvailabilityDelay, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads a local file to the Xurrent AWS S3 storage. 
        /// </summary>
        /// <param name="file">A <see cref="FileInfo"/> representing the file to upload.</param>
        /// <param name="contentType">The MIME content type of the file.</param>
        /// <param name="ct">The <see cref="CancellationToken"/> for request cancellation.</param>
        /// <returns>A <see cref="Task{AttachmentUploadResponse}"/> representing the asynchronous operation, containing the storage key and the size (in bytes) of the uploaded file.</returns>
        public async Task<AttachmentUploadResponse> UploadAttachmentAsync(FileInfo file, string contentType, CancellationToken ct = default)
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));

            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);

            using (FileStream stream = file.OpenRead())
                return await UploadAttachmentAsync(stream, file.Name, contentType, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads a local file to the Xurrent AWS S3 storage. 
        /// </summary>
        /// <param name="file">A <see cref="FileInfo"/> representing the file to upload.</param>
        /// <param name="contentType">The MIME content type of the file.</param>
        /// <param name="attachmentAvailabilityDelay">Time to wait after upload to allow the attachment to become available for referencing.</param>
        /// <param name="ct">The <see cref="CancellationToken"/> for request cancellation.</param>
        /// <returns>A <see cref="Task{AttachmentUploadResponse}"/> representing the asynchronous operation, containing the storage key and the size (in bytes) of the uploaded file.</returns>
        public async Task<AttachmentUploadResponse> UploadAttachmentAsync(FileInfo file, string contentType, TimeSpan attachmentAvailabilityDelay, CancellationToken ct = default)
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));

            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);

            using (FileStream stream = file.OpenRead())
                return await UploadAttachmentAsync(stream, file.Name, contentType, attachmentAvailabilityDelay, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads a file stream as an attachment to Xurrent AWS S3 storage. 
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> containing the file data to upload. Must not be <c>null</c> and must support seeking in order to determine the HTTP Content-Length header.</param>
        /// <param name="fileName">The name of the file, including its extension.</param>
        /// <param name="contentType">The MIME content type of the file.</param>
        /// <param name="ct">The <see cref="CancellationToken"/> for request cancellation.</param>
        /// <returns>A <see cref="Task{AttachmentUploadResponse}"/> representing the asynchronous operation, containing the storage key and the size (in bytes) of the uploaded file.</returns>
        public async Task<AttachmentUploadResponse> UploadAttachmentAsync(Stream stream, string fileName, string contentType, CancellationToken ct = default)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            if (!stream.CanSeek)
                throw new XurrentException("The stream needs to support seeking in order to determine the HTTP Content-Length header.");

            return await UploadAttachmentAsync(stream, fileName, contentType, TimeSpan.FromMilliseconds(1000), ct).ConfigureAwait(true);
        }

        /// <summary>
        /// Uploads a file stream as an attachment to Xurrent AWS S3 storage. 
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> containing the file data to upload. Must not be <c>null</c> and must support seeking in order to determine the HTTP Content-Length header.</param>
        /// <param name="fileName">The name of the file, including its extension.</param>
        /// <param name="contentType">The MIME content type of the file.</param>
        /// <param name="attachmentAvailabilityDelay">Time to wait after upload to allow the attachment to become available for referencing.</param>
        /// <param name="ct">The <see cref="CancellationToken"/> for request cancellation.</param>
        /// <returns>A <see cref="Task{AttachmentUploadResponse}"/> representing the asynchronous operation, containing the storage key and the size (in bytes) of the uploaded file.</returns>
        public async Task<AttachmentUploadResponse> UploadAttachmentAsync(Stream stream, string fileName, string contentType, TimeSpan attachmentAvailabilityDelay, CancellationToken ct = default)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            if (!stream.CanSeek)
                throw new XurrentException("The stream needs to support seeking in order to determine the HTTP Content-Length header.");

            AttachmentStorage? attachmentStorage = await AttachmentStorage.CreateAsync(ct).ConfigureAwait(false);
            
            return await AttachmentStorage.UploadAttachmentAsync(stream, fileName, contentType, attachmentStorage, attachmentAvailabilityDelay, ct).ConfigureAwait(true);
        }
    }
}
