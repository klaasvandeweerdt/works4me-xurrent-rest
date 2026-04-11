using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class AuditLineClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetAuditLinesAsync()
        {
            ReadOnlyKeyedDataCollection<AuditLine> auditLines = await _client.AuditLines.GetAsync(new AuditLineQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(auditLines);

            if (auditLines.Count > 0)
            {
                AuditLine? auditLine = await _client.AuditLines.GetAsync(auditLines.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(auditLine);
            }
        }
    }
}
