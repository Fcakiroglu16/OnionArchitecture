using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Application.CategoryCommandQuery.Commands
{
    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CustomResponseDto<CategoryDto>>
    {
        private readonly IWriteRepositoryManager _writeRepositoryManager;

        public CreateCategoryCommandHandler(IWriteRepositoryManager repositoryManager)
        {
            _writeRepositoryManager = repositoryManager;
        }

        public async Task<CustomResponseDto<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _writeRepositoryManager.CategoryRepository.CreateAsync(ObjectMapper.Mapper.Map<Category>(request));

            var response = ObjectMapper.Mapper.Map<CategoryDto>(category);

            return CustomResponseDto<CategoryDto>.Success(201, response);
        }
    }
}