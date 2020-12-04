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
        // right click Products >> Show Quick Fixes >> Add Reference to ECommerce.Domain
        public DbSet<Product> Products { get; set; }    // > converted to tables

        public DbSet<Category> Categories { get; set; }

        public DbSet<Member> Members { get; set; }

        //generate GUID automatically
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
