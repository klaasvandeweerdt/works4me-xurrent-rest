using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Site"/> records.
    /// </summary>
    public sealed class SiteQuery
        : Query<SiteQuery, Site.PredefinedFilter, Site.Field, Site.FilterField, Site.OrderField>
    {
    }
}
