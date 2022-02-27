namespace OA.Application.ProductCommandQuery.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CustomResponseDto<NoContent>>
{
    private readonly IWriteRepositoryManager _writeRepositoryManager;

    public UpdateProductCommandHandler(IWriteRepositoryManager repositoryManager)
    {
        _writeRepositoryManager = repositoryManager;
    }

    public async Task<CustomResponseDto<NoContent>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _writeRepositoryManager.ProductRepository.UpdateAsync(ObjectMapper.Mapper.Map<Product>(request));

        return CustomResponseDto<NoContent>.Success(204);
    }
}