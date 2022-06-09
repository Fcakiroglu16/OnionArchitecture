namespace OA.Domain;

public class EntityWithPage<T>
{
    public List<T> List { get; set; }
    public int TotalCount { get; set; }
}