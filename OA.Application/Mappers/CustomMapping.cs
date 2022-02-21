using AutoMapper;
using OA.Application.ProductUseCases;
using OA.Application.ProductUseCases.Commands.Create;
using OA.Domain;
using OA.Domain.ProductUseCases.Commands;
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
            CreateMap<Product, ProductDto>();
        }
    }
}