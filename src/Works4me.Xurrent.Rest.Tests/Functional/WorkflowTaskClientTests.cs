using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class WorkflowTaskClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetWorkflowTasksAsync()
        {
            ReadOnlyKeyedDataCollection<WorkflowTask> workflowTasks = await _client.WorkflowTasks.GetAsync(new WorkflowTaskQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(workflowTasks);

            if (workflowTasks.Count > 0)
            {
                WorkflowTask? workflowTask = await _client.WorkflowTasks.GetAsync(workflowTasks.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(workflowTask);
            }
        }
    }
}
