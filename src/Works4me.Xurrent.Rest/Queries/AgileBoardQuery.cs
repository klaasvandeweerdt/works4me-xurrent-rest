using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AgileBoard"/> records.
    /// </summary>
    public sealed class AgileBoardQuery
        : Query<AgileBoardQuery, AgileBoard.PredefinedFilter, AgileBoard.Field, AgileBoard.FilterField, AgileBoard.OrderField>
    {
    }
}
