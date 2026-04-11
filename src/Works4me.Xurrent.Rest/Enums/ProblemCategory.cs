using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various problem categories.
    /// </summary>
    public enum ProblemCategory
    {
        /// <summary>
        /// Indicates that the problem is reactive.
        /// </summary>
        [XurrentEnum("reactive")]
        Reactive,

        /// <summary>
        /// Indicates that the problem is proactive.
        /// </summary>
        [XurrentEnum("proactive")]
        Proactive
    }
}
