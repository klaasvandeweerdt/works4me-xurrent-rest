using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class SlaCoverageGroupClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetSlaCoverageGroupsAsync()
        {
            ReadOnlyKeyedDataCollection<SlaCoverageGroup> slaCoverageGroups = await _client.SlaCoverageGroups.GetAsync(new SlaCoverageGroupQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(slaCoverageGroups);

            if (slaCoverageGroups.Count > 0)
            {
                SlaCoverageGroup? slaCoverageGroup = await _client.SlaCoverageGroups.GetAsync(slaCoverageGroups.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(slaCoverageGroup);
            }
        }
    }
}
