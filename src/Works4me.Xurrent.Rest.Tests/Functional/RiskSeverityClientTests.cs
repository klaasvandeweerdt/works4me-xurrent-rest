using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class RiskSeverityClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetRiskSeveritiesAsync()
        {
            ReadOnlyKeyedDataCollection<RiskSeverity> riskSeverities = await _client.RiskSeverities.GetAsync(new RiskSeverityQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(riskSeverities);

            if (riskSeverities.Count > 0)
            {
                RiskSeverity? riskSeverity = await _client.RiskSeverities.GetAsync(riskSeverities.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(riskSeverity);
            }
        }
    }
}
