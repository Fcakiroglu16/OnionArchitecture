namespace OA.Application.CategoryCommandQuery;

public record CategoryDto : IIdentity
{
    public string Name { get; set; }
    public string Id { get; set; }
}