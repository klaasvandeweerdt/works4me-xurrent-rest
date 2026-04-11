using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various certificate signature algorithms.
    /// </summary>
    public enum JwtAlgorithm
    {
        /// <summary>
        /// Indicates the ECDSA algorithm using the P-256 curve and SHA-256.
        /// </summary>
        [XurrentEnum("es256")]
        ES256,

        /// <summary>
        /// Indicates the ECDSA algorithm using the P-384 curve and SHA-384.
        /// </summary>
        [XurrentEnum("es384")]
        ES384,

        /// <summary>
        /// Indicates the ECDSA algorithm using the P-521 curve and SHA-512.
        /// </summary>
        [XurrentEnum("es512")]
        ES512,

        /// <summary>
        /// Indicates the RSA algorithm using SHA-256.
        /// </summary>
        [XurrentEnum("rs256")]
        RS256,

        /// <summary>
        /// Indicates the RSA algorithm using SHA-384.
        /// </summary>
        [XurrentEnum("rs384")]
        RS384,

        /// <summary>
        /// Indicates the RSA algorithm using SHA-512.
        /// </summary>
        [XurrentEnum("rs512")]
        RS512
    }
}
