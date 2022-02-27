namespace OA.Application.ProductCommandQuery.Commands.Update;

public class UpdateProductCommand : IRequest<CustomResponseDto<NoContent>>, IIdentity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryId { get; set; }
}