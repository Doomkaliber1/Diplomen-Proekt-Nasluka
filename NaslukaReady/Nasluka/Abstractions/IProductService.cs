using Nasluka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Abstractions
{
    public interface IProductService
    {
        bool Create(string name, int categoryId, string description, string image, decimal price, int quantity);
        bool UpdateProduct(int productId, string name, int categoryId, string description, string image,decimal price, int quantity);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        bool RemoveById(int productId);
       // List<Product> GetProducts(string searchStringProduct, string searchStringName);
    }
}
