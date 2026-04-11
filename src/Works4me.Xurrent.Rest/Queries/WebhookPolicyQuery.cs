using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="WebhookPolicy"/> records.
    /// </summary>
    public sealed class WebhookPolicyQuery
        : Query<WebhookPolicyQuery, WebhookPolicy.PredefinedFilter, WebhookPolicy.Field, WebhookPolicy.FilterField, WebhookPolicy.OrderField>
    {
    }
}
