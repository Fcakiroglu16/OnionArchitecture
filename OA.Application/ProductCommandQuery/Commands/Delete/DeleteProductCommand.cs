using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.ProductCommandQuery.Commands.Delete
{
    public class DeleteProductCommand : IRequest<CustomResponseDto<NoContent>>, IIdentity
    {
        public string Id { get; set; }
    }
}