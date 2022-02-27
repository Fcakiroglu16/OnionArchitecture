using OA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain
{
    public class Product : BaseEntity, IIdentity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}