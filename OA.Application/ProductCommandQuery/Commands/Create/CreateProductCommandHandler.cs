using OA.Application.ProductUseCases;
using OA.Domain.Events;

namespace OA.Domain.ProductCommandQuery.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CustomResponseDto<ProductDto>>
{
    private readonly IEventPublish _eventPublish;
    private readonly IWriteRepositoryManager _writeRepositoryManager;

    public CreateProductCommandHandler(IWriteRepositoryManager repositoryManager, IEventPublish eventPublish)
    {
        _writeRepositoryManager = repositoryManager;
        _eventPublish = eventPublish;
    }

    public async Task<CustomResponseDto<ProductDto>> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product =
            await _writeRepositoryManager.ProductRepository.CreateAsync(ObjectMapper.Mapper.Map<Product>(request));

        if (product.Id != null)
            await _eventPublish.Publish(new SyncProductsEvent
                { Product = product, Action = ESyncDatabaseAction.Created });

        var response = ObjectMapper.Mapper.Map<ProductDto>(product);

        return CustomResponseDto<ProductDto>.Success(201, response);
    }
}