using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VitecProjekt.Models
{
    public class VitecProjektModelsContext : DbContext
    {
        public VitecProjektModelsContext (DbContextOptions<VitecProjektModelsContext> options)
            : base(options)
        {
        }

        public DbSet<VitecProjekt.Models.Product> Product { get; set; }
        public DbSet<VitecProjekt.Models.Package> Package { get; set; }
        public DbSet<VitecProjekt.Models.Subscription> Subscriptions { get; set; }
    }
}
