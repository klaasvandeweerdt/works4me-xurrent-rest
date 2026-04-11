using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various workflow completion reasons.
    /// </summary>
    public enum WorkflowCompletionReason
    {
        /// <summary>
        /// Indicates that the workflow was withdrawn.
        /// </summary>
        [XurrentEnum("withdrawn")]
        Withdrawn,

        /// <summary>
        /// Indicates that the workflow was rejected.
        /// </summary>
        [XurrentEnum("rejected")]
        Rejected,

        /// <summary>
        /// Indicates that the workflow was rolled back.
        /// </summary>
        [XurrentEnum("rolled_back")]
        RolledBack,

        /// <summary>
        /// Indicates that the workflow failed.
        /// </summary>
        [XurrentEnum("failed")]
        Failed,

        /// <summary>
        /// Indicates that the workflow was partially completed.
        /// </summary>
        [XurrentEnum("partial")]
        Partial,

        /// <summary>
        /// Indicates that the workflow caused service disruption.
        /// </summary>
        [XurrentEnum("disruptive")]
        Disruptive,

        /// <summary>
        /// Indicates that the workflow was completed.
        /// </summary>
        [XurrentEnum("complete")]
        Complete
    }
}
