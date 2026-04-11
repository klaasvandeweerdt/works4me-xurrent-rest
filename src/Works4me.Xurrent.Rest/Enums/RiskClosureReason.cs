using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various risk closure reasons.
    /// </summary>
    public enum RiskClosureReason
    {
        /// <summary>
        /// Indicates that the risk is completely eliminated.
        /// </summary>
        [XurrentEnum("eliminated")]
        Eliminated,

        /// <summary>
        /// Indicates that the risk level is accepted.
        /// </summary>
        [XurrentEnum("accepted")]
        Accepted,

        /// <summary>
        /// Indicates that the risk is reduced to an acceptable level.
        /// </summary>
        [XurrentEnum("mitigated")]
        Mitigated,

        /// <summary>
        /// Indicates that the risk is transferred to another organization.
        /// </summary>
        [XurrentEnum("transferred")]
        Transferred,

        /// <summary>
        /// Indicates that the assessment found no risk.
        /// </summary>
        [XurrentEnum("no_risk")]
        NoRisk
    }
}
