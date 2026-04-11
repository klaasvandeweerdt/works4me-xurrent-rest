using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various project justifications.
    /// </summary>
    public enum ProjectJustification
    {
        /// <summary>
        /// Indicates that the project justification is compliance.
        /// </summary>
        [XurrentEnum("compliance")]
        Compliance,

        /// <summary>
        /// Indicates that the project justification is correction.
        /// </summary>
        [XurrentEnum("correction")]
        Correction,

        /// <summary>
        /// Indicates that the project justification is expansion.
        /// </summary>
        [XurrentEnum("expansion")]
        Expansion,

        /// <summary>
        /// Indicates that the project justification is improvement.
        /// </summary>
        [XurrentEnum("improvement")]
        Improvement,

        /// <summary>
        /// Indicates that the project justification is maintenance.
        /// </summary>
        [XurrentEnum("maintenance")]
        Maintenance,

        /// <summary>
        /// Indicates that the project justification is move.
        /// </summary>
        [XurrentEnum("move")]
        Move,

        /// <summary>
        /// Indicates that the project justification is removal.
        /// </summary>
        [XurrentEnum("removal")]
        Removal,

        /// <summary>
        /// Indicates that the project justification is replacement.
        /// </summary>
        [XurrentEnum("replacement")]
        Replacement
    }
}
