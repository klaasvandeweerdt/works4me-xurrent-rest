using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Release"/> records.
    /// </summary>
    public sealed class ReleaseQuery
        : Query<ReleaseQuery, Release.PredefinedFilter, Release.Field, Release.FilterField, Release.OrderField>
    {
    }
}
