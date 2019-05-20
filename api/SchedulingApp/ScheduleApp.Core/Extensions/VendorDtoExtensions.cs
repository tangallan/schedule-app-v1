using AutoMapper;
using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.ScheduleAppEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Core.Extensions.VendorExtensions
{
    public static class VendorDtoExtensions
    {
        public static VendorDto ToDto(this Vendor vendor)
        {
            if (vendor == null) return null;

            return Mapper.Map<Vendor, VendorDto>(vendor);
        }

        public static List<VendorDto> ToDtos(this List<Vendor> vendors)
        {
            return Mapper.Map<List<Vendor>, List<VendorDto>>(vendors);
        }

        public static VendorAvailabilityDto ToDto(this VendorAvailability vendorAvailability)
        {
            if (vendorAvailability == null) return null;

            return Mapper.Map<VendorAvailability, VendorAvailabilityDto>(vendorAvailability);
        }

        public static List<VendorAvailabilityDto> ToDtos(this List<VendorAvailability> vendorAvailabilities)
        {
            return Mapper.Map<List<VendorAvailability>, List<VendorAvailabilityDto>>(vendorAvailabilities);
        }

        public static VendorServiceDto ToDto(this VendorService vendorService)
        {
            if (vendorService == null) return null;

            return Mapper.Map<VendorService, VendorServiceDto>(vendorService);
        }

        public static List<VendorServiceDto> ToDtos(this List<VendorService> vendorServices)
        {
            return Mapper.Map<List<VendorService>, List<VendorServiceDto>>(vendorServices);
        }
    }
}
