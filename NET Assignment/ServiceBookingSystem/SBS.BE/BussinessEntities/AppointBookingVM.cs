using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BE.BussinessEntities
{
    public class AppointBookingVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Start time is require")]
        [Display(Name ="Starting time")]
        public System.DateTime StartTime { get; set; }
        [Required(ErrorMessage = "End time is require")]
        [Display(Name = "Ending time")]
        public System.DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Vehicle is require")]
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "Dealer is require")]
        [Display(Name = "Dealer")]
        public int DealerId { get; set; }
        public Nullable<int> MechanicId { get; set; }
        [Required(ErrorMessage = "Service is require")]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        [Display(Name = "Customer")]
        public int CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<bool> Status { get; set; }
        public AppointBookingVM()
        {
            Status = false;
        }
    }
}
