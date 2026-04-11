using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various project task categories.
    /// </summary>
    public enum ProjectTaskCategory
    {
        /// <summary>
        /// Indicates that the project task category is activity.
        /// </summary>
        [XurrentEnum("activity")]
        Activity,

        /// <summary>
        /// Indicates that the project task category is approval.
        /// </summary>
        [XurrentEnum("approval")]
        Approval,

        /// <summary>
        /// Indicates that the project task category is milestone.
        /// </summary>
        [XurrentEnum("milestone")]
        Milestone
    }
}
