using System;
using System.Net.Http.Headers;

namespace Works4me.Xurrent.Rest.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="AuthenticationToken"/> to update its rate-limit and cost-limit values from HTTP headers.
    /// </summary>
    internal static class AuthenticationTokenExtensions
    {
        /// <summary>
        /// Reads rate-limit and cost-limit headers and applies them to the token.
        /// </summary>
        /// <param name="token">The <see cref="AuthenticationToken"/> whose limits are to be updated.</param>
        /// <param name="headers">The <see cref="HttpHeaders"/> containing rate-limit and cost-limit values.</param>
        public static void UpdateLimitsFromHeaders(this AuthenticationToken token, HttpHeaders headers)
        {
            if (token is null)
                throw new ArgumentNullException(nameof(token));

            if (headers is null)
                throw new ArgumentNullException(nameof(headers));

            token.UpdateLimits(
                headers.GetInt("x-ratelimit-limit"),
                headers.GetInt("x-ratelimit-remaining"),
                headers.GetUnixTime("x-ratelimit-reset")
            );
        }

        /// <summary>
        /// Reads the "Retry-After" header from the specified <see cref="HttpHeaders"/> and updates the <see cref="AuthenticationToken"/>'s retry-after property.
        /// </summary>
        /// <param name="token">The <see cref="AuthenticationToken"/> whose retry-after property is to be updated.</param>
        /// <param name="headers">The <see cref="HttpHeaders"/> containing the retry-after value.</param>
        public static void UpdateRetryAfter(this AuthenticationToken token, HttpHeaders headers)
        {
            if (token is null)
                throw new ArgumentNullException(nameof(token));

            if (headers is null)
                throw new ArgumentNullException(nameof(headers));

            token.UpdateRetryAfter(headers.GetInt("retry-after"));
        }
    }
}
