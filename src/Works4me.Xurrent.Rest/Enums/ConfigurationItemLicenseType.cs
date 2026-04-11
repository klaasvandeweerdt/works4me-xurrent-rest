using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various configuration item license types.
    /// </summary>
    public enum ConfigurationItemLicenseType
    {
        /// <summary>
        /// Specifies the concurrent user license type.
        /// </summary>
        [XurrentEnum("concurrent_user_license")]
        ConcurrentUserLicense,

        /// <summary>
        /// Specifies the CPU license type.
        /// </summary>
        [XurrentEnum("cpu_license")]
        CpuLicense,

        /// <summary>
        /// Specifies the installed user license type.
        /// </summary>
        [XurrentEnum("installed_user_license")]
        InstalledUserLicense,

        /// <summary>
        /// Specifies the named user license type.
        /// </summary>
        [XurrentEnum("named_user_license")]
        NamedUserLicense,

        /// <summary>
        /// Specifies the unlimited user license type.
        /// </summary>
        [XurrentEnum("unlimited_user_license")]
        UnlimitedUserLicense,

        /// <summary>
        /// Specifies an unspecified or other license type.
        /// </summary>
        [XurrentEnum("other_type_of_license")]
        OtherTypeOfLicense
    }
}
