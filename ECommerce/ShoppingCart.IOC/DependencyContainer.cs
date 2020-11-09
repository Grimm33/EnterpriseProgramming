using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Data.Repositories;
using ECommerce.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

            //TODO Explain AddScoped
            //transfer init of ShoppingCartDbContext here
            //refine dependences
        }
    }
}
