using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class UiExtensionClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetUiExtensionsAsync()
        {
            ReadOnlyKeyedDataCollection<UiExtension> uiExtensions = await _client.UiExtensions.GetAsync(new UiExtensionQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(uiExtensions);

            if (uiExtensions.Count > 0)
            {
                UiExtension? uiExtension = await _client.UiExtensions.GetAsync(uiExtensions.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(uiExtension);
            }
        }
    }
}
