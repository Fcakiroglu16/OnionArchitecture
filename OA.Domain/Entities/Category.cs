using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.Entities
{
    public class Category : BaseEntity, IIdentity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}