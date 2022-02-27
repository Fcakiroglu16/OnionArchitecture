namespace OA.Domain.Entities
{
    public class Category : BaseEntity, IIdentity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}