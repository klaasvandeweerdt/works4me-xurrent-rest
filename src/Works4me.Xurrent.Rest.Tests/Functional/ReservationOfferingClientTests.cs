using System.Threading.Tasks;
using Works4me.Xurrent.Rest.Tests.Extensions;
using Works4me.Xurrent.Rest.Tests.Shared;
using Xunit;

namespace Works4me.Xurrent.Rest.Tests.Functional
{
    public sealed class ReservationOfferingClientTests
    {
        private readonly XurrentClient _client = Client.Get();

        [Fact]
        public async Task GetReservationOfferingsAsync()
        {
            ReadOnlyKeyedDataCollection<ReservationOffering> reservationOfferings = await _client.ReservationOfferings.GetAsync(new ReservationOfferingQuery()
                .SelectAll(),
                TestContext.Current.CancellationToken);

            Assert.NotNull(reservationOfferings);

            if (reservationOfferings.Count > 0)
            {
                ReservationOffering? reservationOffering = await _client.ReservationOfferings.GetAsync(reservationOfferings.GetRandomItem().Id, TestContext.Current.CancellationToken);

                Assert.NotNull(reservationOffering);
            }
        }
    }
}
