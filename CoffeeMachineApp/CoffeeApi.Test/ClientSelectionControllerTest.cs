using CoffeeApi.Controllers;
using CoffeeApi.DTO;
using CoffeeApi.Interfaces;
using CoffeeApi.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeApi.Test
{
    public class ClientSelectionControllerTest
    {
        private readonly CoffeeDBContext context;

        public ClientSelectionControllerTest()
        {
            var options = new DbContextOptionsBuilder<CoffeeDBContext>()
                .UseInMemoryDatabase(databaseName: "CoffeeClientSelectionTestDB")
                .Options;

            context = new CoffeeDBContext(options);
            DbInitializer.Initialize(context);
        }

        [Fact]
        public void TestClientSelectionService()
        {
            IClientSelectionService clientSelectionService = new ClientSelectionService(context);

            var clientSelectionToAdd = new ClientSelectionDTO()
            {
                BadgeNumber = "KS5VYB",
                DrinkTypeId = 1,
                SugarQty = 17,
                UsePersonalMug = true
            };

            clientSelectionService.AddClientSelection(clientSelectionToAdd);

            var respond1 = clientSelectionService.GetClientSelection("KS5VYB");

            Assert.Equal(clientSelectionToAdd, respond1);

            var updatedClientSelection = new ClientSelectionDTO()
            {
                BadgeNumber = "KS5VYB",
                DrinkTypeId = 2,
                SugarQty = 80,
                UsePersonalMug = false
            };

            clientSelectionService.UpdateClientSelection(updatedClientSelection);
            var respond2 = clientSelectionService.GetClientSelection("KS5VYB");

            Assert.Equal(updatedClientSelection, respond2);
        }

        [Fact]
        public void TestClientSelectionController()
        {
            IClientSelectionService clientSelectionService = new ClientSelectionService(context);
            var clientSelectionController = new ClientSelectionController(clientSelectionService);

            var clientSelectionToAdd = new ClientSelectionDTO()
            {
                BadgeNumber = "KS5VYB",
                DrinkTypeId = 1,
                SugarQty = 17,
                UsePersonalMug = true
            };

            var addResult = clientSelectionController.AddSelection(clientSelectionToAdd);

            Assert.IsType<OkResult>(addResult);

            var respond = clientSelectionController.GetClientSelection("KS5VYB") as OkObjectResult;

            Assert.Equal(clientSelectionToAdd, respond.Value as ClientSelectionDTO);

            var notFound = clientSelectionController.GetClientSelection("xxxxxx");

            Assert.IsType<NotFoundResult>(notFound);
        }
    }
}
