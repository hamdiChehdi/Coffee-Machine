using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeApi.Interfaces;
using Domain;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CoffeeApi.Services
{
    public class DrinkTypeService : IDrinkTypeService
    {
        private readonly CoffeeDBContext coffeeDBContext;

        public DrinkTypeService(CoffeeDBContext coffeeDBContext)
        {
            this.coffeeDBContext = coffeeDBContext;
        }

        public async Task<IEnumerable<DrinkType>> GetAllDrinkTypes()
        {
            return await coffeeDBContext.DrinkTypes.ToListAsync();
        }
    }
}
