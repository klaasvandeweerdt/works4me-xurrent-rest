using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various service level agreement coverage types.
    /// </summary>
    public enum SlaCoverage
    {
        /// <summary>
        /// Indicates that all people of the customer account are selected.
        /// </summary>
        [XurrentEnum("customer_account")]
        CustomerAccount,

        /// <summary>
        /// Indicates that people are selected from the specified organizations and their descendants.
        /// </summary>
        [XurrentEnum("organizations_and_descendants")]
        OrganizationsAndDescendants,

        /// <summary>
        /// Indicates that people are selected from the specified organizations.
        /// </summary>
        [XurrentEnum("organizations")]
        Organizations,

        /// <summary>
        /// Indicates that people are selected from the specified sites.
        /// </summary>
        [XurrentEnum("sites")]
        Sites,

        /// <summary>
        /// Indicates that people are selected from the specified organizations and sites.
        /// </summary>
        [XurrentEnum("organizations_and_sites")]
        OrganizationsAndSites,

        /// <summary>
        /// Indicates that people are selected explicitly.
        /// </summary>
        [XurrentEnum("people")]
        People,

        /// <summary>
        /// Indicates that people are selected based on configuration items of the service instance.
        /// </summary>
        [XurrentEnum("cis_of_service_instance")]
        CisOfServiceInstance,

        /// <summary>
        /// Indicates that people are selected from the specified coverage groups.
        /// </summary>
        [XurrentEnum("coverage_groups")]
        CoverageGroups,

        /// <summary>
        /// Indicates that members of the specified skill pools are selected.
        /// </summary>
        [XurrentEnum("skill_pools")]
        SkillPools,

        /// <summary>
        /// Indicates that members of support teams of the specified service instances are selected.
        /// </summary>
        [XurrentEnum("service_instances")]
        ServiceInstances
    }
}
