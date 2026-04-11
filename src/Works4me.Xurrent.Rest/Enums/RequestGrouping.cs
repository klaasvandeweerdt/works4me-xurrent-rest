using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various request grouping values.
    /// </summary>
    public enum RequestGrouping
    {
        /// <summary>
        /// Indicates that no grouping is applied.
        /// </summary>
        [XurrentEnum("none")]
        None,

        /// <summary>
        /// Indicates that requests are grouped.
        /// </summary>
        [XurrentEnum("group")]
        Group,

        /// <summary>
        /// Indicates that the request is part of a group.
        /// </summary>
        [XurrentEnum("grouped")]
        Grouped
    }
}
