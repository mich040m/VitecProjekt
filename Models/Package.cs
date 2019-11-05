using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecProjekt.Models
{
    public class Package
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public double Price { get; set; }
        public Subscription Subscription { get; set; }
        
    }
}
