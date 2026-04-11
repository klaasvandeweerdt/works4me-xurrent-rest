using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class TimeAllocationClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetTimeAllocationsAsync()
        {
            ReadOnlyKeyedDataCollection<TimeAllocation> timeAllocations = await _client.TimeAllocations.GetAsync(new TimeAllocationQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(timeAllocations);

            if (timeAllocations.Count > 0)
            {
                TimeAllocation? timeAllocation = await _client.TimeAllocations.GetAsync(timeAllocations.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(timeAllocation);
            }
        }
    }
}
