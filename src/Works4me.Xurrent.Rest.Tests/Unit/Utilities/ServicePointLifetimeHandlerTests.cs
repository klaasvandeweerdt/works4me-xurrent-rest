#if !NET5_0_OR_GREATER

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Utilities;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Utilities
{
    public class ServicePointLifetimeHandlerTests
    {
        [Fact]
        public void Constructor_Throws_WhenConnectionLifetimeIsZero()
        {
            HttpMessageHandler innerHandler = new HttpClientHandler();

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new ServicePointLifetimeHandler(TimeSpan.Zero, innerHandler));

            Assert.Equal("connectionLifetime", exception.ParamName);
        }

        [Fact]
        public void Constructor_Throws_WhenInnerHandlerIsNull()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<ArgumentNullException>(() =>
                new ServicePointLifetimeHandler(TimeSpan.FromSeconds(5), null));
#pragma warning restore CS8625
        }

        [Fact]
        public async Task SendAsync_ForwardsRequestToInnerHandler()
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            HttpRequestMessage capturedRequest = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            MockHandler mockHandler = new((request, token) =>
            {
                capturedRequest = request;
                return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
            });

            ServicePointLifetimeHandler handler = new(TimeSpan.FromSeconds(10), mockHandler);

            HttpClient client = new(handler);

            HttpResponseMessage response = await client.GetAsync("https://example.com", TestContext.Current.CancellationToken);

            Assert.NotNull(capturedRequest);
            Assert.Equal("https://example.com/", capturedRequest.RequestUri.ToString());
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        private class MockHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handlerFunc;

            public MockHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handlerFunc)
            {
                _handlerFunc = handlerFunc;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return _handlerFunc(request, cancellationToken);
            }
        }
    }
}
#endif
