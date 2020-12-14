using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            //mapping Products to ProductViewModel
            var products = _productsRepository.GetProducts().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);

            return products;

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

            var result = _mapper.Map<ProductViewModel>(myProduct);

          /*  ProductViewModel myModel = new ProductViewModel();
            myModel.Description = myProduct.Description;
            myModel.ImageUrl = myProduct.ImageUrl;
            myModel.Name = myProduct.Name;
            myModel.Price = myProduct.Price;
            myModel.Id = myProduct.Id;
            myModel.Category = new CategoryViewModel()
            {
                Id = myProduct.Category.Id,
                Name = myProduct.Category.Name
            };*/

            return result;
        }

        public void AddProduct(ProductViewModel product)
        {
            var prod = _mapper.Map<Product>(product);
            //prod.Category = null;   //mapper tried to create a new category but since category with id 1 - 3 already exist, an error is given
            //this was done in ViewModelToDomain which allows us to have the code in 1 place
            _productsRepository.AddProduct(prod);
/*
            // ProductViewModel >> Product
            Product p = new Product()
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.Category.Id,
                ImageUrl = product.ImageUrl
            };


            _productsRepository.AddProduct(p);*/
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
