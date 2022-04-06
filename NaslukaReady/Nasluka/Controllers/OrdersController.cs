using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nasluka.Data;
using Nasluka.Entities;
using Nasluka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrdersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: OrdersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreateBIndingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var item = context.Products.Find(bindingModel.ProductId);
                if (item == null)
                {
                    return this.RedirectToAction("Create");
                }
                Order order = new Order
                {
                    CountProducts = bindingModel.CountProducts,
                    ProductId = bindingModel.ProductId,
                    CreatedOn = DateTime.Now,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                return this.RedirectToAction("All", "Products");
            }
            return View(); //za da se vidi pak formata
        }
    

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
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
