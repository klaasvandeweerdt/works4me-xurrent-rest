using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class OutOfOfficePeriodClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetOutOfOfficePeriodsAsync()
        {
            ReadOnlyKeyedDataCollection<OutOfOfficePeriod> outOfOfficePeriods = await _client.OutOfOfficePeriods.GetAsync(new OutOfOfficePeriodQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(outOfOfficePeriods);

            if (outOfOfficePeriods.Count > 0)
            {
                OutOfOfficePeriod? outOfOfficePeriod = await _client.OutOfOfficePeriods.GetAsync(outOfOfficePeriods.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(outOfOfficePeriod);
            }
        }
    }
}
