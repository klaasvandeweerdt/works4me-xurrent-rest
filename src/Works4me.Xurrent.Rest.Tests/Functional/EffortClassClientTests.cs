using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class EffortClassClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetEffortClassesAsync()
        {
            ReadOnlyKeyedDataCollection<EffortClass> effortClasses = await _client.EffortClasses.GetAsync(new EffortClassQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(effortClasses);

            if (effortClasses.Count > 0)
            {
                EffortClass? effortClass = await _client.EffortClasses.GetAsync(effortClasses.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(effortClass);
            }
        }
    }
}
