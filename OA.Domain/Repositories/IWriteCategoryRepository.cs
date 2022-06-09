namespace OA.Domain.Repositories;

public interface IWriteCategoryRepository
{
    Task<Category> CreateAsync(Category category);
}