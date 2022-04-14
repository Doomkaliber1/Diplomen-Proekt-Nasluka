using Nasluka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Models
{
    public class OrderListingViewModel
    {
        public string Id { get; set; }
       
        public DateTime CreatedOn { get; set; }


        public int CountProducts { get; set; }


        public string UserName { get; set; }
         public string UserId { get; set; }
         public virtual ApplicationUser User { get; set; }

        public string ProductName { get; set; }
        public int ProductId { get; set; }

        
        public virtual Product Product { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
