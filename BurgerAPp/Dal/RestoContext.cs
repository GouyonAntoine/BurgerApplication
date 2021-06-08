using Microsoft.EntityFrameworkCore;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;

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
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FastFood;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Beverage>().ToTable("Beverages");
            modelBuilder.Entity<Burger>().ToTable("Burgers");
            modelBuilder.Entity<Dessert>().ToTable("Desserts");
            modelBuilder.Entity<Menu>().ToTable("Menus");
            modelBuilder.Entity<Side>().ToTable("Sides");

            modelBuilder.Entity<Menu>().HasOne(m => m.Beverage);
            modelBuilder.Entity<Menu>().HasOne(m => m.Burger);
            modelBuilder.Entity<Menu>().HasOne(m => m.Side);
            modelBuilder.Entity<Menu>().HasOne(m => m.Dessert);
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
