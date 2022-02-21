using OA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.ProductUseCases.Queries
{
    public record GetAllProductResponse : IResponsePage
    {
        public int TotalCount { get; set; }
        public List<ProductDto> Products { get; set; } = new();
    }
}