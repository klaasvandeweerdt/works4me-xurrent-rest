using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class CalendarClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetCalendarsAsync()
        {
            ReadOnlyKeyedDataCollection<Calendar> calendars = await _client.Calendars.GetAsync(new CalendarQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(calendars);

            if (calendars.Count > 0)
            {
                Calendar? calendar = await _client.Calendars.GetAsync(calendars.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(calendar);
            }
        }
    }
}
