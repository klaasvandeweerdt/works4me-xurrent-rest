using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Works4me.Xurrent.Rest.Extensions
{
    /// <summary>
    /// A set of <see cref="HttpHeaders"/> extension methods.
    /// </summary>
    internal static class HttpHeadersExtensions
    {
        private static readonly DateTimeOffset UnixEpoch = new(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        /// <summary>Attempts to read an integer value from the specified HTTP header.</summary>
        /// <param name="headers">The HTTP headers to inspect.</param>
        /// <param name="headerName">The name of the header containing the integer value.</param>
        /// <returns>An <see cref="int"/> representing the parsed header value; or <see langword="null"/> if the header is missing, empty, or does not contain a valid integer value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="headers"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="headerName"/> is <see langword="null"/> or whitespace.</exception>
        public static int? GetInt(this HttpHeaders headers, string headerName)
        {
            if (headers is null)
                throw new ArgumentNullException(nameof(headers));

            if (string.IsNullOrWhiteSpace(headerName))
                throw new ArgumentException($"'{nameof(headerName)}' cannot be null or whitespace.", nameof(headerName));

            if (headers.TryGetValues(headerName, out IEnumerable<string>? headerValues))
            {
                string? headerValue = headerValues.FirstOrDefault();
                if (int.TryParse(headerValue, out int value))
                {
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Attempts to read a Unix timestamp (in seconds) from the specified HTTP header and converts it into a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="headers">The HTTP headers to inspect.</param>
        /// <param name="headerName">The name of the header containing the Unix timestamp.</param>
        /// <returns>A <see cref="DateTimeOffset"/> representing the converted Unix timestamp;or <see langword="null"/> if the header is missing, empty, or does not contain a valid integer value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="headers"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="headerName"/> is <see langword="null"/> or whitespace.</exception>
        public static DateTimeOffset? GetUnixTime(this HttpHeaders headers, string headerName)
        {
            if (headers is null)
                throw new ArgumentNullException(nameof(headers));

            if (string.IsNullOrWhiteSpace(headerName))
                throw new ArgumentException($"'{nameof(headerName)}' cannot be null or whitespace.", nameof(headerName));

            if (headers.TryGetValues(headerName, out IEnumerable<string>? headerValues))
            {
                string? headerValue = headerValues.FirstOrDefault();
                if (long.TryParse(headerValue, out long value))
                {
                    DateTimeOffset result = UnixEpoch.AddSeconds(value);
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieves the pagination link values (first, previous, next) defined in the HTTP <c>Link</c> header.
        /// </summary>
        /// <param name="headers">The HTTP headers to inspect.</param>
        /// <returns>
        /// An instance of <see cref="HttpPaginationLinks"/> containing the extracted pagination links. <br/>
        /// If the <c>link</c> header is missing or has no valid values, an empty <see cref="HttpPaginationLinks"/> is returned.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="headers"/> is <see langword="null"/>.</exception>
        public static HttpPaginationLinks GetPaginationLinks(this HttpHeaders headers)
        {
            if (headers is null)
                throw new ArgumentNullException(nameof(headers));

            if (headers.TryGetValues("link", out IEnumerable<string>? headerValues))
                return HttpPaginationLinks.GetLinksFromHeader(headerValues.FirstOrDefault());

            return new HttpPaginationLinks();
        }
    }
}
