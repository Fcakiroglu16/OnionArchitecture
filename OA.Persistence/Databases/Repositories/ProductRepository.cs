using Microsoft.EntityFrameworkCore;
using OA.Domain;
using OA.Domain.Repositories;

namespace OA.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }

        public async Task<EntityWithPage<Product>> GetAll(int page, int pageSize)
        {
            var productCount = await _context.Products.CountAsync();

            var products = await _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new EntityWithPage<Product> { List = products, TotalCount = productCount };
        }
    }
}