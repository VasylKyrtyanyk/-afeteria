using Cafeteria.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Сafeteria.DataModels.Entities;

namespace Cafeteria.DAL
{
    public class CafeteriaDbContext : DbContext
    {
        public CafeteriaDbContext()
        {

        }
        public CafeteriaDbContext(DbContextOptions<CafeteriaDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductMenu>()
                .HasKey(pm => new { pm.MenuId, pm.ProductId });

            modelBuilder.Entity<ProductMenu>()
            .HasOne(pm => pm.Menu)
            .WithMany(m => m.ProductMenus)
            .HasForeignKey(sc => sc.MenuId);

            modelBuilder.Entity<ProductMenu>()
                .HasOne(pm => pm.Product)
                .WithMany(m => m.ProductMenus)
                .HasForeignKey(sc => sc.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId });

            modelBuilder.Entity<ProductOrder>()
            .HasOne(po => po.Order)
            .WithMany(p => p.ProductOrders)
            .HasForeignKey(sc => sc.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(sc => sc.ProductId);

            modelBuilder.SeedData();
        }
    }
}
