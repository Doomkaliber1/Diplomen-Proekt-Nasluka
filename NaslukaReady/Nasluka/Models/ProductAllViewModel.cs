using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Models
{
    public class ProductAllViewModel
    {
        
        public int Id { get; set; }
       
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "CategoryId")]
        public int CategoryId { get; set; }
       
        [Display(Name = "Image")]
        public string Image { get; set; }
       
        [Display(Name = "Price")]
        public decimal Price { get; set; }
      
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
