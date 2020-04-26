using AutoMapper;
using ECommerce.Api.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductDto>()
            .ForMember(p=>p.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
            .ForMember(p=>p.ProductType,o=>o.MapFrom(s=>s.ProductType.Name))
            .ForMember(p=>p.PictureUrl,o=>o.MapFrom<ProductUrlResolver>());
        }
    }
}