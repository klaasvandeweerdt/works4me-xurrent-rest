using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ServiceClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetServicesAsync()
        {
            ReadOnlyKeyedDataCollection<Service> services = await _client.Services.GetAsync(new ServiceQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(services);

            if (services.Count > 0)
            {
                Service? service = await _client.Services.GetAsync(services.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(service);
            }
        }
    }
}
