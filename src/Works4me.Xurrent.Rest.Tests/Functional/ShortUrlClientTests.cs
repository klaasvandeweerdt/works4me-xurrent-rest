using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ShortUrlClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetShortUrlsAsync()
        {
            ReadOnlyKeyedDataCollection<ShortUrl> shortUrls = await _client.ShortUrls.GetAsync(new ShortUrlQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(shortUrls);

            if (shortUrls.Count > 0)
            {
                ShortUrl? shortUrl = await _client.ShortUrls.GetAsync(shortUrls.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(shortUrl);
            }
        }
    }
}
