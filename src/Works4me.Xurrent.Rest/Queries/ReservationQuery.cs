using Works4me.Xurrent.Rest.Builders;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Provides a strongly typed query builder for retrieving <see cref="Reservation"/> records.
    /// </summary>
    public sealed class ReservationQuery
        : Query<ReservationQuery, Reservation.PredefinedFilter, Reservation.Field, Reservation.FilterField, Reservation.OrderField>
    {
    }
}
