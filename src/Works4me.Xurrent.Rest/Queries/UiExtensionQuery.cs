using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="UiExtension"/> records.
    /// </summary>
    public sealed class UiExtensionQuery
        : Query<UiExtensionQuery, UiExtension.PredefinedFilter, UiExtension.Field, UiExtension.FilterField, UiExtension.OrderField>
    {
    }
}
