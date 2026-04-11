using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class SiteClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetSitesAsync()
        {
            ReadOnlyKeyedDataCollection<Site> sites = await _client.Sites.GetAsync(new SiteQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(sites);

            if (sites.Count > 0)
            {
                Site? site = await _client.Sites.GetAsync(sites.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(site);
            }
        }
    }
}
