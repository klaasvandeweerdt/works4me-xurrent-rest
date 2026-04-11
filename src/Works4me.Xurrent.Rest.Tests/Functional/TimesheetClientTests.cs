using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class TimesheetClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetTimesheetsAsync()
        {
            //TODO: TimeSheets
        }
    }
}
