using CoffeeApi.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkTypeController : ControllerBase
    {
        private readonly IDrinkTypeService drinkTypeService;

        public DrinkTypeController(IDrinkTypeService drinkTypeService)
        {
            this.drinkTypeService = drinkTypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<DrinkType>> Get()
        {           
            return await drinkTypeService.GetAllDrinkTypes();
        }
    }
}
