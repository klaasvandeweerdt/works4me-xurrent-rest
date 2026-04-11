using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various time allocation service categories.
    /// </summary>
    public enum TimeAllocationServiceCategory
    {
        /// <summary>
        /// Indicates that no service category is applicable.
        /// </summary>
        [XurrentEnum("none")]
        None,

        /// <summary>
        /// Indicates that a selected service category is applicable.
        /// </summary>
        [XurrentEnum("selected")]
        Selected,

        /// <summary>
        /// Indicates that any service category is applicable.
        /// </summary>
        [XurrentEnum("any")]
        Any
    }
}
