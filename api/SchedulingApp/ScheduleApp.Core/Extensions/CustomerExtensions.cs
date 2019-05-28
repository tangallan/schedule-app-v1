using AutoMapper;
using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.ScheduleAppEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Core.Extensions
{
    public static class CustomerExtensions
    {
        public static CustomerAppointment ToEntity(this CustomerAppointmentDto customerAppointmentDto)
        {
            if (customerAppointmentDto == null) return null;

            return Mapper.Map<CustomerAppointmentDto, CustomerAppointment>(customerAppointmentDto);
        }
    }
}
