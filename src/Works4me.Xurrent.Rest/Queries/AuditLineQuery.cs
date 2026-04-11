using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AuditLine"/> records.
    /// </summary>
    public sealed class AuditLineQuery
        : Query<AuditLineQuery, AuditLine.PredefinedFilter, AuditLine.Field, AuditLine.FilterField, AuditLine.OrderField>
    {
    }
}
