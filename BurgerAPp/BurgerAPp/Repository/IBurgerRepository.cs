using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerAPp.Repository
{
    public interface IBurgerRepository
    {
        //public List<Burger> GetBurgers();
        //public void AddBurger(Burger burger);
        //public void DeleteBurger(Burger burger);
        //public Burger GetBurger(int id);
        //public void EditBurger(int id, Burger burger);
        public Task<List<Burger>> GetBurgersAsync();
        public Task<Burger> GetBurgerAsync(int id);
        public Task<int> CreateAsync(Burger newBurger);
        public Task<int> DeleteAsync(Burger burger);
        public Task<int> UpdateAsync(Burger newBurger);
    }
}
