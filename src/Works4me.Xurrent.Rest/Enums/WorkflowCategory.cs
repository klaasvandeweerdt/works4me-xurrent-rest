using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various workflow categories.
    /// </summary>
    public enum WorkflowCategory
    {
        /// <summary>
        /// Indicates that the workflow category is standard.
        /// </summary>
        [XurrentEnum("standard")]
        Standard,

        /// <summary>
        /// Indicates that the workflow category is non-standard.
        /// </summary>
        [XurrentEnum("non_standard")]
        NonStandard,

        /// <summary>
        /// Indicates that the workflow category is emergency.
        /// </summary>
        [XurrentEnum("emergency")]
        Emergency,

        /// <summary>
        /// Indicates that the workflow category is order.
        /// </summary>
        [XurrentEnum("order")]
        Order
    }
}
