using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using WdtA2Api.Models;

namespace WdtA2Api.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WdtA2ApiProductsContext(
                serviceProvider.GetRequiredService<DbContextOptions<WdtA2ApiProductsContext>>()))
            {
                if (!context.Product.Any())
                {
                    context.Product.AddRange(
                        new Product { Name = "Rabbit", Price = (decimal)10.50 },
                        new Product { Name = "Hat", Price = (decimal)12.00 },
                        new Product { Name = "Svengali Deck", Price = 5 },
                        new Product { Name = "Floating Hankerchief", Price = 8 },
                        new Product { Name = "Wand", Price = 23 },
                        new Product { Name = "Broomstick", Price = 11 },
                        new Product { Name = "Bang Gun", Price = 17 },
                        new Product { Name = "Cloak of Invisibility", Price = 19 },
                        new Product { Name = "Elder Wand", Price = 15 },
                        new Product { Name = "Resurrection Stone", Price = 11 });
                    context.SaveChanges();
                }

                if (!context.Store.Any())
                {
                    context.Store.AddRange(
                        new Store { Name = "Melbourne CBD" },
                        new Store { Name = "North Melbourne" },
                        new Store { Name = "East Melbourne" },
                        new Store { Name = "South Melbourne" },
                        new Store { Name = "West Melbourne" });
                    context.SaveChanges();
                }
            }
        }
    }
}
