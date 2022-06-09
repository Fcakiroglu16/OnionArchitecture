using OA.Domain.Events;

namespace OA.Application.CategoryCommandQuery.Commands;

internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CustomResponseDto<CategoryDto>>
{
    private readonly IEventPublish _eventPublish;
    private readonly IWriteRepositoryManager _writeRepositoryManager;

    public CreateCategoryCommandHandler(IWriteRepositoryManager repositoryManager, IEventPublish eventPublish)
    {
        _writeRepositoryManager = repositoryManager;
        _eventPublish = eventPublish;
    }

    public async Task<CustomResponseDto<CategoryDto>> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category =
            await _writeRepositoryManager.CategoryRepository.CreateAsync(ObjectMapper.Mapper.Map<Category>(request));

        if (category.Id != null)
            await _eventPublish.Publish(new SyncCategoriesEvent
                { Category = category, Action = ESyncDatabaseAction.Created });

        var response = ObjectMapper.Mapper.Map<CategoryDto>(category);

        return CustomResponseDto<CategoryDto>.Success(201, response);
    }
}