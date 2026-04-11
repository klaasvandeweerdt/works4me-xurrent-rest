using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various product category rule sets.
    /// </summary>
    public enum ProductCategoryRuleSet
    {
        /// <summary>
        /// Indicates that the product category rule set applies to a physical asset.
        /// </summary>
        [XurrentEnum("physical_asset")]
        PhysicalAsset,

        /// <summary>
        /// Indicates that the product category rule set applies to a logical asset with financial data.
        /// </summary>
        [XurrentEnum("logical_asset_with_financial_data")]
        LogicalAssetWithFinancialData,

        /// <summary>
        /// Indicates that the product category rule set applies to a logical asset without financial data.
        /// </summary>
        [XurrentEnum("logical_asset_without_financial_data")]
        LogicalAssetWithoutFinancialData,

        /// <summary>
        /// Indicates that the product category rule set applies to a server.
        /// </summary>
        [XurrentEnum("server")]
        Server,

        /// <summary>
        /// Indicates that the product category rule set applies to software.
        /// </summary>
        [XurrentEnum("software")]
        Software,

        /// <summary>
        /// Indicates that the product category rule set applies to a software distribution package.
        /// </summary>
        [XurrentEnum("software_distribution_package")]
        SoftwareDistributionPackage,

        /// <summary>
        /// Indicates that the product category rule set applies to a license certificate.
        /// </summary>
        [XurrentEnum("license_certificate")]
        LicenseCertificate
    }
}
