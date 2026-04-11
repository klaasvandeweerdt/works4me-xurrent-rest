using Works4me.Xurrent.Rest.Attributes;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents the various survey question types.
    /// </summary>
    public enum SurveyQuestionType
    {
        /// <summary>
        /// Indicates that the question uses a star rating.
        /// </summary>
        [XurrentEnum("star_rating")]
        StarRating,

        /// <summary>
        /// Indicates that the question uses free text.
        /// </summary>
        [XurrentEnum("text")]
        Text
    }
}
