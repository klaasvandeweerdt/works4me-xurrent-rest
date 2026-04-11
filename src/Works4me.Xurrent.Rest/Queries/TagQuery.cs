using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Tag"/> records.
    /// </summary>
    public sealed class TagQuery
        : Query<TagQuery, Tag.PredefinedFilter, Tag.Field, Tag.FilterField, Tag.OrderField>
    {
    }
}
