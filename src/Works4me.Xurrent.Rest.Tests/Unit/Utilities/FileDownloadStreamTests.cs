using System;
using System.IO;
using System.Net.Http;
using Works4me.Xurrent.Rest.Utilities;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Utilities
{
    public class FileDownloadStreamTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenResponseIsNull()
        {
            Stream dummyStream = new MemoryStream();

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new FileDownloadStream(null, dummyStream));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            Assert.Equal("response", exception.ParamName);
        }

        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenStreamIsNull()
        {
            HttpResponseMessage response = new();

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new FileDownloadStream(response, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            Assert.Equal("innerStream", exception.ParamName);
        }

        [Fact]
        public void Properties_DelegateToInnerStream()
        {
            MemoryStream innerStream = new(new byte[] { 1, 2, 3 });
            HttpResponseMessage response = new();

            FileDownloadStream fileStream = new(response, innerStream);

            Assert.True(fileStream.CanRead);
            Assert.True(fileStream.CanSeek);
            Assert.True(fileStream.CanWrite);
            Assert.Equal(innerStream.Length, fileStream.Length);
        }

        [Fact]
        public void Read_DelegatesToInnerStream()
        {
            byte[] content = new byte[] { 10, 20, 30 };
            MemoryStream innerStream = new(content);
            HttpResponseMessage response = new();

            FileDownloadStream fileStream = new(response, innerStream);

            byte[] buffer = new byte[3];
            int bytesRead = fileStream.Read(buffer, 0, 3);

            Assert.Equal(3, bytesRead);
            Assert.Equal(content, buffer);
        }

        [Fact]
        public void Dispose_DisposesInnerStreamAndResponse()
        {
            TestStream innerStream = new();
            TestHttpResponseMessage response = new();

            FileDownloadStream fileStream = new(response, innerStream);

            fileStream.Dispose();

            Assert.True(innerStream.IsDisposed);
            Assert.True(response.IsDisposed);
        }

        private class TestStream : MemoryStream
        {
            public bool IsDisposed { get; private set; }

            protected override void Dispose(bool disposing)
            {
                IsDisposed = true;
                base.Dispose(disposing);
            }
        }

        private class TestHttpResponseMessage : HttpResponseMessage
        {
            public bool IsDisposed { get; private set; }

            protected override void Dispose(bool disposing)
            {
                IsDisposed = true;
                base.Dispose(disposing);
            }
        }
    }
}
