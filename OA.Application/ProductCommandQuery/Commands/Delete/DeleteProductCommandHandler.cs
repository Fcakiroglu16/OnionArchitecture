using OA.Domain.Events;

namespace OA.Application.ProductCommandQuery.Commands.Delete
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, CustomResponseDto<NoContent>>
    {
        private readonly IWriteRepositoryManager _writeRepositoryManager;

        private readonly IEventPublish _eventPublish;

        public DeleteProductCommandHandler(IWriteRepositoryManager repositoryManager, IEventPublish eventPublish)
        {
            _writeRepositoryManager = repositoryManager;
            _eventPublish = eventPublish;
        }

        public async Task<CustomResponseDto<NoContent>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = await _writeRepositoryManager.ProductRepository.DeleteAsync(request.Id);

            if (response)
            {
                await _eventPublish.Publish(new SyncProductsEvent() { Product = new Product() { Id = request.Id }, Action = ESyncDatabaseAction.Deleted });
            }

            return CustomResponseDto<NoContent>.Success(204);
        }
    }
}