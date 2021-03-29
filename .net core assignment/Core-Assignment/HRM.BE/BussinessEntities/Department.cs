using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.BE.BussinessEntities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
