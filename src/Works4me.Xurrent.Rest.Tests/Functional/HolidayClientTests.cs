using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class HolidayClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetHolidaysAsync()
        {
            ReadOnlyKeyedDataCollection<Holiday> holidays = await _client.Holidays.GetAsync(new HolidayQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(holidays);

            if (holidays.Count > 0)
            {
                Holiday? holiday = await _client.Holidays.GetAsync(holidays.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(holiday);
            }
        }
    }
}
