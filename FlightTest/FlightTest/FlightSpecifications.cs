using Domain;
using FluentAssertions;

namespace FlightTest
{
    public class FlightSpecifications
    {
        // parametrized test
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seatCapacity"></param>
        /// <param name="numberOfSeats"></param>
        /// <param name="remainingNumberOfSeats"></param>
        [Theory]
        [InlineData(3, 1, 2)]
        public void Booking_reduces_the_number_of_seats(uint seatCapacity, uint numberOfSeats, uint remainingNumberOfSeats)
        {
            var flight = new Flight(seatCapacity: seatCapacity);

            flight.Book("example@test.com", numberOfSeats);

            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);
        }

        [Fact]
        public void Avoids_overbooking()
        {
            // Given
            var flight = new Flight(seatCapacity: 3);

            // When
            var error = flight.Book("example@test.com", 4);

            // Then
            error.Should().BeOfType<OverbookingError>();
        }

        [Fact]
        public void Books_flight_successfully()
        {
            var flight = new Flight(seatCapacity: 3);
            var error = flight.Book("test@example.com", 1);
            error.Should().BeNull();
        }

        [Fact]
        public void Remembers_bookings()
        {
            var flight = new Flight(seatCapacity: 150);

            flight.Book(passengerEmail: "a@b.com", numberOfSeats: 4);

            flight.BookingList.Should().ContainEquivalentOf(new Booking("a@b.com", 4));
        }
    }
}
