using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="UiExtensionVersion"/> records.
    /// </summary>
    public sealed class UiExtensionVersionQuery
        : Query<UiExtensionVersionQuery, UiExtensionVersion.PredefinedFilter, UiExtensionVersion.Field, UiExtensionVersion.FilterField, UiExtensionVersion.OrderField>
    {
    }
}
