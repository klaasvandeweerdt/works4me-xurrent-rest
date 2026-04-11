using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class KnowledgeArticleClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetKnowledgeArticlesAsync()
        {
            ReadOnlyKeyedDataCollection<KnowledgeArticle> knowledgeArticles = await _client.KnowledgeArticles.GetAsync(new KnowledgeArticleQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(knowledgeArticles);

            if (knowledgeArticles.Count > 0)
            {
                KnowledgeArticle? knowledgeArticle = await _client.KnowledgeArticles.GetAsync(knowledgeArticles.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(knowledgeArticle);
            }
        }
    }
}
