namespace OA.Domain.ProductCommandQuery.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CustomResponseDto<CreateProductResponse>>
    {
        private readonly IWriteRepositoryManager _writeRepositoryManager;

        public CreateProductCommandHandler(IWriteRepositoryManager repositoryManager)
        {
            _writeRepositoryManager = repositoryManager;
        }

        public async Task<CustomResponseDto<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _writeRepositoryManager.ProductRepository.CreateAsync(ObjectMapper.Mapper.Map<Product>(request));

            var response = ObjectMapper.Mapper.Map<CreateProductResponse>(product);

            return CustomResponseDto<CreateProductResponse>.Success(200, response);
        }
    }
}