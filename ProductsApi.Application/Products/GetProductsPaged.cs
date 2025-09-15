using ProductsApi.Domain.Abstractions;
using Shared.Contracts.Products;

namespace ProductsApi.Application.Products;

public class GetProductsPaged : IGetProductsPaged
{
    private readonly IProductRepository _repo;
    public GetProductsPaged(IProductRepository repo) => _repo = repo;

    public async Task<PagedResponse<ProductItemDto>> ExecuteAsync(int page, int pageSize, CancellationToken ct = default)
    {
        var (items, total) = await _repo.GetPagedAsync(page, pageSize, ct);
        var mapped = items.Select(p => new ProductItemDto(p.ExternalId, p.Name, p.Price, p.Currency, p.UpdatedAtUtc)).ToList();
        return new PagedResponse<ProductItemDto>(mapped, page, pageSize, total);
    }
}
