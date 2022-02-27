namespace OA.Application.ProductUseCases
{
    public record ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}