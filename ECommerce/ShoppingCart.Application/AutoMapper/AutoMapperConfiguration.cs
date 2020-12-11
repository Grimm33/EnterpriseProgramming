using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(
                cfg =>{
                    cfg.AddProfile(new DomainToViewModelProfile());
                    cfg.AddProfile(new DomainToViewModelProfile());
                });
        }
    }
}
