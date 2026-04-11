using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ProductCategoryClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetProductCategoriesAsync()
        {
            ReadOnlyKeyedDataCollection<ProductCategory> productCategories = await _client.ProductCategories.GetAsync(new ProductCategoryQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(productCategories);

            if (productCategories.Count > 0)
            {
                ProductCategory? productCategory = await _client.ProductCategories.GetAsync(productCategories.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(productCategory);
            }
        }
    }
}
