using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various project completion reasons.
    /// </summary>
    public enum ProjectCompletionReason
    {
        /// <summary>
        /// Indicates that the project was withdrawn.
        /// </summary>
        [XurrentEnum("withdrawn")]
        Withdrawn,

        /// <summary>
        /// Indicates that the project was rejected.
        /// </summary>
        [XurrentEnum("rejected")]
        Rejected,

        /// <summary>
        /// Indicates that the project was abandoned.
        /// </summary>
        [XurrentEnum("abandoned")]
        Abandoned,

        /// <summary>
        /// Indicates that the project was partially completed.
        /// </summary>
        [XurrentEnum("partial")]
        Partial,

        /// <summary>
        /// Indicates that the project was completed.
        /// </summary>
        [XurrentEnum("complete")]
        Complete
    }
}
