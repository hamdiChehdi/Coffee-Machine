using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeApi.Interfaces
{
    public interface IDrinkTypeService
    {
        Task<IEnumerable<DrinkType>> GetAllDrinkTypes();
    }
}