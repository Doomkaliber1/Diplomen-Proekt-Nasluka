using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nasluka.Abstractions;
using Nasluka.Data;
using Nasluka.Entities;
using Nasluka.Models;
using Nasluka.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nasluka.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IOrderService _orderService;

        public OrdersController(ApplicationDbContext context, IOrderService orderService)
        {
            this.context = context;
            _orderService = orderService;
        }



        // GET: OrdersController
        public ActionResult Index()
        {
            List<OrderListingViewModel> ordersFromDb = _orderService.GetOrders()
              .Select(item => new OrderListingViewModel()
              {
                  Id = item.Id,
                  CreatedOn = item.CreatedOn,
                  CountProducts = item.CountProducts,
                  UserName = item.User.UserName,
                  ProductName = item.Product.Name,
                  TotalPrice=item.TotalPrice
              }).ToList();
            return View(ordersFromDb);
        }
        public ActionResult My()
        {
            string currentUserId =
           this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<OrderListingViewModel> reservations = this._orderService.GetOrders()
             .Where(o => o.UserId == currentUserId)
             .Select(item => new OrderListingViewModel()
             {
                 Id = item.Id,
                 CreatedOn = item.CreatedOn,
                 CountProducts = item.CountProducts,
                 UserName = item.User.UserName,
                 ProductName = item.Product.Name,
                 TotalPrice = item.TotalPrice
             }).ToList();
            return View(reservations);
        }
        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
        [Authorize]
        public ActionResult Create(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            Product item = context.Products.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            OrderCreateBIndingModel order = new OrderCreateBIndingModel()
            {
                ProductId = item.Id,
                Price = item.Price,
                

            };
            return View(order);
        }

        // POST: OrdersController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreateBIndingModel bindingModel)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
            var product = this.context.Products.SingleOrDefault(e => e.Id == bindingModel.ProductId);
            if (user == null || product == null || product.Quantity < bindingModel.CountProducts)
            {
                // ако потребителят не съществува или продуктът не съществува или няма достатъчно наличност
                return this.RedirectToAction("All", "Products"); //направи го да отива в друга страница като при Success
            }
            if (ModelState.IsValid)
            {
                Order order = new Order
                {
                    CountProducts = bindingModel.CountProducts,
                    ProductId = bindingModel.ProductId,
                    CreatedOn = DateTime.Now,
                    UserId=currentUserId
                };
                product.Quantity -= bindingModel.CountProducts; //намаляваме наличността на продукта
                this.context.Products.Update(product);

                context.Orders.Add(order);
                context.SaveChanges();
                return this.RedirectToAction("All", "Products");
            }
            return View(); //za da se vidi pak formata
        }


        // GET: OrdersController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
