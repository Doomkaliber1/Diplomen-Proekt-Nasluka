using Nasluka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nasluka.Abstractions
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(int categoryId);
        List<Category> GetCategorieId(int categoryId);
    }
}
