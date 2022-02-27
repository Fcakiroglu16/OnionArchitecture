namespace OA.Application.CategoryCommandQuery
{
    public record CategoryDto : IIdentity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}