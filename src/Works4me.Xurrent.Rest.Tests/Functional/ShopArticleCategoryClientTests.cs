using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ShopArticleCategoryClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetShopArticleCategoriesAsync()
        {
            ReadOnlyKeyedDataCollection<ShopArticleCategory> shopArticleCategories = await _client.ShopArticleCategories.GetAsync(new ShopArticleCategoryQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(shopArticleCategories);

            if (shopArticleCategories.Count > 0)
            {
                ShopArticleCategory? shopArticleCategory = await _client.ShopArticleCategories.GetAsync(shopArticleCategories.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(shopArticleCategory);
            }
        }
    }
}
