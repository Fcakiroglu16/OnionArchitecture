using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.Repositories
{
    public interface IWriteCategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}