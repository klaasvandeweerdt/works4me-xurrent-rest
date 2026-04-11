using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various address labels.
    /// </summary>
    public enum AddressLabel
    {
        /// <summary>
        /// Specifies the home address label.
        /// </summary>
        [XurrentEnum("home")]
        Home,

        /// <summary>
        /// Specifies the street address label.
        /// </summary>
        [XurrentEnum("street")]
        Street,

        /// <summary>
        /// Specifies the mailing address label.
        /// </summary>
        [XurrentEnum("mailing")]
        Mailing,

        /// <summary>
        /// Specifies the billing address label.
        /// </summary>
        [XurrentEnum("billing")]
        Billing,

        /// <summary>
        /// Specifies the shipping address label.
        /// </summary>
        [XurrentEnum("shipping")]
        Shipping
    }
}
