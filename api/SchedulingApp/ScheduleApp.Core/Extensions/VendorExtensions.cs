using AutoMapper;
using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.ScheduleAppEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Core.Extensions.VendorExtensions
{
    public static class VendorExtensions
    {
        public static VendorAvailability ToEntity(this VendorAvailabilityDto vendorAvailabilityDto)
        {
            if (vendorAvailabilityDto == null) return null;

            return Mapper.Map<VendorAvailability>(vendorAvailabilityDto);
        }

        public static VendorService ToEntity(this VendorServiceDto vendorServiceDto)
        {
            if (vendorServiceDto == null) return null;

            return Mapper.Map<VendorService>(vendorServiceDto);
        }
    }
}
