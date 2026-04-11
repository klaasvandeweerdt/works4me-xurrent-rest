using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Models
{
    public sealed class HttpPaginationLinksTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void GetLinksFromHeader_WhenHeaderIsNullOrWhitespace_ReturnsEmptyLinks(string? header)
        {
            HttpPaginationLinks links = HttpPaginationLinks.GetLinksFromHeader(header);

            Assert.Null(links.FirstLink);
            Assert.Null(links.PreviousLink);
            Assert.Null(links.NextLink);
        }

        [Fact]
        public void GetLinksFromHeader_WhenHeaderContainsFirstPrevNext_ParsesAll()
        {
            string header =
                "<https://example.test/api/people?page=1>; rel=\"first\", " +
                "<https://example.test/api/people?page=2>; rel=\"prev\", " +
                "<https://example.test/api/people?page=4>; rel=\"next\"";

            HttpPaginationLinks links = HttpPaginationLinks.GetLinksFromHeader(header);

            Assert.Equal("https://example.test/api/people?page=1", links.FirstLink);
            Assert.Equal("https://example.test/api/people?page=2", links.PreviousLink);
            Assert.Equal("https://example.test/api/people?page=4", links.NextLink);
        }

        [Fact]
        public void GetLinksFromHeader_WhenRelIsDifferentCase_IgnoresThoseLinks()
        {
            string header =
                "<https://example.test/api/people?page=1>; rel=\"FIRST\", " +
                "<https://example.test/api/people?page=2>; rel=\"Prev\", " +
                "<https://example.test/api/people?page=4>; rel=\"Next\"";

            HttpPaginationLinks links = HttpPaginationLinks.GetLinksFromHeader(header);

            Assert.Null(links.FirstLink);
            Assert.Null(links.PreviousLink);
            Assert.Null(links.NextLink);
        }

        [Fact]
        public void GetLinksFromHeader_WhenLinkContainsCommaInsideAngleBrackets_DoesNotSplitIncorrectly()
        {
            string header =
                "<https://example.test/api/people?filter=a,b>; rel=\"next\", " +
                "<https://example.test/api/people?page=1>; rel=\"first\"";

            HttpPaginationLinks links = HttpPaginationLinks.GetLinksFromHeader(header);

            Assert.Equal("https://example.test/api/people?page=1", links.FirstLink);
            Assert.Null(links.PreviousLink);
            Assert.Equal("https://example.test/api/people?filter=a,b", links.NextLink);
        }

        [Fact]
        public void GetLinksFromHeader_WhenPartsAreWhitespaceOrMissingRelOrLink_IgnoresThoseParts()
        {
            string header =
                " , " +
                "<https://example.test/api/people?page=1>; rel=\"first\", " +
                "rel=\"next\", " + // missing <...>
                "<https://example.test/api/people?page=3>; something=\"else\"";

            HttpPaginationLinks links = HttpPaginationLinks.GetLinksFromHeader(header);

            Assert.Equal("https://example.test/api/people?page=1", links.FirstLink);
            Assert.Null(links.PreviousLink);
            Assert.Null(links.NextLink);
        }

        [Fact]
        public void GetLinksFromHeader_WhenRelIsUnknown_IgnoresIt()
        {
            string header =
                "<https://example.test/api/people?page=9>; rel=\"last\", " +
                "<https://example.test/api/people?page=4>; rel=\"next\"";

            HttpPaginationLinks links = HttpPaginationLinks.GetLinksFromHeader(header);

            Assert.Null(links.FirstLink);
            Assert.Null(links.PreviousLink);
            Assert.Equal("https://example.test/api/people?page=4", links.NextLink);
        }
    }
}
