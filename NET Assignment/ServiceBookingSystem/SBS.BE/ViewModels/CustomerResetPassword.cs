using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BE.ViewModels
{
    public class CustomerResetPassword
    {
        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        [StringLength(maximumLength: 30, ErrorMessage = "Passowrd should be between 6-20 character", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Confirm Password")]
        [Display(Name = "Confirm Password")]
        [StringLength(maximumLength: 30, ErrorMessage = "Passowrd should be between 6-20 character", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
