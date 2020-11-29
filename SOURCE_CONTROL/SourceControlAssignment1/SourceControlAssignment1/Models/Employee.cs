using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SourceControlAssignment1.CustomValidations;
namespace SourceControlAssignment1.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Please enter Employee ID")]
        [Display(Name = "Employee Id")]
        public int empId { get; set; }


        [Required(ErrorMessage = "Please enter Employee Name")]
        [Display(Name = "Employee Name")]
        [StringLength(maximumLength:50, MinimumLength = 3,ErrorMessage = "Name length shoud be less than 50 characters")]
        public string empName { get; set; }


        [Required(ErrorMessage = "Please enter Employee Mobile Number")]
        [Display(Name = "Employee mobile")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[789]\d{9}$", ErrorMessage = "Not a valid Phone number")]
        public string empMobile { get; set; }


        [Required(ErrorMessage = "Please enter Employee Email Id")]
        [Display(Name = "Employee Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Invalid Email Address")]
        public string empEmail { get; set; }


        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(maximumLength: 30, MinimumLength = 6, ErrorMessage = "Password length shoud be between 6 to 30 characters")]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Display(Name = "Password")]
        public string empPassword { get; set; }


        [Required(ErrorMessage = "Please enter Confirm password")]
        [Display(Name = "Comfirm Password")]
        [StringLength(maximumLength: 30, MinimumLength = 6, ErrorMessage = "Confirm Password length shoud be between 6 to 30 characters")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("empPassword", ErrorMessage = "Password Not Matched")]
        public string empConfirmPassword { get; set; }


        [Required(ErrorMessage = "Please enter Employee Date Of Birth")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime empDOB { get; set; }


        [Required(ErrorMessage = "Please enter Employee Department")]
        [Display(Name = "Employee Department")]
        [CustomDepartment]
        public string empDepartment { get; set; }


        [Required(ErrorMessage = "Please enter Employee Date of joining")]
        [Display(Name = "Date of Joining")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [CustomDataOfJoining(ErrorMessage = "Joining Date must be less than or equal to Today's Date")]
        public DateTime empDOJ { get; set; }


        [Required(ErrorMessage = "Please enter Employee Salary")]
        [Display(Name = "Employee Salary")]
        [Range(1000, 500000, ErrorMessage = "Salary is invalid")]
        public int empSalary { get; set; }


        [Required(ErrorMessage = "Please enter Employee Address")]
        [Display(Name = "Employee Address")]
        [MinLength(5,ErrorMessage ="Address is not sufficient")]
        public string empAddress { get; set; }



    }
}