using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ConfigurationItemClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetConfigurationItemsAsync()
        {
            ReadOnlyKeyedDataCollection<ConfigurationItem> configurationItems = await _client.ConfigurationItems.GetAsync(new ConfigurationItemQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(configurationItems);

            if (configurationItems.Count > 0)
            {
                ConfigurationItem? configurationItem = await _client.ConfigurationItems.GetAsync(configurationItems.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(configurationItem);
            }
        }
    }
}
