using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class InvoiceClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetInvoicesAsync()
        {
            ReadOnlyKeyedDataCollection<Invoice> invoices = await _client.Invoices.GetAsync(new InvoiceQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(invoices);

            if (invoices.Count > 0)
            {
                Invoice? invoice = await _client.Invoices.GetAsync(invoices.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(invoice);
            }
        }
    }
}
