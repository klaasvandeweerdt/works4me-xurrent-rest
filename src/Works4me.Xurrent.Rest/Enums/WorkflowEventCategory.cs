using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various workflow event categories.
    /// </summary>
    public enum WorkflowEventCategory
    {
        /// <summary>
        /// Indicates that the workflow event category is registered.
        /// </summary>
        [XurrentEnum("registered")]
        Registered,

        /// <summary>
        /// Indicates that the workflow event category is completed.
        /// </summary>
        [XurrentEnum("completed")]
        Completed,

        /// <summary>
        /// Indicates that the workflow event category is reopened.
        /// </summary>
        [XurrentEnum("reopened")]
        Reopened,

        /// <summary>
        /// Indicates that the workflow event category is halted.
        /// </summary>
        [XurrentEnum("halted")]
        Halted
    }
}
