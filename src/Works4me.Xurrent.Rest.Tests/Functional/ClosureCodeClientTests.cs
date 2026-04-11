using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ClosureCodeClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetClosureCodesAsync()
        {
            ReadOnlyKeyedDataCollection<ClosureCode> closureCodes = await _client.ClosureCodes.GetAsync(new ClosureCodeQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(closureCodes);

            if (closureCodes.Count > 0)
            {
                ClosureCode? closureCode = await _client.ClosureCodes.GetAsync(closureCodes.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(closureCode);
            }
        }
    }
}
