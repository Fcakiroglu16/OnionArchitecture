using Microsoft.AspNetCore.Mvc;
using OA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Presentation
{
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
}