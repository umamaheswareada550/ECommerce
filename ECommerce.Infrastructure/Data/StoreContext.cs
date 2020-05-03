using System;
using System.Reflection;
using ECommerce.Core.Entities;
using ECommerce.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        private readonly IConfiguration config;

        public StoreContext() { }
        public StoreContext(DbContextOptions<StoreContext> options,
                            IConfiguration _config) : base(options)
        {
            config = _config;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        
    }
}