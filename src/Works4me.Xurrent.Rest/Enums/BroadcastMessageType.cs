using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various broadcast message types.
    /// </summary>
    public enum BroadcastMessageType
    {
        /// <summary>
        /// Indicates that the broadcast message reports a service outage.
        /// </summary>
        [XurrentEnum("outage")]
        Outage,

        /// <summary>
        /// Indicates that the broadcast message communicates availability.
        /// </summary>
        [XurrentEnum("available")]
        Available,

        /// <summary>
        /// Indicates that the broadcast message conveys a warning.
        /// </summary>
        [XurrentEnum("warning")]
        Warning,

        /// <summary>
        /// Indicates that the broadcast message provides informational content.
        /// </summary>
        [XurrentEnum("info")]
        Info,

        /// <summary>
        /// Indicates that the broadcast message is delivered by email.
        /// </summary>
        [XurrentEnum("email")]
        Email
    }
}
