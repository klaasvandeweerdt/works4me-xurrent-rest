using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class AppInstanceClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetAppInstancesAsync()
        {
            ReadOnlyKeyedDataCollection<AppInstance> appInstances = await _client.AppInstances.GetAsync(new AppInstanceQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(appInstances);

            if (appInstances.Count > 0)
            {
                AppInstance? appInstance = await _client.AppInstances.GetAsync(appInstances.GetRandomItem().Id, TestContext.Current.CancellationToken);
                Assert.NotNull(appInstance);
            }
        }
    }
}
