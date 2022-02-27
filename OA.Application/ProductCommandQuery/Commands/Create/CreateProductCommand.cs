using OA.Application.ProductUseCases;

namespace OA.Domain.ProductCommandQuery.Commands.Create
{
    public record CreateProductCommand : IRequest<CustomResponseDto<ProductDto>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string CategoryId { get; set; }
    }
}