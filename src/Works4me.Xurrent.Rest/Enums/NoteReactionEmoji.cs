using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various note reactions emoji.
    /// </summary>
    public enum NoteReactionEmoji
    {
        /// <summary>
        /// Indicates that the reaction expresses confusion.
        /// </summary>
        [XurrentEnum("😕")]
        ConfusedFace,

        /// <summary>
        /// Indicates that the reaction expresses happiness.
        /// </summary>
        [XurrentEnum("😀")]
        GrinningFace,

        /// <summary>
        /// Indicates that the reaction expresses celebration.
        /// </summary>
        [XurrentEnum("🎉")]
        PartyPopper,

        /// <summary>
        /// Indicates that the reaction expresses appreciation.
        /// </summary>
        [XurrentEnum("❤️")]
        RedHeart,

        /// <summary>
        /// Indicates that the reaction expresses disapproval.
        /// </summary>
        [XurrentEnum("👎")]
        ThumbsDown,

        /// <summary>
        /// Indicates that the reaction expresses approval.
        /// </summary>
        [XurrentEnum("👍")]
        ThumbsUp
    }
}
