using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class WorkflowTypeClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetWorkflowTypesAsync()
        {
            ReadOnlyKeyedDataCollection<WorkflowType> workflowTypes = await _client.WorkflowTypes.GetAsync(new WorkflowTypeQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(workflowTypes);

            if (workflowTypes.Count > 0)
            {
                WorkflowType? workflowType = await _client.WorkflowTypes.GetAsync(workflowTypes.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(workflowType);
            }
        }
    }
}
