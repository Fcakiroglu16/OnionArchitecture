using MediatR;
using OA.Application.ProductUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.ProductUseCases.Queries
{
    public record GetAllProductQuery : IRequestPage, IRequest<CustomResponseDto<GetAllProductResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}