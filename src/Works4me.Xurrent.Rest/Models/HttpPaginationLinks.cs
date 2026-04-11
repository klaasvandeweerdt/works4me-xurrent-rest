using System;
using System.Text.RegularExpressions;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// A HTTP header pagination link parser.
    /// </summary>
    internal sealed class HttpPaginationLinks
    {
        private string? _firstLink;
        private string? _previousLink;
        private string? _nextLink;

        private static readonly Regex RelRegex = new("(?<=rel=\").+?(?=\")", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex LinkRegex = new("(?<=<).+?(?=>)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private const string SplitPattern = ",(?![^<]*>)";

        /// <summary>
        /// Gets the first pagination link.
        /// </summary>
        public string? FirstLink
        {
            get => _firstLink;
            private set => _firstLink = value;
        }

        /// <summary>
        /// Gets the previous pagination link.
        /// </summary>
        public string? PreviousLink
        {
            get => _previousLink;
            private set => _previousLink = value;
        }

        /// <summary>
        /// Gets the next pagination link.
        /// </summary>
        public string? NextLink
        {
            get => _nextLink;
            private set => _nextLink = value;
        }

        /// <summary>
        /// Parses the links specified in the HTTP response header.
        /// </summary>
        /// <param name="linkHeader">The link header string to parse.</param>
        /// <returns>An instance of <see cref="HttpPaginationLinks"/> containing the parsed links.</returns>
        /// <exception cref="XurrentException">Thrown when the link header cannot be parsed.</exception>
        public static HttpPaginationLinks GetLinksFromHeader(string? linkHeader)
        {
            HttpPaginationLinks retval = new();

            if (string.IsNullOrWhiteSpace(linkHeader))
                return retval;

            try
            {
                string[] links = Regex.Split(linkHeader, SplitPattern);
                foreach (string link in links)
                {
                    if (string.IsNullOrWhiteSpace(link))
                    {
                        continue;
                    }

                    Match relMatch = RelRegex.Match(link);
                    Match linkMatch = LinkRegex.Match(link);

                    if (relMatch.Success && linkMatch.Success)
                    {
                        switch (relMatch.Value)
                        {
                            case "first":
                                retval.FirstLink = linkMatch.Value;
                                break;

                            case "prev":
                                retval.PreviousLink = linkMatch.Value;
                                break;

                            case "next":
                                retval.NextLink = linkMatch.Value;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new XurrentException("Error parsing the link header.", ex);
            }

            return retval;
        }
    }
}
