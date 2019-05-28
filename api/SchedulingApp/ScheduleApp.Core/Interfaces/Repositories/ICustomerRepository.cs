using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleApp.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerAppointmentDto>> GetAllAppointmentsAsync(int serivceTypeId);

        Task<List<CustomerAppointmentDto>> GetAllAppointmentsAsync(Guid customerId);

        Task<CustomerAppointmentDto> CreateAppointmentAsync(CustomerAppointmentDto customerAppointmentDto);

        Task<CustomerAppointmentDto> UpdateAppointmentStatusAsync(int appointmetnId, AppointmentStatus newStatus);
    }
}
