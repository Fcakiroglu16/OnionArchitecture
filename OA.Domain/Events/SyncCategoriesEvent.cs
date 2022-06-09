namespace OA.Domain.Events;

public class SyncCategoriesEvent
{
    public Category Category { get; set; }
    public ESyncDatabaseAction Action { get; set; }
}