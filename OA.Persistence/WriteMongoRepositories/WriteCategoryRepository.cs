using MongoDB.Driver;
using OA.Domain;

using OA.Domain.Repositories;
using OA.Persistence.Databases;
using Collection = OA.Persistence.WriteMongoRepositories.AntiCorruptionLayer.Collections;

namespace OA.Persistence.WriteMongoRepositories
{
    public class WriteCategoryRepository : IWriteCategoryRepository
    {
        public const string CategoryCollectionName = "Categories";
        private readonly IMongoCollection<Collection.Category> _categoryCollection;

        public WriteCategoryRepository(IReadDatabaseSettings readDatabaseSettings)
        {
            var client = new MongoClient(readDatabaseSettings.ConnectionString);

            var database = client.GetDatabase(readDatabaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Collection.Category>(CategoryCollectionName);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            var newCategory = new Collection.Category(category);

            await _categoryCollection.InsertOneAsync(newCategory);

            category.Id = newCategory.Id;
            return category;
        }
    }
}