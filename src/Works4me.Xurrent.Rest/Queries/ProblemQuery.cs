using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Problem"/> records.
    /// </summary>
    public sealed class ProblemQuery
        : Query<ProblemQuery, Problem.PredefinedFilter, Problem.Field, Problem.FilterField, Problem.OrderField>
    {
    }
}
