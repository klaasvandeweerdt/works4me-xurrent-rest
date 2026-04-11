using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class TrashItemClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetTrashAsync()
        {
            ReadOnlyKeyedDataCollection<TrashItem> trash = await _client.Trash.GetAsync(new TrashItemQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(trash);

            if (trash.Count > 0)
            {
                TrashItem? trashItem = await _client.Trash.GetAsync(trash.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(trashItem);
            }
        }
    }
}
