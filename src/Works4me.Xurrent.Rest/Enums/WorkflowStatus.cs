using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various workflow statuses.
    /// </summary>
    public enum WorkflowStatus
    {
        /// <summary>
        /// Indicates that the workflow status is being created.
        /// </summary>
        [XurrentEnum("being_created")]
        BeingCreated,

        /// <summary>
        /// Indicates that the workflow status is registered.
        /// </summary>
        [XurrentEnum("registered")]
        Registered,

        /// <summary>
        /// Indicates that the workflow status is in progress.
        /// </summary>
        [XurrentEnum("in_progress")]
        InProgress,

        /// <summary>
        /// Indicates that the workflow status is progress halted.
        /// </summary>
        [XurrentEnum("progress_halted")]
        ProgressHalted,

        /// <summary>
        /// Indicates that the workflow status is completed.
        /// </summary>
        [XurrentEnum("completed")]
        Completed
    }
}
