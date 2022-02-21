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
        private readonly IRepositoryManager _repositoryManager;

        public CreateProductCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<CustomResponseDto<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repositoryManager.ProductRepository.Create(ObjectMapper.Mapper.Map<Product>(request));
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            var response = ObjectMapper.Mapper.Map<CreateProductResponse>(product);

            return CustomResponseDto<CreateProductResponse>.Success(200, response);
        }
    }
}