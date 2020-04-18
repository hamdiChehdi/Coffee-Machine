using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ClientSelection
    {
        public long Id { get; set; }

        public DrinkType DrinkType { get; set; }

        public bool UsePersonalMug { get; set; }

        public int SugarQty { get; set; }

        public Badge Badge { get; set; }
        public long BadgeId { get; internal set; }
    }
}
