using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Address"/> records.
    /// </summary>
    public sealed class AddressQuery
        : Query<AddressQuery, Address.PredefinedFilter, Address.Field, Address.FilterField, Address.OrderField>
    {
    }
}
