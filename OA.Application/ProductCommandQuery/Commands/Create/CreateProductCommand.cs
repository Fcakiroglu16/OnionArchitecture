using MediatR;
using OA.Application.Mappers;
using OA.Application.ProductUseCases.Commands.Create;
using OA.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.ProductUseCases.Commands
{
    public record CreateProductCommand : IRequest<CustomResponseDto<CreateProductResponse>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}