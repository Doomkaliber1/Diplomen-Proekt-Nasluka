using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Models
{
    public class OrderCreateBIndingModel
    {
        [Key]
        public string Id { get; set; }


        public DateTime CreatedOn { get; set; }
       
       
        public decimal Price { get; set; }

        [Required]
        [Range(1,100)]
        public int CountProducts { get; set; }

        public int ProductId { get; set; }

        //  public string ProductName { get; set; }

        public decimal TotalPrice { get; }


    }
}
