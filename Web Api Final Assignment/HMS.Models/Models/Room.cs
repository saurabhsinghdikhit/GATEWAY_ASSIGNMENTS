using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomCategory { get; set; }
        public decimal RoomPrice { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int HotelId { get; set; }
    }
}
