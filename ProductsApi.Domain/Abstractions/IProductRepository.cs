using ProductsApi.Domain.Entities;

namespace ProductsApi.Domain.Abstractions;

public interface IProductRepository
{
    Task<(IReadOnlyList<Product> Items, int Total)> GetPagedAsync(int page, int pageSize, CancellationToken ct = default);
}
