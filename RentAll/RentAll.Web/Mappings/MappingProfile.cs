﻿using AutoMapper;
using RentAll.Domain;
using RentAll.Domain.DTOs;
using RentAll.Web.Controllers;
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
                .ForMember(dest => dest.Owner, map => map.MapFrom(src => src.Owner.CompanyName))
                .ReverseMap();

            CreateMap<Center, CreateCenterDto>()
                 .ReverseMap();


            CreateMap<Center, UpdateCenterDto>()
               .ReverseMap();

            CreateMap<Unit, GetUnitDto>()
                .ForMember(dest => dest.Type, map => map.MapFrom(src => Enum.GetName(src.Type)))
                .ForMember(dest => dest.Center, map => map.MapFrom(src => src.Center.CenterName))
                .ForMember(dest => dest.Floor, map => map.MapFrom(src => src.Floor.FloorName))

               .ReverseMap();

            CreateMap<Unit, CreateUnitDto>()
               .ReverseMap();

            CreateMap<Unit, UpdateUnitDto>()
              .ReverseMap();

            CreateMap<Lease, GetLeaseDto>()
                .ForMember(dest => dest.Center, map => map.MapFrom(src => src.Center.CenterName))
                .ForMember(dest => dest.Tenant, map => map.MapFrom(src => src.Tenant.CompanyName))
                .ForMember(dest => dest.Activity, map => map.MapFrom(src => src.Activity.ActivityName))
                .ForMember(dest => dest.Valid, map => map.MapFrom(src => src.Valid == true ? "valid" : "not valid"))
                .ForMember(dest=>dest.Units, map=>map.MapFrom(src=>src.Units))
                .ReverseMap();

            //CreateMap<Unit, int>().ConvertUsing(src => src.Id);
           
    

            CreateMap<Lease, CreateLeaseDto>()
                //.ForMember(dest => dest.UnitDtos, map => map.MapFrom(src => src.Units))
              .ReverseMap();

            CreateMap<Unit, UnitDto>()
                .ReverseMap();

            CreateMap<Lease, UpdateLeaseDto>()
             
              .ReverseMap();
        }



    }
}