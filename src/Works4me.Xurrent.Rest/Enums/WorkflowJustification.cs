using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various workflow justifications.
    /// </summary>
    public enum WorkflowJustification
    {
        /// <summary>
        /// Indicates that the workflow justification is compliance.
        /// </summary>
        [XurrentEnum("compliance")]
        Compliance,

        /// <summary>
        /// Indicates that the workflow justification is correction.
        /// </summary>
        [XurrentEnum("correction")]
        Correction,

        /// <summary>
        /// Indicates that the workflow justification is expansion.
        /// </summary>
        [XurrentEnum("expansion")]
        Expansion,

        /// <summary>
        /// Indicates that the workflow justification is improvement.
        /// </summary>
        [XurrentEnum("improvement")]
        Improvement,

        /// <summary>
        /// Indicates that the workflow justification is maintenance.
        /// </summary>
        [XurrentEnum("maintenance")]
        Maintenance,

        /// <summary>
        /// Indicates that the workflow justification is move.
        /// </summary>
        [XurrentEnum("move")]
        Move,

        /// <summary>
        /// Indicates that the workflow justification is removal.
        /// </summary>
        [XurrentEnum("removal")]
        Removal,

        /// <summary>
        /// Indicates that the workflow justification is replacement.
        /// </summary>
        [XurrentEnum("replacement")]
        Replacement,

        /// <summary>
        /// Indicates that the workflow justification is purchase.
        /// </summary>
        [XurrentEnum("purchase")]
        Purchase
    }
}
