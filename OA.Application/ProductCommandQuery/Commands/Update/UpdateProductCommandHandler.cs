using OA.Domain.Events;

namespace OA.Application.ProductCommandQuery.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CustomResponseDto<NoContent>>
{
    private readonly IWriteRepositoryManager _writeRepositoryManager;
    private readonly IEventPublish _eventPublish;

    public UpdateProductCommandHandler(IWriteRepositoryManager repositoryManager, IEventPublish eventPublish)
    {
        _writeRepositoryManager = repositoryManager;
        _eventPublish = eventPublish;
    }

    public async Task<CustomResponseDto<NoContent>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var updateProduct = ObjectMapper.Mapper.Map<Product>(request);
        var result = await _writeRepositoryManager.ProductRepository.UpdateAsync(updateProduct);
        if (result) await _eventPublish.Publish(new SyncProductsEvent() { Product = updateProduct, Action = ESyncDatabaseAction.Updated });

        return CustomResponseDto<NoContent>.Success(204);
    }
}