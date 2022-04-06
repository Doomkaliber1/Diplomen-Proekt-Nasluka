using Nasluka.Abstractions;
using Nasluka.Data;
using Nasluka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Services
{
    public class CategoryService : ICategoryService
    {
         
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }

        public List<Category> GetProductsByCategory(int categoryId)
        {
            return _context.Categories
                .Where(x => x.Id ==
                categoryId)
                .ToList();
        }

        public Category GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategorieId(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
