using AutoMapper;
using Core.Entities;
using E_Commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(x => x.ProductBrand, a => a.MapFrom(s => s.ProductBrand.Name))
                .ForMember(x => x.ProductType, a => a.MapFrom(s => s.ProductType.Name))
                .ForMember(x => x.PictureUrl, a => a.MapFrom<ProductUrlResolver>());
        }
    }
}
