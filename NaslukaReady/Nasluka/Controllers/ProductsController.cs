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
using System.Threading.Tasks;

namespace Nasluka.Controllers
{
   
    public class ProductsController : Controller
    {
        public readonly ApplicationDbContext context;
        public readonly ICategoryService _categoryService;
        public readonly IProductService _productService;

        public ProductsController(ApplicationDbContext context, ICategoryService categoryService, IProductService productService)
        {
            this.context = context;
            _categoryService = categoryService;
            _productService = productService;
        }

        public ActionResult Create()
        {
            var product = new ProductCreateViewModel();
            product.Categories= _categoryService.GetCategories()
                .Select(c => new CategoryChooseViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(ProductCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Product productFromDb = new Product
                {
                    Name = bindingModel.Name,
                    Description = bindingModel.Description,
                    CategoryId = bindingModel.CategoryId,
                    Price = bindingModel.Price,
                    Image = bindingModel.Image,
                    Quantity = bindingModel.Quantity


                };

                context.Products.Add(productFromDb);
                context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }
        public IActionResult Success()
        {
            return this.View();
        }

        public IActionResult All()
        {
            List<ProductAllViewModel> products = _productService.GetProducts()
               .Select(productFromDb => new ProductAllViewModel
                       {
                   Id = productFromDb.Id,
                   Name = productFromDb.Name,
                   CategoryId = productFromDb.CategoryId,
                   Image = productFromDb.Image,
                   Price = productFromDb.Price,
                   Quantity = productFromDb.Quantity,
               }).ToList();
            return this.View(products);
        }
        [Authorize(Roles = "Administrator")]
        
        public ActionResult Details(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDetailsViewModel product = new ProductDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                CategoryId = item.CategoryId,
                Price = item.Price,
                Image = item.Image,
                Quantity = item.Quantity
            };
            return View(product);   
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
           ProductCreateViewModel product = new ProductCreateViewModel()
            {
               Id = item.Id,
               Name = item.Name,
               Description = item.Description,
               Price = item.Price,
               Image = item.Image,
               Quantity = item.Quantity
           };
            product.Categories = _categoryService.GetCategories()
                .Select(c => new CategoryChooseViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
            return View(product);
        }



        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _productService.UpdateProduct(id, bindingModel.Name, bindingModel.CategoryId, bindingModel.Description, bindingModel.Image, bindingModel.Price, bindingModel.Quantity);
                if (updated)
                {
                    return this.RedirectToAction("All");
                }
            }
            return View(bindingModel);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductCreateViewModel dog = new ProductCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Image = item.Image,
                Quantity = item.Quantity
            };
            return View(dog);
        }

        // POST: ClientController/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _productService.RemoveById(id);
           
                if (deleted)
            {
                return RedirectToAction("All", "Products");
            }
            else
            {
                return View();
            }
        }
    }
    
}
