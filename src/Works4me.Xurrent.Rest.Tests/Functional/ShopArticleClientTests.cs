using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ShopArticleClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetShopArticlesAsync()
        {
            ReadOnlyKeyedDataCollection<ShopArticle> shopArticles = await _client.ShopArticles.GetAsync(new ShopArticleQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(shopArticles);

            if (shopArticles.Count > 0)
            {
                ShopArticle? shopArticle = await _client.ShopArticles.GetAsync(shopArticles.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(shopArticle);
            }
        }
    }
}
