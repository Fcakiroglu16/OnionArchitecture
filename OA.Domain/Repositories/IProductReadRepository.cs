namespace OA.Domain.Repositories
{
    public interface IProductReadRepository
    {
        Task<EntityWithPage<Product>> GetAll(int page, int pageSize);

        Task<Product> GetById(int id);
    }
}