using ECommerce.Data.Context;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        ECommerceDbContext _context;

        public CategoriesRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories;
        }
    }
}
