using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BE.BussinessEntities
{
    public class VehicleVM
    {
        public int Id { get; set; }
        [Display(Name = "License Plate")]
        [Required(ErrorMessage = "License Plate is Required")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "License Plate should be between 8-10 characters")]
        public string LicensePlate { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand is Required")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Brand should be between 4-25 characters")]
        public string Make { get; set; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "Model is Required")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Model should be between 4-25 characters")]
        public string Model { get; set; }
        [Display(Name = "Registration Date")]
        [Required(ErrorMessage = "Registration Date is Required")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }
        [Display(Name = "Chesis No")]
        [Required(ErrorMessage = "Chesis No is Required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Chesis No should be between 5-50 characters")]
        public string ChassisNo { get; set; }
        [Display(Name = "Owner Id")]
        [Required(ErrorMessage = "Owner ID is Required")]
        public int OwnerId { get; set; }
    }
}
