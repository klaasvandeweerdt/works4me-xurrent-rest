using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class AppOfferingClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetAppOfferingsAsync()
        {
            ReadOnlyKeyedDataCollection<AppOffering> appOfferings = await _client.AppOfferings.GetAsync(new AppOfferingQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(appOfferings);

            if (appOfferings.Count > 0)
            {
                AppOffering? appOffering = await _client.AppOfferings.GetAsync(appOfferings.GetRandomItem().Id, TestContext.Current.CancellationToken);
                Assert.NotNull(appOffering);
            }
        }
    }
}
