using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WdtA2Api.Models
{
    public class WdtA2ApiProductsContext : DbContext
    {
        public WdtA2ApiProductsContext (DbContextOptions<WdtA2ApiProductsContext> options)
            : base(options)
        {
        }

        public DbSet<WdtA2Api.Models.Product> Product { get; set; }
    }
}
