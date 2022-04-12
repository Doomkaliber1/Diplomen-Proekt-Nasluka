using Nasluka.Abstractions;
using Nasluka.Data;
using Nasluka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(int productId, int countProducts)
        {
            Order item = new Order
            {
                ProductId = productId,
                CountProducts = countProducts,
                CreatedOn=DateTime.Now
            };

            _context.Orders.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }

        

        public List<Order> GetOrders()
        {
            List<Order> orders = _context.Orders.ToList();
            return orders;
        }

        

        public bool RemoveById(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order == default(Order))
            {
                return false;
            }
            _context.Remove(order);
            return _context.SaveChanges() != 0;
        }

        

        public bool Update(int orderId, int productId, int countProducts)
        {
            var order = GetOrderById(orderId);
            if (order == default(Order))
            {
                return false;
            }
            order.ProductId = productId;
            order.CountProducts = countProducts;
            _context.Update(order);
            return _context.SaveChanges() != 0;
        }

        
    }
}
