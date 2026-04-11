using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various agreement statuses.
    /// </summary>
    public enum AgreementStatus
    {
        /// <summary>
        /// Indicates that the agreement is being prepared.
        /// </summary>
        [XurrentEnum("being_prepared")]
        BeingPrepared,

        /// <summary>
        /// Indicates that the agreement is scheduled for activation.
        /// </summary>
        [XurrentEnum("scheduled_for_activation")]
        ScheduledForActivation,

        /// <summary>
        /// Indicates that the agreement is active.
        /// </summary>
        [XurrentEnum("active")]
        Active,

        /// <summary>
        /// Indicates that the agreement has expired.
        /// </summary>
        [XurrentEnum("expired")]
        Expired
    }
}
