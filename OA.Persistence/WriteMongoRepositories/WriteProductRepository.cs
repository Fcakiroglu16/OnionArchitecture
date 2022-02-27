using MongoDB.Driver;
using OA.Domain;
using OA.Domain.Repositories;
using OA.Persistence.Databases;
using Collection = OA.Persistence.WriteMongoRepositories.AntiCorruptionLayer.Collections;

namespace OA.Persistence.WriteRepositories
{
    public class WriteProductRepository : IProductWriteRepository
    {
        public const string ProductCollectionName = "Products";
        private readonly IMongoCollection<Collection.Product> _productCollection;

        public WriteProductRepository(IReadDatabaseSettings readDatabaseSettings)
        {
            var client = new MongoClient(readDatabaseSettings.ConnectionString);

            var database = client.GetDatabase(readDatabaseSettings.DatabaseName);

            _productCollection = database.GetCollection<Collection.Product>(ProductCollectionName);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            var newProduct = new Collection.Product(product);

            await _productCollection.InsertOneAsync(newProduct);

            product.Id = newProduct.Id;
            return product;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.Id == id);

            return result.DeletedCount > 0;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.Id == product.Id, new Collection.Product(product));

            return result != null;
        }
    }
}