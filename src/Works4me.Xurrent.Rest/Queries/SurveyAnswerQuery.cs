using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="SurveyAnswer"/> records.
    /// </summary>
    public sealed class SurveyAnswerQuery
        : Query<SurveyAnswerQuery, SurveyAnswer.PredefinedFilter, SurveyAnswer.Field, SurveyAnswer.FilterField, SurveyAnswer.OrderField>
    {
    }
}
