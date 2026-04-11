using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various configuration item relation types.
    /// </summary>
    public enum ConfigurationItemRelationType
    {
        /// <summary>
        /// Represents a parent relationship.
        /// </summary>
        [XurrentEnum("parent")]
        Parent,

        /// <summary>
        /// Represents a child relationship.
        /// </summary>
        [XurrentEnum("child")]
        Child,

        /// <summary>
        /// Represents a network connection relationship.
        /// </summary>
        [XurrentEnum("network_connection")]
        NetworkConnection,

        /// <summary>
        /// Represents a redundancy relationship.
        /// </summary>
        [XurrentEnum("redundancy")]
        Redundancy,

        /// <summary>
        /// Represents a continuity relationship.
        /// </summary>
        [XurrentEnum("continuity")]
        Continuity,

        /// <summary>
        /// Represents a software dependency relationship.
        /// </summary>
        [XurrentEnum("software_dependency")]
        SoftwareDependency
    }
}
