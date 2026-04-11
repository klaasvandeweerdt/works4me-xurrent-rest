using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various parent service instance impact relations.
    /// </summary>
    public enum ParentServiceInstanceImpactRelation
    {
        /// <summary>
        /// Indicates that the impact is down if the service instance of the service level agreement is down.
        /// </summary>
        [XurrentEnum("down")]
        Down,

        /// <summary>
        /// Indicates that the impact is degraded if the service instance of the service level agreement is down or degraded.
        /// </summary>
        [XurrentEnum("degraded")]
        Degraded
    }
}
