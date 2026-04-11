using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class RequestClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetRequestsAsync()
        {
            ReadOnlyKeyedDataCollection<Request> requests = await _client.Requests.GetAsync(new RequestQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(requests);

            if (requests.Count > 0)
            {
                Request? request = await _client.Requests.GetAsync(requests.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(request);
            }
        }
    }
}
