using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Team"/> records.
    /// </summary>
    public sealed class TeamQuery
        : Query<TeamQuery, Team.PredefinedFilter, Team.Field, Team.FilterField, Team.OrderField>
    {
    }
}
