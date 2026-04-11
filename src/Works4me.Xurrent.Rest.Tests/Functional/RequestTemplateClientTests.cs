using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class RequestTemplateClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetRequestTemplatesAsync()
        {
            ReadOnlyKeyedDataCollection<RequestTemplate> requestTemplates = await _client.RequestTemplates.GetAsync(new RequestTemplateQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(requestTemplates);

            if (requestTemplates.Count > 0)
            {
                RequestTemplate? requestTemplate = await _client.RequestTemplates.GetAsync(requestTemplates.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(requestTemplate);
            }
        }
    }
}
