using ECommerce.Data.Context;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        ECommerceDbContext _context;

        public ProductsRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public Guid AddProduct(Product p)
        {
            _context.Products.Add(p);   //stores the product inside memory until pushed to db
            _context.SaveChanges();     //permanently updates the database
            return p.Id;
        }

        public void DeleteProduct(Product p)
        {
            _context.Products.Remove(p);
            _context.SaveChanges();
        }

        public Product GetProduct(Guid Id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == Id);
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }
    }
}
