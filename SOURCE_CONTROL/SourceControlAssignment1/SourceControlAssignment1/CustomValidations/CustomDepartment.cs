using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlAssignment1.CustomValidations
{
    public class CustomDepartment : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string department = value.ToString();
                if (department.Equals("Sales") || department.Equals("Executive") || department.Equals("HR")||department.Equals("Engineers"))
                {
                    return ValidationResult.Success;    
                }
                else
                {
                    return new ValidationResult("Department should be Sales,Executive,HR and Engineers");
                }
            }
            else
            {
                return new ValidationResult("Department can not be null");
            }
        }
    }
}