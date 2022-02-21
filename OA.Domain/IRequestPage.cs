using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain
{
    public interface IRequestPage
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}