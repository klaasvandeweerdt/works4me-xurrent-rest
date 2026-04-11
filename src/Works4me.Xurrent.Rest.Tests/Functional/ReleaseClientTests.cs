using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ReleaseClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetReleasesAsync()
        {
            ReadOnlyKeyedDataCollection<Release> releases = await _client.Releases.GetAsync(new ReleaseQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(releases);

            if (releases.Count > 0)
            {
                Release? release = await _client.Releases.GetAsync(releases.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(release);
            }
        }
    }
}
