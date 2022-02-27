using OA.Application.ProductUseCases;

namespace OA.Domain.ProductCommandQuery.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CustomResponseDto<ProductDto>>
    {
        private readonly IWriteRepositoryManager _writeRepositoryManager;

        public CreateProductCommandHandler(IWriteRepositoryManager repositoryManager)
        {
            _writeRepositoryManager = repositoryManager;
        }

        public async Task<CustomResponseDto<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _writeRepositoryManager.ProductRepository.CreateAsync(ObjectMapper.Mapper.Map<Product>(request));

            var response = ObjectMapper.Mapper.Map<ProductDto>(product);

            return CustomResponseDto<ProductDto>.Success(201, response);
        }
    }
}