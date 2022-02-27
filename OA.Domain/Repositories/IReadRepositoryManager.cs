namespace OA.Domain.Repositories
{
    public interface IReadRepositoryManager
    {
        IReadProductRepository ProductRepository { get; }
    }
}