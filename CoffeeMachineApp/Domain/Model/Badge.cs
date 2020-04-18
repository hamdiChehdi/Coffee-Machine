using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Badge
    {
        public long Id { get; set; }
    
        public string BadgeNumber { get; set; }

        public string Owner { get; set; }

        public ClientSelection ClientSelection { get; set; }
    }
}
