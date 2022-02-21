using MediatR;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.ProductUseCases.Commands;
using OA.Domain.ProductUseCases.Queries;

namespace OA.Presentation
{
    public class ProductsController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Page:int}/{PageSize:int}")]
        public async Task<IActionResult> GetProducts([FromRoute] GetAllProductQuery getAllProductQuery)
        {
            return CreateActionResult(await _mediator.Send(getAllProductQuery));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand)
        {
            return CreateActionResult(await _mediator.Send(createProductCommand));
        }
    }
}