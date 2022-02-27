using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OA.Persistence.WriteMongoRepositories.AntiCorruptionLayer.Collections
{
    public class Category
    {
        public Category()
        {
        }

        public Category(Domain.Category category) => (Id, Name) = (category.Id, category.Name);

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}