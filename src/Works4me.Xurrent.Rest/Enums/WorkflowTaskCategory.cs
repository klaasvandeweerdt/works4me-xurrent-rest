using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various workflow task categories.
    /// </summary>
    public enum WorkflowTaskCategory
    {
        /// <summary>
        /// Indicates that the workflow task category is risk and impact.
        /// </summary>
        [XurrentEnum("risk_and_impact")]
        RiskAndImpact,

        /// <summary>
        /// Indicates that the workflow task category is approval.
        /// </summary>
        [XurrentEnum("approval")]
        Approval,

        /// <summary>
        /// Indicates that the workflow task category is implementation.
        /// </summary>
        [XurrentEnum("implementation")]
        Implementation,

        /// <summary>
        /// Indicates that the workflow task category is fulfillment placeholder.
        /// </summary>
        [XurrentEnum("fulfillment_placeholder")]
        FulfillmentPlaceholder,

        /// <summary>
        /// Indicates that the workflow task category is automation.
        /// </summary>
        [XurrentEnum("automation")]
        Automation
    }
}
