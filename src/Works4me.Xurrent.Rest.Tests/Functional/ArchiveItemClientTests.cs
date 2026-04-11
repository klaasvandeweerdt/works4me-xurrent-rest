using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ArchiveItemClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetArchiveAsync()
        {
            ReadOnlyKeyedDataCollection<ArchiveItem> archive = await _client.Archive.GetAsync(new ArchiveItemQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(archive);

            if (archive.Count > 0)
            {
                ArchiveItem? archiveItem = await _client.Archive.GetAsync(archive.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(archiveItem);
            }
        }
    }
}
