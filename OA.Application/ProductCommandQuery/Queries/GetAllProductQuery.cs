using OA.Application.ProductUseCases.Queries;

namespace OA.Domain.ProductUseCases.Queries
{
    public record GetAllProductQuery : IRequestPage, IRequest<CustomResponseDto<GetAllProductResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}