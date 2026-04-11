using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class TimeEntryClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetTimeEntriesAsync()
        {
            ReadOnlyKeyedDataCollection<TimeEntry> timeEntries = await _client.TimeEntries.GetAsync(new TimeEntryQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(timeEntries);

            if (timeEntries.Count > 0)
            {
                TimeEntry? timeEntry = await _client.TimeEntries.GetAsync(timeEntries.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(timeEntry);
            }
        }
    }
}
