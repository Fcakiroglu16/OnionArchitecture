using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.Repositories
{
    public interface IWriteRepositoryManager
    {
        IProductWriteRepository ProductRepository { get; }
    }
}