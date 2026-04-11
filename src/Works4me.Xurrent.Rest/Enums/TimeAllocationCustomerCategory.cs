using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various time allocation customer categories.
    /// </summary>
    public enum TimeAllocationCustomerCategory
    {
        /// <summary>
        /// Indicates that no customer category is applicable.
        /// </summary>
        [XurrentEnum("none")]
        None,

        /// <summary>
        /// Indicates that a selected customer category is applicable.
        /// </summary>
        [XurrentEnum("selected")]
        Selected,

        /// <summary>
        /// Indicates that any customer category is applicable.
        /// </summary>
        [XurrentEnum("any")]
        Any
    }
}
