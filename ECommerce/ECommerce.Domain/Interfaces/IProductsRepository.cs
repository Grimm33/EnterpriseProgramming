using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Domain.Interfaces
{
    public interface IProductsRepository
    {
        // IQueryable waits until just before the return statement to populate itself, before this it retains the LINQ and SQL commands and when return is called, this call is executed -- more efficient 
        IQueryable<Product> GetProducts(); 

        Product GetProduct(Guid Id);

        void DeleteProduct(Product p);

        Guid AddProduct(Product p);

        void DisableProduct(Guid id);
    }
}
