using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ccs.Models;

namespace ccs.Data
{
    public class CCSContext : IdentityDbContext<AppUser>
    {
        public CCSContext (DbContextOptions<CCSContext> options)
            : base(options)
        {
        }

        public DbSet<ccs.Models.AppUser> ApplicationUsers { get; set; } = default!;
        public DbSet<ccs.Models.DeliveryRequest> DeliveryRequests { get; set; } = default!;
        public DbSet<ccs.Models.Product> Product { get; set; } = default!;
        public DbSet<ccs.Models.Truck> Truck { get; set; } = default!;
        public DbSet<ccs.Models.Route_> Route { get; set; } = default!;
        public DbSet<ccs.Models.Shipping> Shipping { get; set; } = default!;
    }
}
