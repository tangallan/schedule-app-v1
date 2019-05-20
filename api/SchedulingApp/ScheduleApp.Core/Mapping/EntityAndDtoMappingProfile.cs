using AutoMapper;
using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.ScheduleAppEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Core.Mapping
{
    public class EntityAndDtoMappingProfile : Profile
    {
        public EntityAndDtoMappingProfile()
        {
            CreateMap<Vendor, VendorDto>().ReverseMap();
            CreateMap<VendorAvailability, VendorAvailabilityDto>().ReverseMap();
            CreateMap<VendorService, VendorServiceDto>().ReverseMap();
        }
    }
}
