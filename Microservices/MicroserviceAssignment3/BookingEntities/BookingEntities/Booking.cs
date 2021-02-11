using System;
using System.Collections.Generic;
using System.Text;

namespace BookingEntities.BookingEntities
{
    public class Booking
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Tickets { get; set; }
        public double Price { get; set; }
    }
}
