namespace OA.Application.ProductCommandQuery.Commands.Delete
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, CustomResponseDto<NoContent>>
    {
        private readonly IWriteRepositoryManager _writeRepositoryManager;

        public DeleteProductCommandHandler(IWriteRepositoryManager repositoryManager)
        {
            _writeRepositoryManager = repositoryManager;
        }

        public async Task<CustomResponseDto<NoContent>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _writeRepositoryManager.ProductRepository.DeleteAsync(request.Id);

            return CustomResponseDto<NoContent>.Success(204);
        }
    }
}