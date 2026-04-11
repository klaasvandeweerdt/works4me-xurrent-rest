using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class MeClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetMeAsync()
        {
            Person? me = await _client.Me.GetAsync(TestContext.Current.CancellationToken);

            Assert.NotNull(me);
            Assert.NotEqual(0, me.Id);
            Assert.NotNull(me.Name);
            Assert.NotNull(me.PrimaryEmail);
        }
    }
}
