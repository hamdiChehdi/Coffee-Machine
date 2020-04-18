using CoffeeApi.Controllers;
using CoffeeApi.Interfaces;
using CoffeeApi.Services;
using Domain;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeApi.Test
{
    public class DrinkTypeControllerTest
    {
        private readonly CoffeeDBContext context;

        public DrinkTypeControllerTest()
        {
            var options = new DbContextOptionsBuilder<CoffeeDBContext>()
                .UseInMemoryDatabase(databaseName: "CoffeeDrinkTypeTestDB")
                .Options;

            context = new CoffeeDBContext(options);
            DbInitializer.Initialize(context);
        }

        [Fact]
        public async Task TestDrinkTypeService()
        {
            IDrinkTypeService drinkTypeService = new DrinkTypeService(context);

            IEnumerable<DrinkType> drinkTypes = await drinkTypeService.GetAllDrinkTypes();
            
            Assert.Equal(3, drinkTypes.Count());
        }

        [Fact]
        public async Task TestDrinkTypeController()
        {
            IDrinkTypeService drinkTypeService = new DrinkTypeService(context);

            var drinkTypeController = new DrinkTypeController(drinkTypeService);

            IEnumerable<DrinkType> drinkTypes = await drinkTypeController.Get();

            Assert.Equal(3, drinkTypes.Count());
        }
    }
}
