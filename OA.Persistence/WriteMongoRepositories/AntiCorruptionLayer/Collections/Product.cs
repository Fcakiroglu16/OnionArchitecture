using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OA.Persistence.WriteMongoRepositories.AntiCorruptionLayer.Collections
{
    public class Product
    {
        public Product()
        {
        }

        public Product(Domain.Product product) => (Id, Name, Price, Stock, CategoryId) = (product.Id, product.Name, product.Price, product.Stock, product.CategoryId);

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}