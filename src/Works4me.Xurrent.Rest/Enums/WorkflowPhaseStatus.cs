using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various workflow phase statuses.
    /// </summary>
    public enum WorkflowPhaseStatus
    {
        /// <summary>
        /// Indicates that the workflow phase status is registered.
        /// </summary>
        [XurrentEnum("registered")]
        Registered,

        /// <summary>
        /// Indicates that the workflow phase status is in progress.
        /// </summary>
        [XurrentEnum("in_progress")]
        InProgress,

        /// <summary>
        /// Indicates that the workflow phase status is completed.
        /// </summary>
        [XurrentEnum("completed")]
        Completed
    }
}
