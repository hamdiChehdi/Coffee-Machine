using CoffeeApi.DTO;
using CoffeeApi.Interfaces;
using Domain;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace CoffeeApi.Services
{
    public class ClientSelectionService : IClientSelectionService
    {
        private readonly CoffeeDBContext coffeeDBContext;

        public ClientSelectionService(CoffeeDBContext coffeeDBContext)
        {
            this.coffeeDBContext = coffeeDBContext;
        }

        public ClientSelectionDTO GetClientSelection(string badgeNumber)
        {
            var badge = coffeeDBContext.Badges
                        .Include(badge => badge.ClientSelection)
                        .ThenInclude(c => c.DrinkType)
                        .FirstOrDefault(b => b.BadgeNumber == badgeNumber);

            if (badge?.ClientSelection == null)
            {
                return null;
            }

            ClientSelectionDTO clientSelectionDTO = new ClientSelectionDTO();
            clientSelectionDTO.BadgeNumber = badgeNumber;
            clientSelectionDTO.UsePersonalMug = badge.ClientSelection.UsePersonalMug;
            clientSelectionDTO.DrinkTypeId = badge.ClientSelection.DrinkType.Id;
            clientSelectionDTO.SugarQty = badge.ClientSelection.SugarQty;
            return clientSelectionDTO;
        }

        public void AddClientSelection(ClientSelectionDTO clientSelectionDTO)
        {
            var badge = coffeeDBContext.Badges.FirstOrDefault(b => b.BadgeNumber == clientSelectionDTO.BadgeNumber);
            var drinkType = coffeeDBContext.DrinkTypes.FirstOrDefault(d => d.Id == clientSelectionDTO.DrinkTypeId);
            var clientSelection = new ClientSelection();
            clientSelection.Badge = badge;
            clientSelection.DrinkType = drinkType;
            clientSelection.UsePersonalMug = clientSelectionDTO.UsePersonalMug;
            clientSelection.SugarQty = clientSelectionDTO.SugarQty;
            coffeeDBContext.ClientSelections.Add(clientSelection);
            coffeeDBContext.SaveChanges();
        }

        public void UpdateClientSelection(ClientSelectionDTO clientSelectionDTO)
        {
            var badge = coffeeDBContext.Badges.FirstOrDefault(b => b.BadgeNumber == clientSelectionDTO.BadgeNumber);
            var drinkType = coffeeDBContext.DrinkTypes.FirstOrDefault(d => d.Id == clientSelectionDTO.DrinkTypeId);

            var clientSelection = coffeeDBContext.ClientSelections.First(cs => cs.Badge.BadgeNumber == clientSelectionDTO.BadgeNumber);
            clientSelection.DrinkType = drinkType;
            clientSelection.UsePersonalMug = clientSelectionDTO.UsePersonalMug;
            clientSelection.SugarQty = clientSelectionDTO.SugarQty;

            coffeeDBContext.Entry(clientSelection).State = EntityState.Modified;
            coffeeDBContext.SaveChanges();
        }

        
    }
}
