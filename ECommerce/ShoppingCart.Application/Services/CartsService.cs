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
    public class CartsService : ICartsService
    {

        private ICartsRepository _cartsRepository;
        private IMapper _mapper;

        public CartsService(ICartsRepository cartsRepository, IMapper mapper)
        {
            _cartsRepository = cartsRepository;
            _mapper = mapper;
        }

        public void AddToCart(CartViewModel cart)
        {
            var cartItem = _mapper.Map<Cart>(cart);
            _cartsRepository.AddToCart(cartItem);
        }

        public void DeleteFromCart(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartViewModel> GetCart(string memberEmail)
        {
            var cart = _cartsRepository.GetCart(memberEmail).ProjectTo<CartViewModel>(_mapper.ConfigurationProvider);

            return cart;
        }
    }
}
