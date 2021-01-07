using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProductManagementMVC.ViewModels
{
    public class LoginViewModel
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