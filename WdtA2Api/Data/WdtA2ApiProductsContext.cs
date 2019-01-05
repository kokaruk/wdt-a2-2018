namespace WdtA2Api.Data
{
    using Microsoft.EntityFrameworkCore;

    public class WdtA2ApiProductsContext : DbContext
    {
        public WdtA2ApiProductsContext(DbContextOptions<WdtA2ApiProductsContext> options)
            : base(options)
        {
        }

        public DbSet<WdtA2Api.Models.Product> Product { get; set; }
    }
}
