using BurgerApp.Repository.IRepositories;
using Dal;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BurgerApp.Repository
{
    public class RestoRepository : IRestoRepository
    {
        private RestoContext context;
        public RestoRepository(RestoContext context)
        {
            this.context = context;
        }
        public void AddBeverage(Beverage beverage)
        {
            context.Beverages.Add(beverage);
            context.SaveChanges();
        }

        //public void AddBurger(Burger burger)
        //{
        //    context.Burgers.Add(burger);
        //}

        public void AddDessert(Dessert dessert)
        {
            context.Desserts.Add(dessert);
            context.SaveChanges();
        }

        public void AddMenu(Menu menu)
        {
            context.Menus.Add(menu);
            context.SaveChanges();
        }

        public void AddSide(Side side)
        {
            context.Sides.Add(side);
            context.SaveChanges();
        }

        public void DeleteBeverage(Beverage beverage)
        {
            context.Beverages.Remove(beverage);
            context.SaveChanges();
        }

        //public void DeleteBurger(Burger burger)
        //{
        //    context.Burgers.Remove(burger);
        //}

        public void DeleteDessert(Dessert dessert)
        {
            context.Desserts.Remove(dessert);
            context.SaveChanges();
        }

        public void DeleteMenu(Menu menu)
        {
            context.Menus.Remove(menu);
            context.SaveChanges();
        }

        public void DeleteSide(Side side)
        {
            context.Sides.Remove(side);
            context.SaveChanges();
        }

        public IQueryable<Beverage> GetBeverages()
        {
            return context.Beverages;
        }

        //public IQueryable<Burger> GetBurgers()
        //{
        //    return context.Burgers;
        //}

        public IQueryable<Dessert> GetDesserts()
        {
            return context.Desserts;
        }

        public IQueryable<Menu> GetMenus()
        {
            return context.Menus.Include(m => m.Burger).Include(m => m.Side).Include(m => m.Beverage).Include(m => m.Dessert);
        }

        public IQueryable<Side> GetSides()
        {
            return context.Sides;
        }
        public void EditMenu(int id, Menu newMenu)
        {
            context.Menus.First(m => m.Id == id).Name = newMenu.Name;
            context.Menus.First(m => m.Id == id).Description = newMenu.Description;
            context.Menus.First(m => m.Id == id).Price = newMenu.Price;
            context.Menus.First(m => m.Id == id).Burger = newMenu.Burger;
            context.Menus.First(m => m.Id == id).Side = newMenu.Side;
            context.Menus.First(m => m.Id == id).Beverage = newMenu.Beverage;
            context.Menus.First(m => m.Id == id).Dessert = newMenu.Dessert;
            context.SaveChanges();
        }

        public void EditBeverage(int id, Beverage newBeverage)
        {
            context.Beverages.First(b => b.Id == id).Name = newBeverage.Name;
            context.Beverages.First(b => b.Id == id).Description = newBeverage.Description;
            context.Beverages.First(b => b.Id == id).Price = newBeverage.Price;
            context.Beverages.First(b => b.Id == id).IsCarbonated = newBeverage.IsCarbonated;
            context.Beverages.First(b => b.Id == id).Millimeter = newBeverage.Millimeter;
            context.SaveChanges();
        }

        public void EditBurger(int id, Burger newBurger)
        {
            context.Burgers.First(b => b.Id == id).Name = newBurger.Name;
            context.Burgers.First(b => b.Id == id).Description = newBurger.Description;
            context.Burgers.First(b => b.Id == id).Price = newBurger.Price;
            context.Burgers.First(b => b.Id == id).Weight = newBurger.Weight;
            context.Burgers.First(b => b.Id == id).BeefWeight = newBurger.BeefWeight;
            context.SaveChanges();
        }

        public void EditDessert(int id, Dessert newDessert)
        {
            context.Desserts.First(d => d.Id == id).Name = newDessert.Name;
            context.Desserts.First(d => d.Id == id).Description = newDessert.Description;
            context.Desserts.First(d => d.Id == id).Price = newDessert.Price;
            context.Desserts.First(d => d.Id == id).IsFrozen = newDessert.IsFrozen;
            context.Desserts.First(d => d.Id == id).Millimeter = newDessert.Millimeter;
            context.SaveChanges();
        }

        public void EditSide(int id, Side newSide)
        {
            context.Sides.First(s => s.Id == id).Name = newSide.Name;
            context.Sides.First(s => s.Id == id).Description = newSide.Description;
            context.Sides.First(s => s.Id == id).Price = newSide.Price;
            context.Sides.First(s => s.Id == id).Weight = newSide.Weight;
            context.Sides.First(s => s.Id == id).SaltWeight = newSide.SaltWeight;
            context.SaveChanges();
        }

        public IQueryable<Burger> GetBurgers()
        {
            throw new System.NotImplementedException();
        }

        public void AddBurger(Burger newBurger)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBurger(Burger burger)
        {
            throw new System.NotImplementedException();
        }
    }
}