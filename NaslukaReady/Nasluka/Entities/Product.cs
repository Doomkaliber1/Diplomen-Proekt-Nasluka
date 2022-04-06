using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Entities
{
    public class Product
    {
        
       
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; } 
        
        public virtual Category Category { get; set; }

        [Required]
        [MaxLength(150)]
        [MinLength(5)]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
        
    }
}
