using Nasluka.Abstractions;
using Nasluka.Data;
using Nasluka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Nasluka.Services
{
    public class ProductService : IProductService
    {
         
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, int categoryId, string description, string image,decimal price, int quantity)
        {
            var product = new Product
            {
                Name = name,
                CategoryId = categoryId,
                Description = description,
                Image = image,
                Price = price,
                Quantity = quantity,
            };

            _context.Products.Add(product);

            return _context.SaveChanges() != 0;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);

        }

        public List<Product> GetProducts()
        {
            List<Product> products = _context.Products
               .ToList();
            return products;
        }

        public bool RemoveById(int productId)
        {
            var product = GetProductById(productId);
            if (product == default(Product))
            {
                return false;
            }
            _context.Remove(product);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateProduct(int productId, string name, int categoryId, string description, string image, decimal price, int quantity)
        {
            var product = GetProductById(productId);
            if (product == default(Product))
            {
                return false;
            }
            product.Name = name;
            product.CategoryId=categoryId;
            product.Description=description;
            product.Image = image;
            product.Price = price;
            product.Quantity = quantity;
            
            _context.Update(product);
            return _context.SaveChanges() != 0;
        }
    }
}
