using OA.Domain.UnitOfWork;

namespace OA.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}