using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class SprintClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetSprintsAsync()
        {
            ReadOnlyKeyedDataCollection<Sprint> sprints = await _client.Sprints.GetAsync(new SprintQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(sprints);

            if (sprints.Count > 0)
            {
                Sprint? sprint = await _client.Sprints.GetAsync(sprints.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(sprint);
            }
        }
    }
}
