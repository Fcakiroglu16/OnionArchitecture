namespace OA.Domain.Repositories
{
    public interface IWriteRepositoryManager
    {
        IProductWriteRepository ProductRepository { get; }
    }
}