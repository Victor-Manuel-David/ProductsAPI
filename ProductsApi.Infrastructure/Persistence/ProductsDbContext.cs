using Microsoft.EntityFrameworkCore;
using ProductsApi.Domain.Entities;

namespace ProductsApi.Infrastructure.Persistence;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var p = modelBuilder.Entity<Product>();
        p.ToTable("Products");
        p.HasKey(x => x.Id);
        p.HasIndex(x => x.ExternalId).IsUnique();
        p.Property(x => x.ExternalId).HasMaxLength(64).IsRequired();
        p.Property(x => x.Name).HasMaxLength(200).IsRequired();
        p.Property(x => x.Price).HasColumnType("decimal(18,2)");
        p.Property(x => x.Currency).HasMaxLength(8).IsRequired();
        p.Property(x => x.UpdatedAtUtc).IsRequired();
    }
}
