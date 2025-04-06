using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Domain.Seeders


{
    public class EShopSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                context.Database.EnsureCreated();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { Name = "Electronics" },
                        new Category { Name = "Books" },
                        new Category { Name = "Clothing" }
                    );
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product { Name = "Laptop", Price = 999.99m, CategoryId = 1 },
                        new Product { Name = "Smartphone", Price = 499.99m, CategoryId = 1 },
                        new Product { Name = "Novel", Price = 19.99m, CategoryId = 2 },
                        new Product { Name = "T-Shirt", Price = 14.99m, CategoryId = 3 }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
