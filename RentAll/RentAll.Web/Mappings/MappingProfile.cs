using AutoMapper;
using RentAll.Domain;
using RentAll.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Center, CenterDto>()
                .ForPath(dest => dest.Owner.CompanyName, source => source.MapFrom(source => source.Owner.CompanyName))
                
                .ReverseMap();

           

            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
        }



    }
}
