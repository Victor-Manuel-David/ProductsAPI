namespace ProductsApi.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string ExternalId { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }
    public string Currency { get; private set; } = "USD";
    public DateTime UpdatedAtUtc { get; private set; }

    private Product() { } // EF

    public Product(string externalId, string name, decimal price, string currency, DateTime updatedAtUtc)
    {
        ExternalId = externalId;
        Name = name;
        Price = price;
        Currency = currency;
        UpdatedAtUtc = updatedAtUtc;
    }
}

