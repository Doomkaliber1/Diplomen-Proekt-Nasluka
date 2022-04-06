using Nasluka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Abstractions
{
    public interface IOrderService
    {
        bool Create(int productId,int countProducts);
        public List<Order> GetOrders();
        public bool RemoveById(int orderId);
        public bool Update(int orderId, int productId, int countProducts);
        public Order GetOrderById(int orderId);
    }
}
