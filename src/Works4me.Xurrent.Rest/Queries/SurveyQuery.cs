using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Survey"/> records.
    /// </summary>
    public sealed class SurveyQuery
        : Query<SurveyQuery, Survey.PredefinedFilter, Survey.Field, Survey.FilterField, Survey.OrderField>
    {
    }
}
