namespace OA.Domain.Repositories;

public interface IReadProductRepository
{
    Task<EntityWithPage<Product?>> GetAll(int page, int pageSize);

    Task<Product?> GetById(int id);
}