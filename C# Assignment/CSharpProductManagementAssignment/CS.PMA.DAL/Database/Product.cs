using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.DAL.Database
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public long Quantity { get; set; }
        [Required]
        [StringLength(100)]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        [Required]
        [StringLength(100)]
        public string SmallImageUrl { get; set; }
        [StringLength(100)]
        public string LargeImageUrl { get; set; }
        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public User User { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
