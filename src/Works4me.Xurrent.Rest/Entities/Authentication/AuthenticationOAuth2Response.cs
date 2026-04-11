using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// The OAuth 2.0 authentication response.
    /// </summary>
    internal sealed class AuthenticationOAuth2Response
    {
        /// <summary>
        /// The access token.
        /// </summary>
        [XurrentField("access_token")]
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// The token type.
        /// </summary>
        [XurrentField("token_type")]
        public string TokenType { get; set; } = string.Empty;

        /// <summary>
        /// Expires in seconds.
        /// </summary>
        [XurrentField("expires_in")]
        public int ExpiresIn { get; set; } = 0;
    }
}
