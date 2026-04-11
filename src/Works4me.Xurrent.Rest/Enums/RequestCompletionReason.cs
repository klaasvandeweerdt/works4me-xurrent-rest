using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various request completion reasons.
    /// </summary>
    public enum RequestCompletionReason
    {
        /// <summary>
        /// Indicates that the request was completed because it was solved.
        /// </summary>
        [XurrentEnum("solved")]
        Solved,

        /// <summary>
        /// Indicates that the request was completed because a workaround was applied.
        /// </summary>
        [XurrentEnum("workaround")]
        Workaround,

        /// <summary>
        /// Indicates that the request was completed because the issue can no longer be found.
        /// </summary>
        [XurrentEnum("gone")]
        Gone,

        /// <summary>
        /// Indicates that the request was completed because it is a duplicate.
        /// </summary>
        [XurrentEnum("duplicate")]
        Duplicate,

        /// <summary>
        /// Indicates that the request was completed because it was withdrawn.
        /// </summary>
        [XurrentEnum("withdrawn")]
        Withdrawn,

        /// <summary>
        /// Indicates that the request was completed because no reply was received.
        /// </summary>
        [XurrentEnum("no_reply")]
        NoReply,

        /// <summary>
        /// Indicates that the request was completed because it was rejected.
        /// </summary>
        [XurrentEnum("rejected")]
        Rejected,

        /// <summary>
        /// Indicates that the request was completed due to a conflict.
        /// </summary>
        [XurrentEnum("conflict")]
        Conflict,

        /// <summary>
        /// Indicates that the request was completed because it was declined.
        /// </summary>
        [XurrentEnum("declined")]
        Declined,

        /// <summary>
        /// Indicates that the request was completed because it is unsolvable.
        /// </summary>
        [XurrentEnum("unsolvable")]
        Unsolvable
    }
}
