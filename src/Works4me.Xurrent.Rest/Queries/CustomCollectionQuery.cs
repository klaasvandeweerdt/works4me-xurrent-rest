using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="CustomCollection"/> records.
    /// </summary>
    public sealed class CustomCollectionQuery
        : Query<CustomCollectionQuery, CustomCollection.PredefinedFilter, CustomCollection.Field, CustomCollection.FilterField, CustomCollection.OrderField>
    {
    }
}
