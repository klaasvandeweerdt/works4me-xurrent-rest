using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various feedback satisfaction values.
    /// </summary>
    public enum FeedbackSatisfaction
    {
        /// <summary>
        /// Indicates that the feedback expresses dissatisfaction.
        /// </summary>
        [XurrentEnum("dissatisfied")]
        Dissatisfied,

        /// <summary>
        /// Indicates that the feedback expresses satisfaction.
        /// </summary>
        [XurrentEnum("satisfied")]
        Satisfied
    }
}
