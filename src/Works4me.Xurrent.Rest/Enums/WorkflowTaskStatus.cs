using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various workflow task statuses.
    /// </summary>
    public enum WorkflowTaskStatus
    {
        /// <summary>
        /// Indicates that the workflow task status is registered.
        /// </summary>
        [XurrentEnum("registered")]
        Registered,

        /// <summary>
        /// Indicates that the workflow task status is declined.
        /// </summary>
        [XurrentEnum("declined")]
        Declined,

        /// <summary>
        /// Indicates that the workflow task status is assigned.
        /// </summary>
        [XurrentEnum("assigned")]
        Assigned,

        /// <summary>
        /// Indicates that the workflow task status is accepted.
        /// </summary>
        [XurrentEnum("accepted")]
        Accepted,

        /// <summary>
        /// Indicates that the workflow task status is in progress.
        /// </summary>
        [XurrentEnum("in_progress")]
        InProgress,

        /// <summary>
        /// Indicates that the workflow task status is waiting for.
        /// </summary>
        [XurrentEnum("waiting_for")]
        WaitingFor,

        /// <summary>
        /// Indicates that the workflow task status is waiting for customer.
        /// </summary>
        [XurrentEnum("waiting_for_customer")]
        WaitingForCustomer,

        /// <summary>
        /// Indicates that the workflow task status is request pending.
        /// </summary>
        [XurrentEnum("request_pending")]
        RequestPending,

        /// <summary>
        /// Indicates that the workflow task status is failed.
        /// </summary>
        [XurrentEnum("failed")]
        Failed,

        /// <summary>
        /// Indicates that the workflow task status is rejected.
        /// </summary>
        [XurrentEnum("rejected")]
        Rejected,

        /// <summary>
        /// Indicates that the workflow task status is completed.
        /// </summary>
        [XurrentEnum("completed")]
        Completed,

        /// <summary>
        /// Indicates that the workflow task status is approved.
        /// </summary>
        [XurrentEnum("approved")]
        Approved,

        /// <summary>
        /// Indicates that the workflow task status is canceled.
        /// </summary>
        [XurrentEnum("canceled")]
        Canceled
    }
}
