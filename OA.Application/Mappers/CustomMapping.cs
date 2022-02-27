using AutoMapper;
using OA.Application.CategoryCommandQuery;
using OA.Application.CategoryCommandQuery.Commands;
using OA.Application.ProductCommandQuery.Commands.Update;
using OA.Application.ProductUseCases;
using OA.Domain.ProductCommandQuery.Commands.Create;

namespace OA.Application.Mappers
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        }
    }
}