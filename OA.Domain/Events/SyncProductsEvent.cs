namespace OA.Domain.Events;

public class SyncProductsEvent
{
    public Product Product { get; set; }
    public ESyncDatabaseAction Action { get; set; }
}