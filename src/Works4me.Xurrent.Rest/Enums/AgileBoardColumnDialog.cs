using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various agile board column dialog types.
    /// </summary>
    public enum AgileBoardColumnDialog
    {
        /// <summary>
        /// Indicates that no dialog is used.
        /// </summary>
        [XurrentEnum("none")]
        None,

        /// <summary>
        /// Indicates that the minimal dialog is used.
        /// </summary>
        [XurrentEnum("minimal")]
        Minimal,

        /// <summary>
        /// Indicates that the full dialog is used.
        /// </summary>
        [XurrentEnum("full")]
        Full
    }
}
