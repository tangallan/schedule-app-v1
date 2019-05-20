using Microsoft.EntityFrameworkCore;
using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.Extensions.VendorExtensions;
using ScheduleApp.Core.Interfaces.Repositories;
using ScheduleApp.Data.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScheduleApp.Domain.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ScheduleAppContext _scheduleAppContext;

        public VendorRepository(ScheduleAppContext scheduleAppContext)
        {
            _scheduleAppContext = scheduleAppContext;
        }

        public async Task<VendorDto> GetByIdAsync(Guid vendorId)
        {
            var data = await _scheduleAppContext.Vendors.FirstOrDefaultAsync(f => f.Id == vendorId);

            return data.ToDto();
        }

        public async Task<VendorDto> GetByCompanyAsync(string company)
        {
            if (string.IsNullOrWhiteSpace(company)) return null;

            var data = await _scheduleAppContext.Vendors.FirstOrDefaultAsync(f => f.CompanyName.Contains(company));
            return data.ToDto();
        }

        public async Task<List<VendorDto>> GetAllAsync()
        {
            var data = await _scheduleAppContext.Vendors.ToListAsync();

            return data.ToDtos();
        }

        public async Task<List<VendorAvailabilityDto>> GetAvailbitiesAsync(Guid vendorId)
        {
            var data = await _scheduleAppContext.VendorAvailabilities.Where(w => w.VendorId == vendorId).ToListAsync();

            return data.ToDtos();
        }

        public async Task<List<VendorServiceDto>> GetServicesAsync(Guid vendorId)
        {
            var data = await _scheduleAppContext.VendorServices.Where(w => w.VendorId == vendorId).ToListAsync();

            return data.ToDtos();
        }

        public async Task UpdateAvailablityAsync(Guid vendorId, VendorAvailabilityDto vendorAvailability)
        {
            if (vendorId == Guid.Empty) throw new ArgumentException("Vendor is required.");
            if (vendorAvailability.FromTime > vendorAvailability.ToTime) throw new ArgumentException("From time must be before To time.");
            if (!Enum.IsDefined(typeof(DayOfWeek), vendorAvailability.DayOfWeek)) throw new ArgumentException("Invalid day of week.");

            var data = await _scheduleAppContext.VendorAvailabilities.FirstOrDefaultAsync(f => f.VendorId == vendorId && f.DayOfWeek == vendorAvailability.DayOfWeek);

            if(data == null)
            {
                var newVa = vendorAvailability.ToEntity();
                newVa.VendorId = vendorId;
                await _scheduleAppContext.VendorAvailabilities.AddAsync(newVa);
            }
            else
            {
                data.FromTime = vendorAvailability.FromTime;
                data.ToTime = vendorAvailability.ToTime;
            }

            await _scheduleAppContext.SaveChangesAsync();
        }

        public async Task RemoveAvailabilityAsync(Guid vendorId, DayOfWeek dayOfWeek)
        {
            var data = await _scheduleAppContext.VendorAvailabilities.FirstOrDefaultAsync(f => f.VendorId == vendorId && f.DayOfWeek == dayOfWeek);
            if(data != null)
            {
                _scheduleAppContext.VendorAvailabilities.Remove(data);
                await _scheduleAppContext.SaveChangesAsync();
            }
        }


        public Task AddServiceAsync(Guid vendorId, VendorServiceDto service)
        {
            throw new NotImplementedException();
        }

        public Task RemoveServiceAsync(Guid vendorId, int vendorServiceId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceAsync(Guid vendorId, VendorServiceDto service)
        {
            throw new NotImplementedException();
        }
    }
}
