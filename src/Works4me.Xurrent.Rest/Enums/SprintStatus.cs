using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various sprint statuses.
    /// </summary>
    public enum SprintStatus
    {
        /// <summary>
        /// Indicates that the sprint is registered.
        /// </summary>
        [XurrentEnum("registered")]
        Registered,

        /// <summary>
        /// Indicates that the sprint is active.
        /// </summary>
        [XurrentEnum("active")]
        Active,

        /// <summary>
        /// Indicates that the sprint is completed.
        /// </summary>
        [XurrentEnum("completed")]
        Completed
    }
}
