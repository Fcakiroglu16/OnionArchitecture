using OA.Domain.Entities;

namespace OA.Domain
{
    public class Product : BaseEntity, IIdentity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}