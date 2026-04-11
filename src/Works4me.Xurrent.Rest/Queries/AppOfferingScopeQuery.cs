using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="AppOfferingScope"/> records.
    /// </summary>
    public sealed class AppOfferingScopeQuery
        : Query<AppOfferingScopeQuery, AppOfferingScope.PredefinedFilter, AppOfferingScope.Field, AppOfferingScope.FilterField, AppOfferingScope.OrderField>
    {
    }
}
