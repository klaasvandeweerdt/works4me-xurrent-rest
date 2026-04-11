using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various shop order line statuses.
    /// </summary>
    public enum ShopOrderLineStatus
    {
        /// <summary>
        /// Indicates that the shop order line is in the cart.
        /// </summary>
        [XurrentEnum("in_cart")]
        InCart,

        /// <summary>
        /// Indicates that the shop order line is pending workflow processing.
        /// </summary>
        [XurrentEnum("workflow_pending")]
        WorkflowPending,

        /// <summary>
        /// Indicates that the shop order line is pending fulfillment.
        /// </summary>
        [XurrentEnum("fulfillment_pending")]
        FulfillmentPending,

        /// <summary>
        /// Indicates that the shop order line is completed.
        /// </summary>
        [XurrentEnum("completed")]
        Completed,

        /// <summary>
        /// Indicates that the shop order line is canceled.
        /// </summary>
        [XurrentEnum("canceled")]
        Canceled
    }
}
