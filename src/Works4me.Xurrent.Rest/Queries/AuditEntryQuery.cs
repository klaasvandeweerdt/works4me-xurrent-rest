using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AuditEntry"/> records.
    /// </summary>
    public sealed class AuditEntryQuery
        : Query<AuditEntryQuery, AuditEntry.PredefinedFilter, AuditEntry.Field, AuditEntry.FilterField, AuditEntry.OrderField>
    {
    }
}
