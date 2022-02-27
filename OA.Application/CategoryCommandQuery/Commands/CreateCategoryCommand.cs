using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.CategoryCommandQuery.Commands
{
    public class CreateCategoryCommand : IRequest<CustomResponseDto<CategoryDto>>
    {
        public string Name { get; set; }
    }
}