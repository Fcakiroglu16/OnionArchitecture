using OA.Domain.Repositories;
using OA.Persistence.Databases;
using OA.Persistence.WriteRepositories;

namespace OA.Persistence.WriteMongoRepositories
{
    public class WriteRepositoryManager : IWriteRepositoryManager
    {
        private readonly Lazy<IWriteProductRepository> _productWriteRepository;
        private readonly Lazy<IWriteCategoryRepository> _categoryWriteRepository;

        public WriteRepositoryManager(IReadDatabaseSettings readDatabaseSettings)
        {
            _productWriteRepository = new Lazy<IWriteProductRepository>(() => new WriteProductRepository(readDatabaseSettings));
            _categoryWriteRepository = new Lazy<IWriteCategoryRepository>(() => new WriteCategoryRepository(readDatabaseSettings));
        }

        public IWriteProductRepository ProductRepository => _productWriteRepository.Value;
        public IWriteCategoryRepository CategoryRepository => _categoryWriteRepository.Value;
    }
}