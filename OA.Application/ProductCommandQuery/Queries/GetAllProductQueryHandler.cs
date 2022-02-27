using OA.Domain.ProductUseCases.Queries;

namespace OA.Application.ProductUseCases.Queries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, CustomResponseDto<GetAllProductResponse>>
    {
        public async Task<CustomResponseDto<GetAllProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            //var productWithPages = await _repositoryManager.ProductRepository.GetAll(request.Page, request.PageSize);

            //var response = new GetAllProductResponse()
            //{
            //    Products = ObjectMapper.Mapper.Map<List<ProductDto>>(productWithPages.List),
            //    TotalCount = productWithPages.TotalCount
            //};

            return CustomResponseDto<GetAllProductResponse>.Success(200);
        }
    }
}