using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various app offering scope grant types.
    /// </summary>
    public enum AppOfferingScopeGrant
    {
        /// <summary>
        /// Indicates that the app offering scope grant type uses authorization code flow.
        /// </summary>
        [XurrentEnum("authorization_code")]
        AuthorizationCode,

        /// <summary>
        /// Indicates that the app offering scope grant type uses client credentials flow.
        /// </summary>
        [XurrentEnum("client_credentials")]
        ClientCredentials
    }
}
