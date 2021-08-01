using System;
using System.Collections.Generic;
using AutoMapper;
using backend.Models;
using backend.Models.Dto;

namespace backend.Mapping
{
    public class KeesMappingProfile : Profile {
        public KeesMappingProfile()
        {
            CreateMap<Product, ProductOut>();
            CreateMap<ProductIn, Product>()
                .ForMember(m => m.Date, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}