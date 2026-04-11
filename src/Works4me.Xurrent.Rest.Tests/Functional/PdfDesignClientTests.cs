using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class PdfDesignClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetPdfDesignsAsync()
        {
            ReadOnlyKeyedDataCollection<PdfDesign> pdfDesigns = await _client.PdfDesigns.GetAsync(new PdfDesignQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(pdfDesigns);

            if (pdfDesigns.Count > 0)
            {
                PdfDesign? pdfDesign = await _client.PdfDesigns.GetAsync(pdfDesigns.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(pdfDesign);
            }
        }
    }
}
