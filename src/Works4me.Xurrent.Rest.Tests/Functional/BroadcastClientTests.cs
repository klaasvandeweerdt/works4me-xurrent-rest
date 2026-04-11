using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class BroadcastClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetBroadcastsAsync()
        {
            ReadOnlyKeyedDataCollection<Broadcast> broadcasts = await _client.Broadcasts.GetAsync(new BroadcastQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(broadcasts);

            if (broadcasts.Count > 0)
            {
                Broadcast? broadcast = await _client.Broadcasts.GetAsync(broadcasts.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(broadcast);
            }
        }
    }
}
