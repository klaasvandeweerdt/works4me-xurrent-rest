using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class WorkflowTemplateClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetWorkflowTemplatesAsync()
        {
            ReadOnlyKeyedDataCollection<WorkflowTemplate> workflowTemplates = await _client.WorkflowTemplates.GetAsync(new WorkflowTemplateQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(workflowTemplates);

            if (workflowTemplates.Count > 0)
            {
                WorkflowTemplate? workflowTemplate = await _client.WorkflowTemplates.GetAsync(workflowTemplates.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(workflowTemplate);
            }
        }
    }
}
