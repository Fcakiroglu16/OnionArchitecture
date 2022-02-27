using AutoMapper;
using OA.Application.ProductCommandQuery.Commands.Update;
using OA.Application.ProductUseCases;

using OA.Domain;
using OA.Domain.ProductCommandQuery.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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