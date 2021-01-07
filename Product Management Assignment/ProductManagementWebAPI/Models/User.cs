//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductManagementWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

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
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}
