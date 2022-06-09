namespace OA.Domain;

public interface IRequestPage
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}