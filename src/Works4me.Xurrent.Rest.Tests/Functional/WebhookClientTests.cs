using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class WebhookClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetWebhooksAsync()
        {
            ReadOnlyKeyedDataCollection<Webhook> webhooks = await _client.Webhooks.GetAsync(new WebhookQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(webhooks);

            if (webhooks.Count > 0)
            {
                Webhook? webhook = await _client.Webhooks.GetAsync(webhooks.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(webhook);
            }
        }
    }
}
