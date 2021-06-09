using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class RestoContext : DbContext

    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public RestoContext() : base()
        {

        }
        public RestoContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=RestoDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
