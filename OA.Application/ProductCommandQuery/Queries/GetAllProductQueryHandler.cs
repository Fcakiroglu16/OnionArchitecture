using OA.Domain.ProductUseCases.Queries;

namespace OA.Application.ProductUseCases.Queries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, CustomResponseDto<GetAllProductResponse>>
    {
        private readonly IReadRepositoryManager _readRepositoryManager;

        public GetAllProductQueryHandler(IReadRepositoryManager readRepositoryManager)
        {
            _readRepositoryManager = readRepositoryManager;
        }

        public async Task<CustomResponseDto<GetAllProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var productWithPages = await _readRepositoryManager.ProductRepository.GetAll(request.Page, request.PageSize);

            var response = new GetAllProductResponse()
            {
                Products = ObjectMapper.Mapper.Map<List<ProductDto>>(productWithPages.List),
                TotalCount = productWithPages.TotalCount
            };

            return CustomResponseDto<GetAllProductResponse>.Success(200, response);
        }
    }
}