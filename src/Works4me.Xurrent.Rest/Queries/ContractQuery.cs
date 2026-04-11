using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Contract"/> records.
    /// </summary>
    public sealed class ContractQuery
        : Query<ContractQuery, Contract.PredefinedFilter, Contract.Field, Contract.FilterField, Contract.OrderField>
    {
    }
}
