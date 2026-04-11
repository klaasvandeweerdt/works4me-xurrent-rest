using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class SkillPoolClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetSkillPoolsAsync()
        {
            ReadOnlyKeyedDataCollection<SkillPool> skillPools = await _client.SkillPools.GetAsync(new SkillPoolQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(skillPools);

            if (skillPools.Count > 0)
            {
                SkillPool? skillPool = await _client.SkillPools.GetAsync(skillPools.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(skillPool);
            }
        }
    }
}
