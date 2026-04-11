using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various service offering statuses.
    /// </summary>
    public enum ServiceOfferingStatus
    {
        /// <summary>
        /// Indicates a service offering that is planned.
        /// </summary>
        [XurrentEnum("planned")]
        Planned,

        /// <summary>
        /// Indicates a service offering that is unpublished.
        /// </summary>
        [XurrentEnum("unpublished")]
        Unpublished,

        /// <summary>
        /// Indicates a service offering that is available.
        /// </summary>
        [XurrentEnum("available")]
        Available,

        /// <summary>
        /// Indicates a service offering that is temporarily unavailable.
        /// </summary>
        [XurrentEnum("temporarily_unavailable")]
        TemporarilyUnavailable,

        /// <summary>
        /// Indicates a service offering that has been discontinued.
        /// </summary>
        [XurrentEnum("discontinued")]
        Discontinued
    }
}
