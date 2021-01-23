using AutoMapper;
using ECommerce.Application.ViewModels;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ProductViewModel, Product>().ForMember(x=>x.Category, opt=>opt.Ignore());
            CreateMap<CategoryViewModel, Category>();
            CreateMap<MemberViewModel, Member>();

            CreateMap<CartViewModel, Cart>();
        }
    }
}
