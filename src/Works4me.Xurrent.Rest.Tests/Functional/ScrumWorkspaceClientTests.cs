using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ScrumWorkspaceClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetScrumWorkspacesAsync()
        {
            ReadOnlyKeyedDataCollection<ScrumWorkspace> scrumWorkspaces = await _client.ScrumWorkspaces.GetAsync(new ScrumWorkspaceQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(scrumWorkspaces);

            if (scrumWorkspaces.Count > 0)
            {
                ScrumWorkspace? scrumWorkspace = await _client.ScrumWorkspaces.GetAsync(scrumWorkspaces.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(scrumWorkspace);
            }
        }
    }
}
