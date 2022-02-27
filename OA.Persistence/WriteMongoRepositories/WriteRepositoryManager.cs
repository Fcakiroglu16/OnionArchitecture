using OA.Domain.Repositories;
using OA.Persistence.Databases;
using OA.Persistence.WriteRepositories;

namespace OA.Persistence.WriteMongoRepositories
{
    public class WriteRepositoryManager : IWriteRepositoryManager
    {
        private readonly Lazy<IProductWriteRepository> _productWriteRepository;

        public WriteRepositoryManager(IReadDatabaseSettings readDatabaseSettings)
        {
            _productWriteRepository = new Lazy<IProductWriteRepository>(() => new WriteProductRepository(readDatabaseSettings));
        }

        public IProductWriteRepository ProductRepository => _productWriteRepository.Value;
    }
}