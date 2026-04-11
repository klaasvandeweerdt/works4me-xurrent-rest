using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class CustomCollectionClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetCustomCollectionAsync()
        {
            ReadOnlyKeyedDataCollection<CustomCollection> customCollections = await _client.CustomCollection.GetAsync(new CustomCollectionQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(customCollections);

            if (customCollections.Count > 0)
            {
                CustomCollection? customCollection = await _client.CustomCollection.GetAsync(customCollections.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(customCollection);
            }
        }
    }
}
