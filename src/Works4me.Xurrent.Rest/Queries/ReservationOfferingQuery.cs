using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="ReservationOffering"/> records.
    /// </summary>
    public sealed class ReservationOfferingQuery
        : Query<ReservationOfferingQuery, ReservationOffering.PredefinedFilter, ReservationOffering.Field, ReservationOffering.FilterField, ReservationOffering.OrderField>
    {
    }
}
