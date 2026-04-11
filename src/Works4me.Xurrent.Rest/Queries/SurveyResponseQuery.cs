using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="SurveyResponse"/> records.
    /// </summary>
    public sealed class SurveyResponseQuery
        : Query<SurveyResponseQuery, SurveyResponse.PredefinedFilter, SurveyResponse.Field, SurveyResponse.FilterField, SurveyResponse.OrderField>
    {
    }
}
