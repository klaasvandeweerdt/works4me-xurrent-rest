using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ProjectTemplateClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetProjectTemplatesAsync()
        {
            ReadOnlyKeyedDataCollection<ProjectTemplate> projectTemplates = await _client.ProjectTemplates.GetAsync(new ProjectTemplateQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(projectTemplates);

            if (projectTemplates.Count > 0)
            {
                ProjectTemplate? projectTemplate = await _client.ProjectTemplates.GetAsync(projectTemplates.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(projectTemplate);
            }
        }
    }
}
