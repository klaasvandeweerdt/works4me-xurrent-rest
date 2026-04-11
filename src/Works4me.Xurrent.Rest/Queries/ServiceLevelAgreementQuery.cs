using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ServiceLevelAgreement"/> records.
    /// </summary>
    public sealed class ServiceLevelAgreementQuery
        : Query<ServiceLevelAgreementQuery, ServiceLevelAgreement.PredefinedFilter, ServiceLevelAgreement.Field, ServiceLevelAgreement.FilterField, ServiceLevelAgreement.OrderField>
    {
    }
}
