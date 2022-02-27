using MediatR;
using Microsoft.AspNetCore.Mvc;
using OA.Application.CategoryCommandQuery.Commands;

namespace OA.Presentation.Controllers
{
    public class CategoriesController : CustomControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand request)
        {
            return CreateActionResult(await _mediator.Send(request));
        }
    }
}