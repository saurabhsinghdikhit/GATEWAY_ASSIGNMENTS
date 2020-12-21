using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Source_Control_Final_Assignment.CustomValidation;
namespace Source_Control_Final_Assignment.ViewModel
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter Employee First Name")]
        [Display(Name = "First Name")]
        [StringLength(maximumLength:20,ErrorMessage ="Name should be between 2 to 20 characters",MinimumLength =2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Employee Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 20, ErrorMessage = "Name should be between 2 to 20 characters", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Employee Email")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        [StringLength(maximumLength: 20, ErrorMessage = "Passowrd should be between 6-20 character", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Employee salary")]
        [Display(Name = "Salary")]
        [DataType(DataType.PhoneNumber)]
        [Range(1000, 100000, ErrorMessage = "Salary is Invalid")]
        public float Salary { get; set; }

        [Required(ErrorMessage = "Please enter Mobile number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please enter Employee Date of joining")]
        [Display(Name = "Date of Joining")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [CustomDataOfJoining(ErrorMessage = "Joining Date must be less than or equal to Today's Date")]
        public DateTime empDOJ { get; set; }

     
        [Display(Name = "Employee Image")]
        [FileExtensions(Extensions = "jpg,png", ErrorMessage = "Only Image file allowed")]
        public HttpPostedFileBase employeeImage { get; set; }

    }
}