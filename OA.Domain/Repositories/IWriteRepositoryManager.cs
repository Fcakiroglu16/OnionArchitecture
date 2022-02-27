namespace OA.Domain.Repositories
{
    public interface IWriteRepositoryManager
    {
        IWriteProductRepository ProductRepository { get; }
        IWriteCategoryRepository CategoryRepository { get; }
    }
}