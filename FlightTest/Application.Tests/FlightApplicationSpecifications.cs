using FluentAssertions;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests
{
    public class FlightApplicationSpecifications
    {
        [Theory]
        [InlineData("M@m.com", 2)]
        [InlineData("a@a.com", 2)]
        public void Books_flights(string passengerEmail, uint numberOfSeats)
        {
            var entities = new Entities(new DbContextOptionsBuilder<Entities>()
                .UseInMemoryDatabase("Flights").Options);

            var flight = new Flight(3);
            entities.Flights.Add(flight);

            var bookingService = new BookingService(entities);

            bookingService.Book(new BookDTO(flight.Id, passengerEmail, numberOfSeats));

            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail, numberOfSeats)
                );
        }
    }

    public class BookingService
    {
        public Entities Entities { get; set; }

        public BookingService(Entities entities)
        {
            
        }
        public void Book(BookDTO bookDto)
        {
            var flight = Entities.Flights.Find(bookDto.FlightId);
            flight.Book(bookDto.PassengerEmail, bookDto.NumberOfSeats);
            Entities.SaveChanges();
        }

        public IEnumerable<BookingRm> FindBookings(Guid flightId)
        {
            return new[]
            {
                new BookingRm("a@b.com", 2)
            };
        }
    }

    public class BookDTO
    {
        public Guid FlightId { get; set; }
        public string PassengerEmail { get; set; }
        public uint NumberOfSeats { get; set; }

        public BookDTO(Guid flightId, string passengerEmail, uint numberOfSeats)
        {
            FlightId = flightId;
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
        }
    }

    public class BookingRm
    {
        public string PassengerEmail { get; set; }
        public uint NumberOfSeats { get; set; }

        public BookingRm(string passengerEmail, uint numberOfSeats)
        {
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
        }
    }
}
