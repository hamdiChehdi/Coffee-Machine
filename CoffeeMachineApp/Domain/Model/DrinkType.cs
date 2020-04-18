using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class DrinkType
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
