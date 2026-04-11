using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various account plans.
    /// </summary>
    public enum AccountPlan
    {
        /// <summary>
        /// Indicates the basic account plan.
        /// </summary>
        [XurrentEnum("basic")]
        Basic,

        /// <summary>
        /// Indicates the premium account plan.
        /// </summary>
        [XurrentEnum("premium")]
        Premium,

        /// <summary>
        /// Indicates the standard account plan.
        /// </summary>
        [XurrentEnum("standard")]
        Standard
    }
}
