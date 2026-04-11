using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various service instance statuses.
    /// </summary>
    public enum ServiceInstanceStatus
    {
        /// <summary>
        /// Indicates that the service instance is being set up and is not yet available for use.
        /// </summary>
        [XurrentEnum("being_prepared")]
        BeingPrepared,

        /// <summary>
        /// Indicates that the service instance is fully set up and currently in active use.
        /// </summary>
        [XurrentEnum("in_production")]
        InProduction,

        /// <summary>
        /// Indicates that the service instance has been retired and is no longer active.
        /// </summary>
        [XurrentEnum("discontinued")]
        Discontinued
    }
}
