using CoffeeApi.DTO;
using Domain.Model;

namespace CoffeeApi.Interfaces
{
    public interface IClientSelectionService
    {
        void AddClientSelection(ClientSelectionDTO clientSelectionDTO);
        
        void UpdateClientSelection(ClientSelectionDTO clientSelectionDTO);

        ClientSelectionDTO GetClientSelection(string badgeNumber);
    }
}