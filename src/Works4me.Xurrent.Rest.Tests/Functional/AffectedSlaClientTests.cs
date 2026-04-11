using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Extensions;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class AffectedSlaClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetAffectedSlaAsync()
        {
            ReadOnlyKeyedDataCollection<AffectedSla> affectedSlas = await _client.AffectedSlas.GetAsync(new AffectedSlaQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(affectedSlas);

            IEnumerable<AffectedSla> noTargets = affectedSlas.Where(x => x.NextTargetAt is not null && x.NextTargetAt.Value.IsNoTarget());
            Assert.NotNull(noTargets);

            IEnumerable<AffectedSla> clocksStopped = affectedSlas.Where(x => x.NextTargetAt is not null && x.NextTargetAt.Value.IsClockStopped());
            Assert.NotNull(clocksStopped);

            IEnumerable<AffectedSla> bestEfforts = affectedSlas.Where(x => x.NextTargetAt is not null && x.NextTargetAt.Value.IsBestEffort());
            Assert.NotNull(bestEfforts);

            if (affectedSlas.Count > 0)
            {
                AffectedSla? affectedSla = await _client.AffectedSlas.GetAsync(affectedSlas.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(affectedSla);
                Assert.NotNull(affectedSla.Accountability);
            }
        }
    }
}
