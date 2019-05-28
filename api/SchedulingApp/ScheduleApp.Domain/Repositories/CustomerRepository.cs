using Microsoft.EntityFrameworkCore;
using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.Enums;
using ScheduleApp.Core.Extensions;
using ScheduleApp.Core.Interfaces.Repositories;
using ScheduleApp.Data.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApp.Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ScheduleAppContext _scheduleAppContext;

        public CustomerRepository(ScheduleAppContext scheduleAppContext)
        {
            _scheduleAppContext = scheduleAppContext;
        }

        public async Task<CustomerAppointmentDto> CreateAppointmentAsync(CustomerAppointmentDto customerAppointmentDto)
        {
            var newEntity = customerAppointmentDto.ToEntity();
            await _scheduleAppContext.CustomerAppointments.AddAsync(newEntity);
            await _scheduleAppContext.SaveChangesAsync();

            return newEntity.ToDto();
        }

        public async Task<List<CustomerAppointmentDto>> GetAllAppointmentsAsync(int serivceTypeId)
        {
            var data = await _scheduleAppContext.CustomerAppointments.Where(w => w.VendorServiceId == serivceTypeId).ToListAsync();

            return data.ToDto();
        }

        public async Task<List<CustomerAppointmentDto>> GetAllAppointmentsAsync(Guid customerId)
        {
            var data = await _scheduleAppContext.CustomerAppointments.Where(w => w.CustomerId == customerId).ToListAsync();

            return data.ToDto();
        }

        public async Task<CustomerAppointmentDto> UpdateAppointmentStatusAsync(int appointmentId, AppointmentStatus newStatus)
        {
            var data = await _scheduleAppContext.CustomerAppointments.FirstOrDefaultAsync(f => f.Id == appointmentId);

            if (data == null) throw new ArgumentException("Appointment cannot be found.");

            data.CurrentStatus = newStatus;

            await _scheduleAppContext.SaveChangesAsync();

            return data.ToDto();
        }
    }
}
