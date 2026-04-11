using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various configuration item staged change statuses.
    /// </summary>
    public enum CiStagedChangeStatus
    {
        /// <summary>
        /// Indicates that the staged change is pending review.
        /// </summary>
        [XurrentEnum("pending")]
        Pending,

        /// <summary>
        /// Indicates that the staged change has been approved.
        /// </summary>
        [XurrentEnum("approved")]
        Approved,

        /// <summary>
        /// Indicates that the staged change has been rejected.
        /// </summary>
        [XurrentEnum("rejected")]
        Rejected,

        /// <summary>
        /// Indicates that the staged change has been superseded.
        /// </summary>
        [XurrentEnum("superseded")]
        Superseded
    }
}
