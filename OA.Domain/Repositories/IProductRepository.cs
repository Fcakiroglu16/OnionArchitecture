namespace OA.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<EntityWithPage<Product>> GetAll(int page, int pageSize);

        Task<Product> Create(Product product);
    }
}