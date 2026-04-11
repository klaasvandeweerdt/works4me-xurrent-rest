using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class KnowledgeArticleTemplateClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetKnowledgeArticleTemplatesAsync()
        {
            ReadOnlyKeyedDataCollection<KnowledgeArticleTemplate> knowledgeArticleTemplates = await _client.KnowledgeArticleTemplates.GetAsync(new KnowledgeArticleTemplateQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(knowledgeArticleTemplates);

            if (knowledgeArticleTemplates.Count > 0)
            {
                KnowledgeArticleTemplate? knowledgeArticleTemplate = await _client.KnowledgeArticleTemplates.GetAsync(knowledgeArticleTemplates.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(knowledgeArticleTemplate);
            }
        }
    }
}
