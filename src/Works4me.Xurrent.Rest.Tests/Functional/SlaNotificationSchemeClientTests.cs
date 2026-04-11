using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class SlaNotificationSchemeClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetSlaNotificationSchemesAsync()
        {
            ReadOnlyKeyedDataCollection<SlaNotificationScheme> slaNotificationSchemes = await _client.SlaNotificationSchemes.GetAsync(new SlaNotificationSchemeQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(slaNotificationSchemes);

            if (slaNotificationSchemes.Count > 0)
            {
                SlaNotificationScheme? slaNotificationScheme = await _client.SlaNotificationSchemes.GetAsync(slaNotificationSchemes.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(slaNotificationScheme);
            }
        }
    }
}
