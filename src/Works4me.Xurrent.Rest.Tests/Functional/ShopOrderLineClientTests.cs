using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ShopOrderLineClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetShopOrderLinesAsync()
        {
            ReadOnlyKeyedDataCollection<ShopOrderLine> shopOrderLines = await _client.ShopOrderLines.GetAsync(new ShopOrderLineQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(shopOrderLines);

            if (shopOrderLines.Count > 0)
            {
                ShopOrderLine? shopOrderLine = await _client.ShopOrderLines.GetAsync(shopOrderLines.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(shopOrderLine);
            }
        }
    }
}
