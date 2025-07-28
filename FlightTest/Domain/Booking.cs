using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Booking
    {
        public string Email { get; set; }
        public uint NumberOfSeats { get; set; }

        public Booking(string email, uint numberOfSeats)
        {
            this.Email = email;
            this.NumberOfSeats = numberOfSeats;
        }
    }
}
