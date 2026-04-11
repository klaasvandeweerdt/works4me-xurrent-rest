using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="BroadcastTranslation"/> records.
    /// </summary>
    public sealed class BroadcastTranslationQuery
        : Query<BroadcastTranslationQuery, BroadcastTranslation.PredefinedFilter, BroadcastTranslation.Field, BroadcastTranslation.FilterField, BroadcastTranslation.OrderField>
    {
    }
}
