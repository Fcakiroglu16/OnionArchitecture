namespace OA.Application.ProductUseCases;

public record ProductDto : IIdentity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Id { get; set; }
}