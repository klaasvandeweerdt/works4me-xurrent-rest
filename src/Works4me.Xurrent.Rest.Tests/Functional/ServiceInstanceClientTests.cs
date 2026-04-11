using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ServiceInstanceClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetServiceInstancesAsync()
        {
            ReadOnlyKeyedDataCollection<ServiceInstance> serviceInstances = await _client.ServiceInstances.GetAsync(new ServiceInstanceQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(serviceInstances);

            if (serviceInstances.Count > 0)
            {
                ServiceInstance? serviceInstance = await _client.ServiceInstances.GetAsync(serviceInstances.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(serviceInstance);
            }
        }
    }
}
