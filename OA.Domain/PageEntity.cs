using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain
{
    public class EntityWithPage<T>
    {
        public List<T> List { get; set; }
        public int TotalCount { get; set; }
    }
}