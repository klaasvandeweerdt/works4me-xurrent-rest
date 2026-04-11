using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class TimesheetSettingClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetTimesheetSettingsAsync()
        {
            ReadOnlyKeyedDataCollection<TimesheetSetting> timesheetSettings = await _client.TimesheetSettings.GetAsync(new TimesheetSettingQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(timesheetSettings);

            if (timesheetSettings.Count > 0)
            {
                TimesheetSetting? timesheetSetting = await _client.TimesheetSettings.GetAsync(timesheetSettings.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(timesheetSetting);
            }
        }
    }
}
