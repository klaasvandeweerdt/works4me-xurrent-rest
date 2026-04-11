using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class CustomCollectionElementClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetCustomCollectionElementsAsync()
        {
            ReadOnlyKeyedDataCollection<CustomCollectionElement> customCollectionElements = await _client.CustomCollectionElements.GetAsync(new CustomCollectionElementQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(customCollectionElements);

            if (customCollectionElements.Count > 0)
            {
                CustomCollectionElement? customCollectionElement = await _client.CustomCollectionElements.GetAsync(customCollectionElements.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(customCollectionElement);
            }
        }
    }
}
