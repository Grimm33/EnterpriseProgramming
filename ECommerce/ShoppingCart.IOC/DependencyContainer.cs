using AutoMapper;
using ECommerce.Application.AutoMapper;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Data.Context;
using ECommerce.Data.Repositories;
using ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            /*
            When are the instances creted?
            Singleton: IoC container will create and share a single instance of a service throughout the application's lifetime.
                many requests > 1 instance 
            Tranasient: The IoC container will create a new instance of the specified service type every time you ask for it.
                1 request > multiple instances
            Scoped: The Ioc container will create an instance of the specified service type once per request and will be shared in a single request.
                1 request > 1 instance
            */

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();

            services.AddScoped<IMembersRepository, MembersRepository>();
            services.AddScoped<IMembersService, MembersService>();

            services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer(
                    connectionString));

            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}
