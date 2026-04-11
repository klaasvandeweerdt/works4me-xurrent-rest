using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class FirstLineSupportAgreementClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetFirstLineSupportAgreementsAsync()
        {
            ReadOnlyKeyedDataCollection<FirstLineSupportAgreement> firstLineSupportAgreements = await _client.FirstLineSupportAgreements.GetAsync(new FirstLineSupportAgreementQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(firstLineSupportAgreements);

            if (firstLineSupportAgreements.Count > 0)
            {
                FirstLineSupportAgreement? firstLineSupportAgreement = await _client.FirstLineSupportAgreements.GetAsync(firstLineSupportAgreements.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(firstLineSupportAgreement);
            }
        }
    }
}
