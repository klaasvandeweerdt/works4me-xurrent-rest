using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various configuration item types.
    /// </summary>
    public enum ConfigurationItemType
    {
        /// <summary>
        /// Represents a software version configuration item type.
        /// </summary>
        [XurrentEnum("software_version")]
        SoftwareVersion,

        /// <summary>
        /// Represents a software license certificate configuration item type.
        /// </summary>
        [XurrentEnum("software_license_certificate")]
        SoftwareLicenseCertificate,

        /// <summary>
        /// Represents a hardware configuration item type.
        /// </summary>
        [XurrentEnum("hardware")]
        Hardware
    }
}
