using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various time allocation description categories.
    /// </summary>
    public enum TimeAllocationDescriptionCategory
    {
        /// <summary>
        /// Indicates that the time allocation description is hidden.
        /// </summary>
        [XurrentEnum("hidden")]
        Hidden,

        /// <summary>
        /// Indicates that the time allocation description is optional.
        /// </summary>
        [XurrentEnum("optional")]
        Optional,

        /// <summary>
        /// Indicates that the time allocation description is required.
        /// </summary>
        [XurrentEnum("required")]
        Required
    }
}
