using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BE.ViewModels
{
    public class CustomerForgetPassword
    {
        [Required(ErrorMessage = "Please enter Email")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Question")]
        [Required(ErrorMessage = "Question is Required")]
        public string Question { get; set; }

        [Display(Name = "Answer")]
        [Required(ErrorMessage = "Answer is Required")]
        public string Answer { get; set; }
    }
}
