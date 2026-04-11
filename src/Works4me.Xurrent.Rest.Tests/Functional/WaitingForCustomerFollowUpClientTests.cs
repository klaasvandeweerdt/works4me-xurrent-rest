using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class WaitingForCustomerFollowUpClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetWaitingForCustomerFollowUpsAsync()
        {
            ReadOnlyKeyedDataCollection<WaitingForCustomerFollowUp> waitingForCustomerFollowUps = await _client.WaitingForCustomerFollowUps.GetAsync(new WaitingForCustomerFollowUpQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(waitingForCustomerFollowUps);

            if (waitingForCustomerFollowUps.Count > 0)
            {
                WaitingForCustomerFollowUp? waitingForCustomerFollowUp = await _client.WaitingForCustomerFollowUps.GetAsync(waitingForCustomerFollowUps.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(waitingForCustomerFollowUp);
            }
        }
    }
}
