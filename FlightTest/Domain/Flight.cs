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

        public void CancelBooking(string email, uint numberOfSeats)
        {
            _RemainingNumberOfSeats += numberOfSeats;
        }
    }
}
