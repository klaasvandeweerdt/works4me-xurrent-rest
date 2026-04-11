using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ProductClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetProductsAsync()
        {
            ReadOnlyKeyedDataCollection<Product> products = await _client.Products.GetAsync(new ProductQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(products);

            if (products.Count > 0)
            {
                Product? product = await _client.Products.GetAsync(products.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(product);
            }
        }
    }
}
