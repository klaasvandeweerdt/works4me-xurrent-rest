using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class WorkflowClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetWorkflowsAsync()
        {
            ReadOnlyKeyedDataCollection<Workflow> workflows = await _client.Workflows.GetAsync(new WorkflowQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(workflows);

            if (workflows.Count > 0)
            {
                Workflow? workflow = await _client.Workflows.GetAsync(workflows.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(workflow);
            }
        }
    }
}
