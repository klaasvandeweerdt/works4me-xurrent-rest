using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="UsageStatement"/> records.
    /// </summary>
    internal sealed class UsageStatementQuery
        : Query<UsageStatementQuery, UsageStatement.PredefinedFilter, UsageStatement.Field, UsageStatement.FilterField, UsageStatement.OrderField>
    {
    }
}
