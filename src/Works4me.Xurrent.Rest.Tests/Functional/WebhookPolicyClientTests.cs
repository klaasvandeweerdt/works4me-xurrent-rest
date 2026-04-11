using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class WebhookPolicyClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetWebhookPoliciesAsync()
        {
            ReadOnlyKeyedDataCollection<WebhookPolicy> webhookPolicies = await _client.WebhookPolicies.GetAsync(new WebhookPolicyQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(webhookPolicies);

            if (webhookPolicies.Count > 0)
            {
                WebhookPolicy? webhookPolicy = await _client.WebhookPolicies.GetAsync(webhookPolicies.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(webhookPolicy);
            }
        }
    }
}
