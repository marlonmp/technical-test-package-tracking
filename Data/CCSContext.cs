using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ccs.Models;
using Microsoft.AspNetCore.Identity;

namespace ccs.Data
{
    public class CCSContext : IdentityDbContext<AppUser>
    {
        public CCSContext (DbContextOptions<CCSContext> options)
            : base(options) {}

        public DbSet<ccs.Models.AppUser> ApplicationUsers { get; set; } = default!;
        public DbSet<ccs.Models.DeliveryRequest> DeliveryRequests { get; set; } = default!;
        public DbSet<ccs.Models.DeliveryRequestProduct> DeliveryRequestsProducts { get; set; } = default!;
        public DbSet<ccs.Models.Product> Product { get; set; } = default!;
        public DbSet<ccs.Models.Truck> Truck { get; set; } = default!;
        public DbSet<ccs.Models.TruckMaintenance> TruckMaintenances { get; set; } = default!;
        public DbSet<ccs.Models.Route_> Route { get; set; } = default!;
        public DbSet<ccs.Models.RouteDetail> RouteDetails { get; set; } = default!;
        public DbSet<ccs.Models.Shipping> Shipping { get; set; } = default!;
        public DbSet<ccs.Models.ShippingDetail> ShippingDetails { get; set; } = default!;

        public override int SaveChanges()
        {
            this.AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entries = this.ChangeTracker
                .Entries()
                .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.Entity is CreableModel creableModel && entry.State == EntityState.Added)
                {
                    creableModel.AddTimestamp();
                }

                if (entry.Entity is UpgradeableModel upgradeableModel && entry.State == EntityState.Modified)
                {
                    upgradeableModel.UpdateTimestamp();
                }
            }
        }
    }
}
