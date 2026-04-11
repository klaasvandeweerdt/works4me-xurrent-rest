using System;
using System.IO;
using System.Net.Http;

namespace Works4me.Xurrent.Rest.Utilities
{
    /// <summary>
    /// Represents a stream for a downloaded file and ensures cleanup of the underlying HTTP response and stream resources. <br />
    /// When you dispose this stream, both the HTTP response and the wrapped stream are disposed automatically. <br />
    /// </summary>
    /// <remarks>
    /// Use this class when you need to download a file as a stream from an HTTP endpoint and want to ensure that all associated resources are released correctly.
    /// </remarks>
    internal sealed class FileDownloadStream : Stream
    {
        private readonly HttpResponseMessage _response;
        private readonly Stream _innerStream;

        /// <inheritdoc/>
        public override bool CanRead
        {
            get => _innerStream.CanRead;
        }

        /// <inheritdoc/>
        public override bool CanSeek
        {
            get => _innerStream.CanSeek;
        }

        /// <inheritdoc/>
        public override bool CanWrite
        {
            get => _innerStream.CanWrite;
        }

        /// <inheritdoc/>
        public override long Length
        {
            get => _innerStream.Length;
        }

        /// <inheritdoc/>
        public override long Position
        {
            get => _innerStream.Position;
            set => _innerStream.Position = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDownloadStream"/> class.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/> associated with the file download. This instance will be disposed when the stream is disposed.</param>
        /// <param name="innerStream">The inner <see cref="Stream"/> representing the file content.This instance will be disposed when the stream is disposed.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="response"/> or <paramref name="innerStream"/> is <c>null</c>.</exception>
        public FileDownloadStream(HttpResponseMessage response, Stream innerStream)
        {
            _response = response ?? throw new ArgumentNullException(nameof(response));
            _innerStream = innerStream ?? throw new ArgumentNullException(nameof(innerStream));
        }

        /// <inheritdoc/>
        public override void Flush()
        {
            _innerStream.Flush();
        }

        /// <inheritdoc/>
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _innerStream.Read(buffer, offset, count);
        }

        /// <inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _innerStream.Seek(offset, origin);
        }

        /// <inheritdoc/>
        public override void SetLength(long value)
        {
            _innerStream.SetLength(value);
        }

        /// <inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count)
        {
            _innerStream.Write(buffer, offset, count);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _innerStream?.Dispose();
                _response?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
