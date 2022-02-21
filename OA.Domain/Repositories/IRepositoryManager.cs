using OA.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}