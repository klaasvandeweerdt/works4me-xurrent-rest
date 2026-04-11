using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ContractClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetContractsAsync()
        {
            ReadOnlyKeyedDataCollection<Contract> contracts = await _client.Contracts.GetAsync(new ContractQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(contracts);

            if (contracts.Count > 0)
            {
                Contract? contract = await _client.Contracts.GetAsync(contracts.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(contract);
            }
        }
    }
}
