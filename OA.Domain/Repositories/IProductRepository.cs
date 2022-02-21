using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<EntityWithPage<Product>> GetAll(int page, int pageSize);

        Task<Product> Create(Product product);
    }
}