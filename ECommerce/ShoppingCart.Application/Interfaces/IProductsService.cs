using ECommerce.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Application.Interfaces
{
    public interface IProductsService
    {
        IQueryable<ProductViewModel> GetProducts();

        IQueryable<ProductViewModel> GetProducts(int category);

        IQueryable<ProductViewModel> GetProducts(string keyword);

        ProductViewModel GetProduct(Guid Id);

        void AddProduct(ProductViewModel product);

        void DeleteProduct(Guid id);

        void DisableProduct(Guid id);
    }
}
