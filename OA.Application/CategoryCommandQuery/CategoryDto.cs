using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.CategoryCommandQuery
{
    public record CategoryDto : IIdentity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}