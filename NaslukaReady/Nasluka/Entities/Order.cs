using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Entities
{
    public class Order
    {
            public Order()
            {
                this.Id = Guid.NewGuid().ToString();
            }
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        
        public DateTime CreatedOn { get; set; }

        [Required]
        [Range(1,100)]
        
        public int CountProducts { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return CountProducts * Product.Price;
            }
        }
    }
}
