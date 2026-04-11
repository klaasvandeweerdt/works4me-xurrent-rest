using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ShortUrl"/> records.
    /// </summary>
    public sealed class ShortUrlQuery
        : Query<ShortUrlQuery, ShortUrl.PredefinedFilter, ShortUrl.Field, ShortUrl.FilterField, ShortUrl.OrderField>
    {
    }
}
