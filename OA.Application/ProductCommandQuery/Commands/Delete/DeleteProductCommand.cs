namespace OA.Application.ProductCommandQuery.Commands.Delete
{
    public class DeleteProductCommand : IRequest<CustomResponseDto<NoContent>>, IIdentity
    {
        public string Id { get; set; }
    }
}