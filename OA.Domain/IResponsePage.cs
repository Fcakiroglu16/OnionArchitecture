using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain
{
    public interface IResponsePage
    {
        public int TotalCount { get; set; }
    }
}