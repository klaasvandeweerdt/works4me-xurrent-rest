using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various request impact levels.
    /// </summary>
    public enum RequestImpact
    {
        /// <summary>
        /// Indicates a low impact where the service is degraded for one user.
        /// </summary>
        [XurrentEnum("low")]
        Low,

        /// <summary>
        /// Indicates a medium impact where the service is down for one user.
        /// </summary>
        [XurrentEnum("medium")]
        Medium,

        /// <summary>
        /// Indicates a high impact where the service is degraded for several users.
        /// </summary>
        [XurrentEnum("high")]
        High,

        /// <summary>
        /// Indicates a top impact where the service is down for several users.
        /// </summary>
        [XurrentEnum("top")]
        Top
    }
}
