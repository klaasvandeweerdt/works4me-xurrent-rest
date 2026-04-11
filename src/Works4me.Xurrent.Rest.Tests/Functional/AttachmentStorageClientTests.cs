using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class AttachmentStorageClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetAttachmentStorageAsync()
        {
            AttachmentStorage? attachmentStorage = await _client.AttachmentStorage.CreateAsync(TestContext.Current.CancellationToken);

            Assert.NotNull(attachmentStorage);
        }
    }
}
