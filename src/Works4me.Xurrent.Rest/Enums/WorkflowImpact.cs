using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various impact values.
    /// </summary>
    public enum WorkflowImpact
    {
        /// <summary>
        /// Indicates that the workflow impact is high.
        /// </summary>
        [XurrentEnum("high")]
        High,

        /// <summary>
        /// Indicates that the workflow impact is low.
        /// </summary>
        [XurrentEnum("low")]
        Low,

        /// <summary>
        /// Indicates that the workflow impact is medium.
        /// </summary>
        [XurrentEnum("medium")]
        Medium,

        /// <summary>
        /// Indicates that the workflow impact is none.
        /// </summary>
        [XurrentEnum("none")]
        None,

        /// <summary>
        /// Indicates that the workflow impact is top.
        /// </summary>
        [XurrentEnum("top")]
        Top
    }
}
