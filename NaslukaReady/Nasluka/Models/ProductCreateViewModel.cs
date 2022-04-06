using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Models
{
    public class ProductCreateViewModel
    {
        public ProductCreateViewModel()
        {
            Categories = new List<CategoryChooseViewModel>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        
        [Display(Name = "Category")]
        public int  CategoryId { get; set; }
        [Required]
        [Display(Name = "Price")]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        public virtual List<CategoryChooseViewModel> Categories { get; set; }
    }
}
