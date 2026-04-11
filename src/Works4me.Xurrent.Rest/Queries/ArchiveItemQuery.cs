using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ArchiveItem"/> records.
    /// </summary>
    public sealed class ArchiveItemQuery
        : Query<ArchiveItemQuery, ArchiveItem.PredefinedFilter, ArchiveItem.Field, ArchiveItem.FilterField, ArchiveItem.OrderField>
    {
    }
}
