using BurgerAPp.Repository.IRepositories;
using Dal;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerApp.Repository
{
    public class BeverageRepository : IBeverageRepository
    {
        private RestoContext context;
        public BeverageRepository(RestoContext context)
        {
            this.context = context;
        }

        public void AddBeverage(Beverage beverage)
        {
            context.Beverages.Add(beverage);
        }

        public void DeleteBeverage(Beverage beverage)
        {
            context.Beverages.Remove(beverage);
        }

        public IQueryable<Beverage> GetBeverages()
        {
            return context.Beverages;
        }
    }
}
