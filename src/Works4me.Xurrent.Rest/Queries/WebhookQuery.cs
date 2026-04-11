using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Webhook"/> records.
    /// </summary>
    public sealed class WebhookQuery
        : Query<WebhookQuery, Webhook.PredefinedFilter, Webhook.Field, Webhook.FilterField, Webhook.OrderField>
    {
    }
}
