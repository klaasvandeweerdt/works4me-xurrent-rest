using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class AutomationRuleClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetAutomationRulesAsync()
        {
            ReadOnlyKeyedDataCollection<AutomationRule> automationRules = await _client.AutomationRules.GetAsync(new AutomationRuleQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(automationRules);

            if (automationRules.Count > 0)
            {
                AutomationRule? automationRule = await _client.AutomationRules.GetAsync(automationRules.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(automationRule);
            }
        }
    }
}
