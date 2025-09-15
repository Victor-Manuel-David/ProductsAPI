using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Application.Products;
using Shared.Contracts.Products;

namespace ProductsApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // exige JWT: Recibe el token de AuthServer
public class ProductsController : ControllerBase
{
    private readonly IGetProductsPaged _useCase;
    public ProductsController(IGetProductsPaged useCase) => _useCase = useCase;

    [HttpGet]
    public async Task<ActionResult<PagedResponse<ProductItemDto>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 50, CancellationToken ct = default)
    {
        var result = await _useCase.ExecuteAsync(page, pageSize, ct);
        return Ok(result);
    }
}
