using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ServiceOfferingClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetServiceOfferingsAsync()
        {
            ReadOnlyKeyedDataCollection<ServiceOffering> serviceOfferings = await _client.ServiceOfferings.GetAsync(new ServiceOfferingQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(serviceOfferings);

            if (serviceOfferings.Count > 0)
            {
                ServiceOffering? serviceOffering = await _client.ServiceOfferings.GetAsync(serviceOfferings.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(serviceOffering);
            }
        }
    }
}
