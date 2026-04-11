using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class TeamClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetTeamsAsync()
        {
            ReadOnlyKeyedDataCollection<Team> teams = await _client.Teams.GetAsync(new TeamQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(teams);

            if (teams.Count > 0)
            {
                Team? team = await _client.Teams.GetAsync(teams.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(team);
            }
        }
    }
}
