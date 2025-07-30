namespace Domain
{
    public class Flight
    {
        private uint _RemainingNumberOfSeats;
        private List<Booking> _bookingList = new();

        public IEnumerable<Booking> BookingList => _bookingList;

        public uint RemainingNumberOfSeats { 
            get { return _RemainingNumberOfSeats; }
            set 
            { 
                if (value > 0)
                {
                    _RemainingNumberOfSeats = value;
                }
                else
                {
                    throw new ArgumentException("Entered number of seats is <= 0");
                }
            }
        }

        public Guid Id { get; }

        [Obsolete("Needed by EF")]
        Flight()
        {

        }

        public Flight(uint seatCapacity) 
        {
            _RemainingNumberOfSeats = seatCapacity;
        }

        public object? Book(string passengerEmail, uint numberOfSeats)
        {
            if (numberOfSeats > this._RemainingNumberOfSeats)
            {
                return new OverbookingError();
            }

            _RemainingNumberOfSeats -= numberOfSeats;

            _bookingList.Add(new Booking(passengerEmail, numberOfSeats));

            return null;
        }

        public object? CancelBooking(string passedgerEmail, uint numberOfSeats)
        {
            if (!BookingList.Any(booking => booking.Email == passedgerEmail))
            {
                return new BookingNotFoundError();
            }
            
            _RemainingNumberOfSeats += numberOfSeats;

            return null;
        }
    }
}
