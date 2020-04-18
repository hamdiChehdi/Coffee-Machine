using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApi.DTO
{
    public class ClientSelectionDTO
    {
        public long DrinkTypeId { get; set; }

        public bool UsePersonalMug { get; set; }

        public string BadgeNumber { get; set; }

        public int SugarQty { get; set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }


            ClientSelectionDTO other = (ClientSelectionDTO)obj;
            return (DrinkTypeId, UsePersonalMug, BadgeNumber, SugarQty) == (other.DrinkTypeId, other.UsePersonalMug, other.BadgeNumber, other.SugarQty);
        }
    }
}
