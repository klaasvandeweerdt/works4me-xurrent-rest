using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various risk statuses.
    /// </summary>
    public enum RiskStatus
    {
        /// <summary>
        /// Indicates that the risk is anticipated.
        /// </summary>
        [XurrentEnum("anticipated")]
        Anticipated,

        /// <summary>
        /// Indicates that the risk has materialized.
        /// </summary>
        [XurrentEnum("materialized")]
        Materialized,

        /// <summary>
        /// Indicates that the risk is closed.
        /// </summary>
        [XurrentEnum("closed")]
        Closed
    }
}
