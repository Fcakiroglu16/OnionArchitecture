namespace OA.Domain;

public class Category : BaseEntity, IIdentity
{
    public string Name { get; set; }
    public string Id { get; set; }
}