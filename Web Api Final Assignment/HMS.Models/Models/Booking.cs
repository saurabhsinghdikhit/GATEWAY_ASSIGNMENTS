using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingStatus { get; set; }
    }
}
