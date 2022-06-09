using OA.Domain.Repositories;
using OA.Persistence.Databases.ReadEfCoreRepositories;

namespace OA.Persistence.ReadRepositories;

public class ReadRepositoryManager : IReadRepositoryManager
{
    private readonly Lazy<IReadProductRepository> _readProductRepository;

    public ReadRepositoryManager(AppDbContext context)
    {
        _readProductRepository = new Lazy<IReadProductRepository>(() => new ReadProductRepository(context));
    }

    public IReadProductRepository ProductRepository => _readProductRepository.Value;
}