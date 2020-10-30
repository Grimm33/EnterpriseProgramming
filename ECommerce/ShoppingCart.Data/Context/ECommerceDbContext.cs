using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Context
{
    //MUST inherit DbContext
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext( DbContextOptions options ) : base(options)
        {

        }

        //Pre defined method -- DbSet<>
        // right click Product >> Show Quick Fixes >> Add Reference to ECommerce.Domain
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
