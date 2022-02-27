using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Persistence.WriteMongoRepositories.AntiCorruptionLayer.Collections
{
    public class Product
    {
        public Product()
        {
        }

        public Product(Domain.Product product) => (Id, Name, Price, Stock) = (product.Id, product.Name, product.Price, product.Stock);

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        //public string CategoryId { get; set; }

        //public Category Category { get; set; }
    }
}