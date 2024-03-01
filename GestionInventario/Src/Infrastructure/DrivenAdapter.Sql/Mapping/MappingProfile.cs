using AutoMapper;
using Core;
using DrivenAdapter.Sql.Persistence;

namespace DrivenAdapter.Sql.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductCore>().ReverseMap();
        }
    }
}
