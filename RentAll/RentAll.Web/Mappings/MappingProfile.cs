using AutoMapper;
using RentAll.Domain;
using RentAll.Domain.DTOs;
using RentAll.Web.DTOs;
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
            CreateMap<Center, GetCenterDto>()
                .ReverseMap();

            CreateMap<Center, CreateCenterDto>()
                 .ReverseMap();


            CreateMap<Company, GetCompanyByNameDto>()
                .ReverseMap();

            CreateMap<Center, UpdateCenterDto>()
               .ReverseMap();

           

        }



    }
}
