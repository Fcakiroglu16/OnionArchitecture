using Microsoft.EntityFrameworkCore;
using OA.Domain;
using OA.Domain.Repositories;
using OA.Persistence.Databases;

namespace OA.Persistence.ReadRepositories;

public class ReadProductRepository : IReadProductRepository
{
    private readonly AppDbContext _context;

    public ReadProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EntityWithPage<Product?>> GetAll(int page, int pageSize)
    {
        var productCount = await _context.Products.CountAsync();

        var products = await _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return new EntityWithPage<Product?> { List = products, TotalCount = productCount };
    }

    public async Task<Product?> GetById(int id)
    {
        return await _context.Products.FindAsync(id);
    }
}