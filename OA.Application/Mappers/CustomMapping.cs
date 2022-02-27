using AutoMapper;
using OA.Application.ProductCommandQuery.Commands.Update;
using OA.Application.ProductUseCases;
using OA.Domain.ProductCommandQuery.Commands.Create;

namespace OA.Application.Mappers
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Product, CreateProductResponse>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}