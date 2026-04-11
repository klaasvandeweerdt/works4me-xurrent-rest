using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class WorkflowTaskTemplateClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetWorkflowTaskTemplatesAsync()
        {
            ReadOnlyKeyedDataCollection<WorkflowTaskTemplate> workflowTaskTemplates = await _client.WorkflowTaskTemplates.GetAsync(new WorkflowTaskTemplateQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(workflowTaskTemplates);

            if (workflowTaskTemplates.Count > 0)
            {
                WorkflowTaskTemplate? workflowTaskTemplate = await _client.WorkflowTaskTemplates.GetAsync(workflowTaskTemplates.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(workflowTaskTemplate);
            }
        }
    }
}
