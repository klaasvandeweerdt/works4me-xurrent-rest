using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various request statuses.
    /// </summary>
    public enum RequestStatus
    {
        /// <summary>
        /// Indicates that the request status is declined.
        /// </summary>
        [XurrentEnum("declined")]
        Declined,

        /// <summary>
        /// Indicates that the request status is on backlog.
        /// </summary>
        [XurrentEnum("on_backlog")]
        OnBacklog,

        /// <summary>
        /// Indicates that the request status is assigned.
        /// </summary>
        [XurrentEnum("assigned")]
        Assigned,

        /// <summary>
        /// Indicates that the request status is accepted.
        /// </summary>
        [XurrentEnum("accepted")]
        Accepted,

        /// <summary>
        /// Indicates that the request status is in progress.
        /// </summary>
        [XurrentEnum("in_progress")]
        InProgress,

        /// <summary>
        /// Indicates that the request status is waiting for.
        /// </summary>
        [XurrentEnum("waiting_for")]
        WaitingFor,

        /// <summary>
        /// Indicates that the request status is waiting for customer.
        /// </summary>
        [XurrentEnum("waiting_for_customer")]
        WaitingForCustomer,

        /// <summary>
        /// Indicates that the request status is reservation pending.
        /// </summary>
        [XurrentEnum("reservation_pending")]
        ReservationPending,

        /// <summary>
        /// Indicates that the request status is workflow pending.
        /// </summary>
        [XurrentEnum("workflow_pending")]
        WorkflowPending,

        /// <summary>
        /// Indicates that the request status is project pending.
        /// </summary>
        [XurrentEnum("project_pending")]
        ProjectPending,

        /// <summary>
        /// Indicates that the request status is completed.
        /// </summary>
        [XurrentEnum("completed")]
        Completed
    }
}
