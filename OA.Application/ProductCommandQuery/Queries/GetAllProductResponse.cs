namespace OA.Application.ProductUseCases.Queries;

public record GetAllProductResponse : IResponsePage
{
    public List<ProductDto> Products { get; set; } = new();
    public int TotalCount { get; set; }
}