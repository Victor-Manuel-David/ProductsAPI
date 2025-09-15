using Shared.Contracts.Products;

namespace ProductsApi.Application.Products;

public interface IGetProductsPaged
{
    Task<PagedResponse<ProductItemDto>> ExecuteAsync(int page, int pageSize, CancellationToken ct = default);
}
