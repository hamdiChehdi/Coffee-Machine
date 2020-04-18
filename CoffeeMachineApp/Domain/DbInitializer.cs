using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public static class DbInitializer
    {
        public static void Initialize(CoffeeDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any badges.
            if (context.Badges.Any())
            {
                return;   // DB has been seeded
            }

            var badges = new Badge[]
            {
                new Badge{Owner="Alexander", BadgeNumber="KS5VYB"},
                new Badge{Owner="Alonso", BadgeNumber="WEJ2AC"},
                new Badge{Owner="Anand", BadgeNumber="HP7SY3"},
                new Badge{Owner="Barzdukas", BadgeNumber="4PUA7N"},
                new Badge{Owner="Justice", BadgeNumber="G2CPY7"},
                new Badge{Owner="Norman", BadgeNumber="UK82YX"},
                new Badge{Owner="Olivetto", BadgeNumber="TWKH4M"},
            };

            context.Badges.AddRange(badges);
            
            context.SaveChanges();

            var drinkTypes = new DrinkType[]
            {
                new DrinkType{Name="Coffee", Price = 3, ImageUrl = "/images/Coffe.png"},
                new DrinkType{Name="Tea", Price = 3.5m, ImageUrl = "/images/Tea.png"},
                new DrinkType{Name="Chocolate", Price = 4, ImageUrl = "/images/Chocolate.png"}
            };

            context.DrinkTypes.AddRange(drinkTypes);

            context.SaveChanges();
        }
    }
}
