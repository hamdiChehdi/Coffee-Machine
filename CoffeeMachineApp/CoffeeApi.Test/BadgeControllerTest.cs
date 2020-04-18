using CoffeeApi.Controllers;
using CoffeeApi.Interfaces;
using CoffeeApi.Services;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace CoffeeApi.Test
{
    public class BadgeControllerTest
    {
        private readonly CoffeeDBContext context;

        public BadgeControllerTest()
        {
            var options = new DbContextOptionsBuilder<CoffeeDBContext>()
                .UseInMemoryDatabase(databaseName: "CoffeeBadgeTestDB")
                .Options;

            context = new CoffeeDBContext(options);
            DbInitializer.Initialize(context);
        }

        [Fact]
        public void TestBadgeService()
        {            
            IBadgeService badgeService = new BadgeService(context);

            string onwer = badgeService.GetOwner("KS5VYB");

            Assert.Equal("Alexander", onwer);
        }

        [Fact]
        public void TestBadgeController()
        {
            IBadgeService badgeService = new BadgeService(context);
            var badgeController = new BadgeController(badgeService);
            
            string onwer = badgeController.GetOnwer("WEJ2AC");

            Assert.Equal("Alonso", onwer);
        }
    }
}
