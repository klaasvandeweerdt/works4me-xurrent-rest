using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Account"/> records.
    /// </summary>
    public sealed class AccountQuery
        : Query<AccountQuery, Account.PredefinedFilter, Account.Field, Account.FilterField, Account.OrderField>
    {
    }
}
