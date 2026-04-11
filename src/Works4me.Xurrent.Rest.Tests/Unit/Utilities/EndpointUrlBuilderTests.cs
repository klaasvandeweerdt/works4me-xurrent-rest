using System;
using Works4me.Xurrent.Rest.Utilities;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Unit.Utilities
{
    public sealed class EndpointUrlBuilderTests
    {
        [Theory]
        [InlineData(EnvironmentRegion.AU, EnvironmentType.Quality, "au.xurrent.qa")]
        [InlineData(EnvironmentRegion.AU, EnvironmentType.Demo, "xurrent-demo.com")]
        [InlineData(EnvironmentRegion.AU, (EnvironmentType)999, "au.xurrent.com")]
        [InlineData(EnvironmentRegion.UK, EnvironmentType.Quality, "uk.xurrent.qa")]
        [InlineData(EnvironmentRegion.UK, EnvironmentType.Demo, "xurrent-demo.com")]
        [InlineData(EnvironmentRegion.UK, (EnvironmentType)999, "uk.xurrent.com")]
        [InlineData(EnvironmentRegion.US, EnvironmentType.Quality, "us.xurrent.qa")]
        [InlineData(EnvironmentRegion.US, EnvironmentType.Demo, "xurrent-demo.com")]
        [InlineData(EnvironmentRegion.US, (EnvironmentType)999, "us.xurrent.com")]
        [InlineData(EnvironmentRegion.CH, EnvironmentType.Quality, "ch.xurrent.qa")]
        [InlineData(EnvironmentRegion.CH, EnvironmentType.Demo, "xurrent-demo.com")]
        [InlineData(EnvironmentRegion.CH, (EnvironmentType)999, "ch.xurrent.com")]
        public void GetBaseUrl_RegionSpecificMappings_ReturnExpectedHost(EnvironmentRegion region, EnvironmentType environment, string expected)
        {
            string actual = EndpointUrlBuilder.GetBaseUrl(region, environment);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EnvironmentType.Quality, "xurrent.qa")]
        [InlineData(EnvironmentType.Demo, "xurrent-demo.com")]
        [InlineData((EnvironmentType)999, "xurrent.com")]
        public void GetBaseUrl_DefaultRegionBranch_ReturnExpectedHost(EnvironmentType environment, string expected)
        {
            EnvironmentRegion unknownRegion = (EnvironmentRegion)999;

            string actual = EndpointUrlBuilder.GetBaseUrl(unknownRegion, environment);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_CustomDomain_ReturnsExpectedRestEndpoint()
        {
            Uri uri = EndpointUrlBuilder.Get("example.test");

            Assert.Equal("https://api.example.test/v1/", uri.ToString());
        }

        [Fact]
        public void GetOAuth2Url_WhenHostStartsWithApiPrefix_RewritesToOauthAndSetsTokenPath()
        {
            Uri apiUrl = new("https://api.xurrent.com/v1/");

            Uri oauthUrl = EndpointUrlBuilder.GetOAuth2Url(apiUrl);

            Assert.Equal("https://oauth.xurrent.com/token", oauthUrl.ToString());
        }

        [Fact]
        public void GetOAuth2Url_WhenHostDoesNotStartWithApiPrefix_DoesNotRewriteHostAndSetsTokenPath()
        {
            Uri apiUrl = new("https://xurrent.com/v1/");

            Uri oauthUrl = EndpointUrlBuilder.GetOAuth2Url(apiUrl);

            Assert.Equal("https://xurrent.com/token", oauthUrl.ToString());
        }

        [Fact]
        public void GetOAuth2Url_PreservesSchemePortAndQuery_AndForcesTokenPath()
        {
            Uri apiUrl = new("https://api.example.test:8443/v1/?a=1&b=2");

            Uri oauthUrl = EndpointUrlBuilder.GetOAuth2Url(apiUrl);

            Assert.Equal("https", oauthUrl.Scheme);
            Assert.Equal("oauth.example.test", oauthUrl.Host);
            Assert.Equal(8443, oauthUrl.Port);
            Assert.Equal("/token", oauthUrl.AbsolutePath);
            Assert.Equal("a=1&b=2", oauthUrl.Query.TrimStart('?'));
        }
    }
}
