using AutoMapper;
using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.ScheduleAppEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Core.Extensions
{
    public static class CustomerDtoExtensions
    {
        public static CustomerAppointmentDto ToDto(this CustomerAppointment customerAppointment)
        {
            if (customerAppointment == null) return null;

            return Mapper.Map<CustomerAppointment, CustomerAppointmentDto>(customerAppointment);
        }

        public static List<CustomerAppointmentDto> ToDto(this List<CustomerAppointment> customerAppointments)
        {
            if (customerAppointments == null) return null;

            return Mapper.Map<List<CustomerAppointment>, List<CustomerAppointmentDto>>(customerAppointments);
        }
    }
}
