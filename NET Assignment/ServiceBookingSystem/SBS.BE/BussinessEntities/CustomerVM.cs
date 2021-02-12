using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BE.BussinessEntities
{
    public class CustomerVM
    {
        public int Id { get; set; }

        [Display(Name ="Customer Name")]
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(40,MinimumLength =3,ErrorMessage ="Name should be between 3-40 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [Display(Name = "Address")]
        [StringLength(maximumLength: 30, ErrorMessage = "Address should be between 3 to 100 characters", MinimumLength = 3)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter City")]
        [Display(Name = "City")]
        [StringLength(maximumLength: 30, ErrorMessage = "City should be between 3 to 30 characters", MinimumLength = 3)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter State")]
        [Display(Name = "State")]
        [StringLength(maximumLength: 30, ErrorMessage = "State should be between 3 to 30 characters", MinimumLength = 3)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter Zip Code")]
        [Display(Name = "Salary")]
        [DataType(DataType.PhoneNumber)]
        [Range(1, 999999, ErrorMessage = "Zipcode is Invalid")]
        public int  Zipcode{ get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

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

        [Required(ErrorMessage = "Please enter Mobile number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 13, ErrorMessage = "Incorrent Mobile", MinimumLength = 10)]
        public string Mobile { get; set; }

        [Display(Name = "Question")]
        [Required(ErrorMessage = "Question is Required")]
        public string Question { get; set; }

        [Display(Name = "Answer")]
        [Required(ErrorMessage = "Answer is Required")]
        public string Answer { get; set; }
    }
}
