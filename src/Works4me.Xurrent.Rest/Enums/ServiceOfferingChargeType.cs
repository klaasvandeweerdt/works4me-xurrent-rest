using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various service offering charge types.
    /// </summary>
    public enum ServiceOfferingChargeType
    {
        /// <summary>
        /// Indicates a fixed price charge type.
        /// </summary>
        [XurrentEnum("fixed_price")]
        FixedPrice,

        /// <summary>
        /// Indicates a time and material charge type.
        /// </summary>
        [XurrentEnum("time_material")]
        TimeMaterial
    }
}
