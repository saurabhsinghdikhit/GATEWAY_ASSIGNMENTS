using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.BE.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Name should be between 2 to 50 characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter Price")]
        [Display(Name = "Price")]
        [DataType(DataType.PhoneNumber)]
        [Range(100, 500000, ErrorMessage = "Price is Invalid")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please Select Quantity")]
        [Display(Name = "Quantity")]
        public long Quantity { get; set; }

        [Required(ErrorMessage = "Please enter short Description")]
        [Display(Name = "Short Description")]
        [StringLength(maximumLength: 100, ErrorMessage = "Description should be between 2 to 100 characters", MinimumLength = 2)]
        public string ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        [StringLength(maximumLength: 10000, ErrorMessage = "Description should be less than 2 characters", MinimumLength = 2)]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Please upload Small image")]
        [Display(Name = "Small Image")]
        public string SmallImageUrl { get; set; }

        [Display(Name = "Large Image")]
        public string LargeImageUrl { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
