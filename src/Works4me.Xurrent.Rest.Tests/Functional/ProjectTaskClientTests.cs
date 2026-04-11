using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ProjectTaskClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetProjectTasksAsync()
        {
            ReadOnlyKeyedDataCollection<ProjectTask> projectTasks = await _client.ProjectTasks.GetAsync(new ProjectTaskQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(projectTasks);

            if (projectTasks.Count > 0)
            {
                ProjectTask? projectTask = await _client.ProjectTasks.GetAsync(projectTasks.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(projectTask);
            }
        }
    }
}
