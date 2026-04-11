using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class RiskClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetRisksAsync()
        {
            ReadOnlyKeyedDataCollection<Risk> risks = await _client.Risks.GetAsync(new RiskQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(risks);

            if (risks.Count > 0)
            {
                Risk? risk = await _client.Risks.GetAsync(risks.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(risk);
            }
        }
    }
}
