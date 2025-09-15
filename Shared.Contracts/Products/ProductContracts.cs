namespace Shared.Contracts.Products;

public record ProductItemDto(
    string ExternalId,
    string Name,
    decimal Price,
    string Currency,
    DateTime UpdatedAtUtc
);

public record PagedResponse<T>(
    IReadOnlyList<T> Items,
    int Page,
    int PageSize,
    int Total
);
