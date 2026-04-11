using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various affected service level accountability values.
    /// </summary>
    public enum AffectedSlaAccountability
    {
        /// <summary>
        /// Indicates that the provider is accountable.
        /// </summary>
        [XurrentEnum("provider")]
        Provider,

        /// <summary>
        /// Indicates that the supplier is accountable.
        /// </summary>
        [XurrentEnum("supplier")]
        Supplier,

        /// <summary>
        /// Indicates that the service level agreement is not affected.
        /// </summary>
        [XurrentEnum("sla_not_affected")]
        SlaNotAffected
    }
}
