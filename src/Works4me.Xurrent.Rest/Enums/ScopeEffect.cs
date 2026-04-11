using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various scope effects.
    /// </summary>
    public enum ScopeEffect
    {
        /// <summary>
        /// Indicates that the scope effect allows the action.
        /// </summary>
        [XurrentEnum("allow")]
        Allow,

        /// <summary>
        /// Indicates that the scope effect denies the action.
        /// </summary>
        [XurrentEnum("deny")]
        Deny
    }
}
