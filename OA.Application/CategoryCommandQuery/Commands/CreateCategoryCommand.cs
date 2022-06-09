namespace OA.Application.CategoryCommandQuery.Commands;

public class CreateCategoryCommand : IRequest<CustomResponseDto<CategoryDto>>
{
    public string Name { get; set; }
}