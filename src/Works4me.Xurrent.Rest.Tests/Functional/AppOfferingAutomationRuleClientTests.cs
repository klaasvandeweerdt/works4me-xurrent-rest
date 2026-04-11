using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class AppOfferingAutomationRuleClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetAppInstancesAsync()
        {
            ReadOnlyKeyedDataCollection<AppOfferingAutomationRule> appOfferingAutomationRules = await _client.AppOfferingAutomationRules.GetAsync(new AppOfferingAutomationRuleQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(appOfferingAutomationRules);

            if (appOfferingAutomationRules.Count > 0)
            {
                AppOfferingAutomationRule? appOfferingAutomationRule = await _client.AppOfferingAutomationRules.GetAsync(appOfferingAutomationRules.GetRandomItem().Id, TestContext.Current.CancellationToken);
                Assert.NotNull(appOfferingAutomationRule);
            }
        }
    }
}
