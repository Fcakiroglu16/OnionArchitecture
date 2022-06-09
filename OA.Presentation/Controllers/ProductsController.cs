using MediatR;
using Microsoft.AspNetCore.Mvc;
using OA.Application.ProductCommandQuery.Commands.Delete;
using OA.Application.ProductCommandQuery.Commands.Update;
using OA.Domain.ProductCommandQuery.Commands.Create;
using OA.Domain.ProductUseCases.Queries;

namespace OA.Presentation;

public class ProductsController : CustomControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Page:int}/{PageSize:int}")]
    public async Task<IActionResult> GetAll([FromRoute] GetAllProductQuery request)
    {
        return CreateActionResult(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request)
    {
        return CreateActionResult(await _mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductCommand request)
    {
        return CreateActionResult(await _mediator.Send(request));
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteProductCommand request)
    {
        return CreateActionResult(await _mediator.Send(request));
    }
}