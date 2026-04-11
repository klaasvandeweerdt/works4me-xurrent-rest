using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ProductBacklogClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetProductBacklogsAsync()
        {
            ReadOnlyKeyedDataCollection<ProductBacklog> productBacklogs = await _client.ProductBacklogs.GetAsync(new ProductBacklogQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(productBacklogs);

            if (productBacklogs.Count > 0)
            {
                ProductBacklog? productBacklog = await _client.ProductBacklogs.GetAsync(productBacklogs.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(productBacklog);
            }
        }
    }
}
