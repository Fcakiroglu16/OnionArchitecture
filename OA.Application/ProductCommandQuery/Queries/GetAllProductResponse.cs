namespace OA.Application.ProductUseCases.Queries
{
    public record GetAllProductResponse : IResponsePage
    {
        public int TotalCount { get; set; }
        public List<ProductDto> Products { get; set; } = new();
    }
}