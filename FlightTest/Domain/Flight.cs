namespace Domain
{
    public class Flight
    {
        private uint _RemainingNumberOfSeats;
        public List<Booking> BookingList { get; set; } = new List<Booking>();

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

            BookingList.Add(new Booking(passengerEmail, numberOfSeats));

            return null;
        }


    }
}
