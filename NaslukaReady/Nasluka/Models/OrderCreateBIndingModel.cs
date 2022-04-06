using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Models
{
    public class OrderCreateBIndingModel
    {
        public int Id { get; set; }


        public DateTime CreatedOn { get; set; }
       
        public decimal Price { get; set; }


        public int CountProducts { get; set; }


        public int ProductId { get; set; }


    }
}
