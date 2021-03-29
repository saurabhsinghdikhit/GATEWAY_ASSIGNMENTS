using HRM.BE.BussinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.BE
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        [StringLength(maximumLength: 6, MinimumLength = 4)]
        public string Salary { get; set; }
        public bool IsManager { get; set; }
        public string Manager { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }

        //Foreign key for Standard
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
