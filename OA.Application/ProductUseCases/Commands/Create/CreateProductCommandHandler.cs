using MediatR;
using OA.Application.Mappers;
using OA.Domain;
using OA.Domain.ProductUseCases.Commands;
using OA.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.ProductUseCases.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CustomResponseDto<CreateProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Create(ObjectMapper.Mapper.Map<Product>(request));

            var response = ObjectMapper.Mapper.Map<CreateProductResponse>(product);

            return CustomResponseDto<CreateProductResponse>.Success(200, response);
        }
    }
}