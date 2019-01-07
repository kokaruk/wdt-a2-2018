using Microsoft.EntityFrameworkCore;

using WdtA2Api.Models;

namespace WdtA2Api.Data
{
    public class WdtA2ApiProductsContext : DbContext
    {
        public WdtA2ApiProductsContext(DbContextOptions<WdtA2ApiProductsContext> options)
            : base(options)
        {
        }

        public DbSet<OwnerInventory> OwnerInventory { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<StockRequest> StockRequest { get; set; }

        public DbSet<Store> Store { get; set; }

        public DbSet<StoreInventory> StoreInventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreInventory>().HasKey(inv => new { inv.ProductId, inv.StoreId });
        }
    }
}
