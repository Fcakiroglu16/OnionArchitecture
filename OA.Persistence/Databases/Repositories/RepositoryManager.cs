using OA.Domain.Repositories;
using OA.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public RepositoryManager(AppDbContext context)
        {
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }

        public IProductRepository ProductRepository => _productRepository.Value;

        public IUnitOfWork UnitOfWork => _unitOfWork.Value;
    }
}