using System;
using System.Collections.Generic;
using System.Text;

namespace BookingEntities.BookingEntities
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TheaterId { get; set; }
        public int MovieId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }
    }
}
