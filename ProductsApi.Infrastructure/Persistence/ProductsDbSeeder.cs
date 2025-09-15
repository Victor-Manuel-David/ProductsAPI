using ProductsApi.Domain.Entities;

namespace ProductsApi.Infrastructure.Persistence;

public static class ProductsDbSeeder
{
    public static async Task SeedAsync(ProductsDbContext db)
    {
        if (db.Products.Any()) return;

        var now = DateTime.UtcNow;
        var seed = new[]
        {
            new Product("p-1001", "Mouse", 15.99m, "USD", now.AddMinutes(-10)),
            new Product("p-1002", "Teclado", 25.49m, "USD", now.AddMinutes(-9)),
            new Product("p-1003", "Monitor", 199.90m, "USD", now.AddMinutes(-8)),
            new Product("p-1004", "Headset", 45.00m, "USD", now.AddMinutes(-7))
        };

        await db.Products.AddRangeAsync(seed);
        await db.SaveChangesAsync();
    }
}
