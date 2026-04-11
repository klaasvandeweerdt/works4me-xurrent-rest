using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class CiStagedChangeClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetCiStagedChangesAsync()
        {
            ReadOnlyKeyedDataCollection<CiStagedChange> ciStagedChanges = await _client.CiStagedChanges.GetAsync(new CiStagedChangeQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(ciStagedChanges);

            if (ciStagedChanges.Count > 0)
            {
                CiStagedChange? ciStagedChange = await _client.CiStagedChanges.GetAsync(ciStagedChanges.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(ciStagedChange);
            }
        }
    }
}
