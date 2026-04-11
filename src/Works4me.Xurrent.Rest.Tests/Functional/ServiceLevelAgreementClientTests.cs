using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ServiceLevelAgreementClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetServiceLevelAgreementsAsync()
        {
            ReadOnlyKeyedDataCollection<ServiceLevelAgreement> serviceLevelAgreements = await _client.ServiceLevelAgreements.GetAsync(new ServiceLevelAgreementQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(serviceLevelAgreements);

            if (serviceLevelAgreements.Count > 0)
            {
                ServiceLevelAgreement? serviceLevelAgreement = await _client.ServiceLevelAgreements.GetAsync(serviceLevelAgreements.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(serviceLevelAgreement);
            }
        }
    }
}
