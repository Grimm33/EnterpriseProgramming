using AutoMapper;
using ECommerce.Application.Interfaces;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Application.Services
{
    public class ProductsService : IProductsService
    {

        private IProductsRepository _productsRepository;
        private IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            var products = _productsRepository.GetProducts();
            var res = _mapper.Map<IQueryable<Product>, IQueryable<ProductViewModel>>(products);

            return res;

            //to be implemented with AutoMapper
/*
            var list = from p in _productsRepository.GetProducts()
                       select new ProductViewModel()
                       {
                           Id = p.Id,
                           Description = p.Description,
                           Name = p.Name,
                           Price = p.Price,
                           Category = new CategoryViewModel()
                           {
                               Id = p.Category.Id,
                               Name = p.Category.Name
                           },
                           ImageUrl = p.ImageUrl
                       };

            return list;
*/
        }

        public IQueryable<ProductViewModel> GetProducts(int category)
        {
            //Domain >> ViewModels

            var list = from p in _productsRepository.GetProducts().Where(x => x.Category.Id == category)
                       select new ProductViewModel()
                       {
                           Id = p.Id,
                           Description = p.Description,
                           Name = p.Name,
                           Price = p.Price,
                           Category = new CategoryViewModel()
                           {
                               Id = p.Category.Id,
                               Name = p.Category.Name
                           },
                           ImageUrl = p.ImageUrl
                       };

            return list;
        }

        public ProductViewModel GetProduct(Guid Id)
        {
            var myProduct = _productsRepository.GetProduct(Id);
            ProductViewModel myModel = new ProductViewModel();
            myModel.Description = myProduct.Description;
            myModel.ImageUrl = myProduct.ImageUrl;
            myModel.Name = myProduct.Name;
            myModel.Price = myProduct.Price;
            myModel.Id = myProduct.Id;
            myModel.Category = new CategoryViewModel()
            {
                Id = myProduct.Category.Id,
                Name = myProduct.Category.Name
            };

            return myModel;
        }

        public void AddProduct(ProductViewModel product)
        {
            Product p = new Product()
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.Category.Id,
                ImageUrl = product.ImageUrl
            };


            _productsRepository.AddProduct(p);
        }

        public void DeleteProduct(Guid id)
        {
            var p = _productsRepository.GetProduct(id);

            if(p != null)
                _productsRepository.DeleteProduct(p);
        }

        public void DisableProduct(Guid id)
        {
            _productsRepository.DisableProduct(id);
        }
    }
}
