using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various request major incident statuses.
    /// </summary>
    public enum RequestMajorIncidentStatus
    {
        /// <summary>
        /// Indicates that the major incident status is proposed.
        /// </summary>
        [XurrentEnum("proposed")]
        Proposed,

        /// <summary>
        /// Indicates that the major incident status is rejected.
        /// </summary>
        [XurrentEnum("rejected")]
        Rejected,

        /// <summary>
        /// Indicates that the major incident status is accepted.
        /// </summary>
        [XurrentEnum("accepted")]
        Accepted,

        /// <summary>
        /// Indicates that the major incident status is resolved.
        /// </summary>
        [XurrentEnum("resolved")]
        Resolved,

        /// <summary>
        /// Indicates that the major incident status is canceled.
        /// </summary>
        [XurrentEnum("canceled")]
        Canceled
    }
}
