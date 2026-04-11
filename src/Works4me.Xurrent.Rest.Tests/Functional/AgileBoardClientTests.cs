using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class AgileBoardClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetAgileBoardsAsync()
        {
            ReadOnlyKeyedDataCollection<AgileBoard> agileBoards = await _client.AgileBoards.GetAsync(new AgileBoardQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(agileBoards);

            if (agileBoards.Count > 0)
            {
                AgileBoard? agileBoard = await _client.AgileBoards.GetAsync(agileBoards.GetRandomItem().Id, TestContext.Current.CancellationToken);
                Assert.NotNull(agileBoard);
            }
        }
    }
}
