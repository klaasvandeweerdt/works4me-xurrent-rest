using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various agile board column action types.
    /// </summary>
    public enum AgileBoardColumnAction
    {
        /// <summary>
        /// Indicates that the column action performs no operation.
        /// </summary>
        [XurrentEnum("none")]
        None,

        /// <summary>
        /// Indicates that the column action assigns the item.
        /// </summary>
        [XurrentEnum("assign")]
        Assign,

        /// <summary>
        /// Indicates that the column action accepts the item.
        /// </summary>
        [XurrentEnum("accept")]
        Accept,

        /// <summary>
        /// Indicates that the column action starts the item.
        /// </summary>
        [XurrentEnum("start")]
        Start,

        /// <summary>
        /// Indicates that the column action completes the item.
        /// </summary>
        [XurrentEnum("complete")]
        Complete
    }
}
