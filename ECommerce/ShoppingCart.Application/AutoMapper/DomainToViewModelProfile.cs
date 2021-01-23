using AutoMapper;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>(); //informing AutoMapper that we are mapping/linking Product onto ProductVewModel

            CreateMap<Category, CategoryViewModel>();

            CreateMap<Member, MemberViewModel>();

            CreateMap<Cart, CartViewModel>();
        }
    }
}
