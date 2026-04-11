using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various dashboard visibility values.
    /// </summary>
    public enum DashboardVisibility
    {
        /// <summary>
        /// Indicates that the dashboard is private and not shared.
        /// </summary>
        [XurrentEnum("private")]
        Private,

        /// <summary>
        /// Indicates that the dashboard is shared within an account.
        /// </summary>
        [XurrentEnum("shared")]
        Shared,

        /// <summary>
        /// Indicates that the dashboard is shared with members of teams.
        /// </summary>
        [XurrentEnum("members_of_teams")]
        MembersOfTeams,

        /// <summary>
        /// Indicates that the dashboard is shared with members of skill pools.
        /// </summary>
        [XurrentEnum("members_of_skill_pools")]
        MembersOfSkillPools
    }
}
