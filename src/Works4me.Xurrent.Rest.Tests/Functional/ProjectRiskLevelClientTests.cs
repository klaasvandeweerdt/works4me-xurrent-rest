using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ProjectRiskLevelClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetProjectRiskLevelsAsync()
        {
            ReadOnlyKeyedDataCollection<ProjectRiskLevel> projectRiskLevels = await _client.ProjectRiskLevels.GetAsync(new ProjectRiskLevelQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(projectRiskLevels);

            if (projectRiskLevels.Count > 0)
            {
                ProjectRiskLevel? projectRiskLevel = await _client.ProjectRiskLevels.GetAsync(projectRiskLevels.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(projectRiskLevel);
            }
        }
    }
}
