using MediatR;
using OA.Application.Mappers;
using OA.Domain;
using OA.Domain.ProductUseCases.Queries;
using OA.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.ProductUseCases.Queries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, CustomResponseDto<GetAllProductResponse>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetAllProductQueryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<CustomResponseDto<GetAllProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var productWithPages = await _repositoryManager.ProductRepository.GetAll(request.Page, request.PageSize);

            var response = new GetAllProductResponse()
            {
                Products = ObjectMapper.Mapper.Map<List<ProductDto>>(productWithPages.List),
                TotalCount = productWithPages.TotalCount
            };

            return CustomResponseDto<GetAllProductResponse>.Success(200, response);
        }
    }
}