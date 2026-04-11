using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various reservation statuses.
    /// </summary>
    public enum ReservationStatus
    {
        /// <summary>
        /// Indicates that the reservation is a prototype.
        /// </summary>
        [XurrentEnum("prototype")]
        Prototype,

        /// <summary>
        /// Indicates that the reservation is provisional.
        /// </summary>
        [XurrentEnum("provisional")]
        Provisional,

        /// <summary>
        /// Indicates that the reservation is pending.
        /// </summary>
        [XurrentEnum("pending")]
        Pending,

        /// <summary>
        /// Indicates that the reservation is conflicting.
        /// </summary>
        [XurrentEnum("conflicting")]
        Conflicting,

        /// <summary>
        /// Indicates that the reservation is confirmed.
        /// </summary>
        [XurrentEnum("confirmed")]
        Confirmed,

        /// <summary>
        /// Indicates that the reservation is being prepared.
        /// </summary>
        [XurrentEnum("being_prepared")]
        BeingPrepared,

        /// <summary>
        /// Indicates that the reservation is active.
        /// </summary>
        [XurrentEnum("active")]
        Active,

        /// <summary>
        /// Indicates that the reservation is canceled.
        /// </summary>
        [XurrentEnum("canceled")]
        Canceled,

        /// <summary>
        /// Indicates that the reservation has ended.
        /// </summary>
        [XurrentEnum("ended")]
        Ended
    }
}
