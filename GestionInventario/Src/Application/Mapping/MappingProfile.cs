using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using AutoMapper;
using Core;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, ProductCore>();
            CreateMap<UpdateProductCommand, ProductCore>();
        }
    }
}
