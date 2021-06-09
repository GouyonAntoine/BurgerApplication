using Dal;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerAPp.Repository
{
    public class BurgerRepository : IBurgerRepository
    {
        private RestoContext context;
        public BurgerRepository(RestoContext context)
        {
            this.context = context;
        }


        //Partie classique
        //public void AddBurger(Burger burger)
        //{
        //    context.Burgers.Add(burger);
        //    context.SaveChanges();
        //}

        //public void DeleteBurger(Burger burger)
        //{
        //    context.Burgers.Remove(burger);
        //    context.SaveChanges();
        //}

        //public List<Burger> GetBurgers()
        //{
        //    return context.Burgers.ToList();
        //}
        //public void EditBurger(int id, Burger burger)
        //{
        //    var burgerBDD = GetBurger(id);
        //    burgerBDD.BeefWeight = burger.BeefWeight;
        //    burgerBDD.Description = burger.Description;
        //    burgerBDD.Name = burger.Name;
        //    burgerBDD.Price = burger.Price;
        //    burgerBDD.Weight = burger.Weight;
        //}

        //Version Asynchrone
        public async Task<int> CreateAsync(Burger burger)
        {
            context.Burgers.Add(burger);
            return await context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(Burger burger)
        {
            context.Burgers.Remove(burger);
            return await context.SaveChangesAsync();
        }
        public async Task<List<Burger>> GetBurgersAsync()
        {
            return await context.Burgers.ToListAsync();
        }
        public async Task<Burger> GetBurgerAsync(int id)
        {
            return await context.Burgers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> UpdateAsync(Burger newBurger)
        {
            context.Burgers.First(b => b.Id == newBurger.Id).Name = newBurger.Name;
            context.Burgers.First(b => b.Id == newBurger.Id).Description = newBurger.Description;
            context.Burgers.First(b => b.Id == newBurger.Id).Price = newBurger.Price;
            context.Burgers.First(b => b.Id == newBurger.Id).Weight = newBurger.Weight;
            context.Burgers.First(b => b.Id == newBurger.Id).BeefWeight = newBurger.BeefWeight;
            return await context.SaveChangesAsync();
        }
    }
}
