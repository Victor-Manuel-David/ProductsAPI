using Microsoft.EntityFrameworkCore;
using ProductsApi.Domain.Abstractions;
using ProductsApi.Domain.Entities;
using ProductsApi.Infrastructure.Persistence;

namespace ProductsApi.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductsDbContext _db;
    public ProductRepository(ProductsDbContext db) => _db = db;

    public async Task<(IReadOnlyList<Product> Items, int Total)> GetPagedAsync(int page, int pageSize, CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 50;

        var query = _db.Products.AsNoTracking().OrderBy(p => p.ExternalId);
        var total = await query.CountAsync(ct);
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);
        return (items, total);
    }
}
