using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various project task statuses.
    /// </summary>
    public enum ProjectTaskStatus
    {
        /// <summary>
        /// Indicates that the project task status is registered.
        /// </summary>
        [XurrentEnum("registered")]
        Registered,

        /// <summary>
        /// Indicates that the project task status is assigned.
        /// </summary>
        [XurrentEnum("assigned")]
        Assigned,

        /// <summary>
        /// Indicates that the project task status is accepted.
        /// </summary>
        [XurrentEnum("accepted")]
        Accepted,

        /// <summary>
        /// Indicates that the project task status is in progress.
        /// </summary>
        [XurrentEnum("in_progress")]
        InProgress,

        /// <summary>
        /// Indicates that the project task status is waiting for.
        /// </summary>
        [XurrentEnum("waiting_for")]
        WaitingFor,

        /// <summary>
        /// Indicates that the project task status is failed.
        /// </summary>
        [XurrentEnum("failed")]
        Failed,

        /// <summary>
        /// Indicates that the project task status is rejected.
        /// </summary>
        [XurrentEnum("rejected")]
        Rejected,

        /// <summary>
        /// Indicates that the project task status is completed.
        /// </summary>
        [XurrentEnum("completed")]
        Completed,

        /// <summary>
        /// Indicates that the project task status is approved.
        /// </summary>
        [XurrentEnum("approved")]
        Approved,

        /// <summary>
        /// Indicates that the project task status is canceled.
        /// </summary>
        [XurrentEnum("canceled")]
        Canceled
    }
}
