using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ProjectClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetProjectsAsync()
        {
            ReadOnlyKeyedDataCollection<Project> projects = await _client.Projects.GetAsync(new ProjectQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(projects);

            if (projects.Count > 0)
            {
                Project? project = await _client.Projects.GetAsync(projects.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(project);
            }
        }
    }
}
