using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="SurveyQuestion"/> records.
    /// </summary>
    public sealed class SurveyQuestionQuery
        : Query<SurveyQuestionQuery, SurveyQuestion.PredefinedFilter, SurveyQuestion.Field, SurveyQuestion.FilterField, SurveyQuestion.OrderField>
    {
    }
}
