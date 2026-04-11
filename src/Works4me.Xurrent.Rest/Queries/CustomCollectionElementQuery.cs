using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="CustomCollectionElement"/> records.
    /// </summary>
    public sealed class CustomCollectionElementQuery
        : Query<CustomCollectionElementQuery, CustomCollectionElement.PredefinedFilter, CustomCollectionElement.Field, CustomCollectionElement.FilterField, CustomCollectionElement.OrderField>
    {
    }
}
