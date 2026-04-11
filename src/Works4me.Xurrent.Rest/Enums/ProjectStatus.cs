using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various project Statuses.
    /// </summary>
    public enum ProjectStatus
    {
        /// <summary>
        /// Indicates that the project status is registered.
        /// </summary>
        [XurrentEnum("registered")]
        Registered,

        /// <summary>
        /// Indicates that the project status is in progress.
        /// </summary>
        [XurrentEnum("in_progress")]
        InProgress,

        /// <summary>
        /// Indicates that the project status is progress halted.
        /// </summary>
        [XurrentEnum("progress_halted")]
        ProgressHalted,

        /// <summary>
        /// Indicates that the project status is completed.
        /// </summary>
        [XurrentEnum("completed")]
        Completed
    }
}
