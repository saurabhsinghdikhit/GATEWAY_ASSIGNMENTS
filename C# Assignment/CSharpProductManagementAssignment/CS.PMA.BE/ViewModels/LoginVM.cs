using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.BE.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(maximumLength: 30, MinimumLength = 6, ErrorMessage = "Password length shoud be between 6 to 30 characters")]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
