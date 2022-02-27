namespace OA.Domain.ProductCommandQuery.Commands.Create
{
    public record CreateProductCommand : IRequest<CustomResponseDto<CreateProductResponse>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}