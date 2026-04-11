using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ReservationClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetReservationsAsync()
        {
            ReadOnlyKeyedDataCollection<Reservation> reservations = await _client.Reservations.GetAsync(new ReservationQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(reservations);

            if (reservations.Count > 0)
            {
                Reservation? reservation = await _client.Reservations.GetAsync(reservations.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(reservation);
            }
        }
    }
}
