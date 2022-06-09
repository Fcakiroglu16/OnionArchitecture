using Microsoft.AspNetCore.Mvc;
using OA.Domain;

namespace OA.Presentation;

[Route("api/[controller]")]
[ApiController]
public class CustomControllerBase : ControllerBase
{
    public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
    {
        return new ObjectResult(response.StatusCode == 204 ? null : response)
        {
            StatusCode = response.StatusCode
        };
    }
}