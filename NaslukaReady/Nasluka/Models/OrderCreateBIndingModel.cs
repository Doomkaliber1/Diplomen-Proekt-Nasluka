using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Models
{
    public class OrderCreateBIndingModel
    {
        public int Id { get; set; }


        public string CreatedOn { get; set; }


        public int CountProducts { get; set; }


        public string OrderId { get; set; }


        public decimal Product { get; set; }


    }
}
