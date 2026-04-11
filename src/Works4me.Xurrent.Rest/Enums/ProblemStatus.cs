using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various problem statuses.
    /// </summary>
    public enum ProblemStatus
    {
        /// <summary>
        /// Indicates that the problem has been declined.
        /// </summary>
        [XurrentEnum("declined")]
        Declined,

        /// <summary>
        /// Indicates that the problem is on the backlog.
        /// </summary>
        [XurrentEnum("on_backlog")]
        OnBacklog,

        /// <summary>
        /// Indicates that the problem has been assigned.
        /// </summary>
        [XurrentEnum("assigned")]
        Assigned,

        /// <summary>
        /// Indicates that the problem has been accepted.
        /// </summary>
        [XurrentEnum("accepted")]
        Accepted,

        /// <summary>
        /// Indicates that work on the problem is in progress.
        /// </summary>
        [XurrentEnum("in_progress")]
        InProgress,

        /// <summary>
        /// Indicates that the problem is waiting for an external dependency.
        /// </summary>
        [XurrentEnum("waiting_for")]
        WaitingFor,

        /// <summary>
        /// Indicates that the problem has been analyzed.
        /// </summary>
        [XurrentEnum("analyzed")]
        Analyzed,

        /// <summary>
        /// Indicates that a change has been requested for the problem.
        /// </summary>
        [XurrentEnum("change_requested")]
        ChangeRequested,

        /// <summary>
        /// Indicates that the problem is pending a workflow.
        /// </summary>
        [XurrentEnum("workflow_pending")]
        WorkflowPending,

        /// <summary>
        /// Indicates that the problem is pending a project.
        /// </summary>
        [XurrentEnum("project_pending")]
        ProjectPending,

        /// <summary>
        /// Indicates that progress on the problem has been halted.
        /// </summary>
        [XurrentEnum("progress_halted")]
        ProgressHalted,

        /// <summary>
        /// Indicates that the problem has been solved.
        /// </summary>
        [XurrentEnum("solved")]
        Solved
    }
}
