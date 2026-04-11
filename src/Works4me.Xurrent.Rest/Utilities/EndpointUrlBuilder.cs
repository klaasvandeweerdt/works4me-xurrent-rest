using System;

namespace Works4me.Xurrent.Rest.Utilities
{
    /// <summary>
    /// Get the Xurrent REST URL.
    /// </summary>
    internal static class EndpointUrlBuilder
    {
        /// <summary>
        /// Returns the base URL for a specific environment.
        /// </summary>
        /// <param name="environment">The environment type.</param>
        /// <param name="environmentRegion">The environment region.</param>
        /// <returns>The API endpoint URL for the specified environment.</returns>
        internal static string GetBaseUrl(EnvironmentRegion environmentRegion, EnvironmentType environment)
        {
            return environmentRegion switch
            {
                EnvironmentRegion.AU => environment switch
                {
                    EnvironmentType.Quality => "au.xurrent.qa",
                    EnvironmentType.Demo => "xurrent-demo.com",
                    _ => "au.xurrent.com",
                },
                EnvironmentRegion.UK => environment switch
                {
                    EnvironmentType.Quality => "uk.xurrent.qa",
                    EnvironmentType.Demo => "xurrent-demo.com",
                    _ => "uk.xurrent.com",
                },
                EnvironmentRegion.US => environment switch
                {
                    EnvironmentType.Quality => "us.xurrent.qa",
                    EnvironmentType.Demo => "xurrent-demo.com",
                    _ => "us.xurrent.com",
                },
                EnvironmentRegion.CH => environment switch
                {
                    EnvironmentType.Quality => "ch.xurrent.qa",
                    EnvironmentType.Demo => "xurrent-demo.com",
                    _ => "ch.xurrent.com",
                },
                _ => environment switch
                {
                    EnvironmentType.Quality => "xurrent.qa",
                    EnvironmentType.Demo => "xurrent-demo.com",
                    _ => "xurrent.com",
                },
            };
        }

        /// <summary>
        /// Returns the REST API endpoint for a custom domain.
        /// </summary>
        /// <param name="domainName">The custom domain name.</param>
        /// <returns>The REST API endpoint URL for the specified custom domain.</returns>
        internal static Uri Get(string domainName)
        {
            return new Uri($"https://api.{domainName}/v1/", UriKind.Absolute);
        }

        /// <summary>
        /// Get the Xurrent OAuth 2.0 authentication URL based on the REST API url.
        /// </summary>
        /// <param name="url">The custom name.</param>
        /// <returns>The Xurrent OAuth 2.0 authentication URL for the specified domain.</returns>
        public static Uri GetOAuth2Url(Uri url)
        {
            const string apiPrefix = "api.";
            const string oauthPrefix = "oauth.";

            string host = url.Host;

            if (host.StartsWith(apiPrefix, StringComparison.Ordinal))
                host = oauthPrefix + host.Substring(apiPrefix.Length);

            UriBuilder builder = new(url)
            {
                Host = host,
                Path = "token"
            };

            return builder.Uri;
        }
    }
}
