using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various broadcast visibility values.
    /// </summary>
    public enum BroadcastVisibility
    {
        /// <summary>
        /// Indicates that the broadcast is visible to all people registered in the account.
        /// </summary>
        [XurrentEnum("all_of_account")]
        AllOfAccount,

        /// <summary>
        /// Indicates that the broadcast is visible to account specialists.
        /// </summary>
        [XurrentEnum("account_specialists")]
        AccountSpecialists,

        /// <summary>
        /// Indicates that the broadcast is visible to members of the specified teams.
        /// </summary>
        [XurrentEnum("members_of_teams")]
        MembersOfTeams,

        /// <summary>
        /// Indicates that the broadcast is visible to people covered for any service instance.
        /// </summary>
        [XurrentEnum("covered_for_any")]
        CoveredForAny,

        /// <summary>
        /// Indicates that the broadcast is visible to people covered for the specified service instances.
        /// </summary>
        [XurrentEnum("covered_for")]
        CoveredFor,

        /// <summary>
        /// Indicates that the broadcast is visible to specialists handling requests from the specified customers.
        /// </summary>
        [XurrentEnum("customers")]
        Customers,

        /// <summary>
        /// Indicates that the broadcast is visible to people of the specified organizations and their descendant organizations.
        /// </summary>
        [XurrentEnum("organizations_and_descendants")]
        OrganizationsAndDescendants,

        /// <summary>
        /// Indicates that the broadcast is visible to people of the specified organizations.
        /// </summary>
        [XurrentEnum("organizations")]
        Organizations,

        /// <summary>
        /// Indicates that the broadcast is visible to people of the specified sites.
        /// </summary>
        [XurrentEnum("sites")]
        Sites,

        /// <summary>
        /// Indicates that the broadcast is visible to members of the specified skill pools.
        /// </summary>
        [XurrentEnum("members_of_skill_pools")]
        MembersOfSkillPools,

        /// <summary>
        /// Indicates that the broadcast is visible to customer representatives of the specified service level agreements.
        /// </summary>
        [XurrentEnum("customer_representatives_of_slas")]
        CustomerRepresentativesOfSlas
    }
}
