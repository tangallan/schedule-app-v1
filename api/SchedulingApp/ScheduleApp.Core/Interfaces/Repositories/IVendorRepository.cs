using ScheduleApp.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleApp.Core.Interfaces.Repositories
{
    public interface IVendorRepository
    {
        Task<VendorDto> GetByIdAsync(Guid vendorId);
        Task<VendorDto> GetByCompanyAsync(string company);
        Task<List<VendorDto>> GetAllAsync();
        Task<List<VendorAvailabilityDto>> GetAvailbitiesAsync(Guid vendorId);
        Task<List<VendorServiceDto>> GetServicesAsync(Guid vendorId);

        Task UpdateAvailablityAsync(Guid vendorId, VendorAvailabilityDto vendorAvailability);
        Task RemoveAvailabilityAsync(Guid vendorId, DayOfWeek dayOfWeek);

        Task AddServiceAsync(Guid vendorId, VendorServiceDto service);
        Task UpdateServiceAsync(VendorServiceDto service);
        Task RemoveServiceAsync(Guid vendorId, int vendorServiceId);
    }
}
