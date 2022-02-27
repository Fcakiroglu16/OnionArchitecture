using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.Repositories
{
    public interface IProductWriteRepository
    {
        Task<Product> CreateAsync(Product product);

        Task<bool> UpdateAsync(Product product);

        Task<bool> DeleteAsync(string id);
    }
}