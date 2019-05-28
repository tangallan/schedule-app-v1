using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.Interfaces.Repositories;

namespace ScheduleApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorsController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        // GET api/vendors/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VendorDto>> Get(Guid id)
        {
            var result = await _vendorRepository.GetByIdAsync(id);

            return result;
        }

        // GET api/vendors
        [HttpGet]
        public async Task<ActionResult<List<VendorDto>>> Get()
        {
            var result = await _vendorRepository.GetAllAsync();

            return result;
        }

        // GET api/vendors/{id}/availabilities
        [HttpGet]
        [Route("{id}/availabilities")]
        public async Task<ActionResult<List<VendorAvailabilityDto>>> GetAvailabilities(Guid id)
        {
            var result = await _vendorRepository.GetAvailbitiesAsync(id);

            return result;
        }

        // PUT api/vendors/{id}/availability
        [HttpPut]
        [Route("{id}/availability")]
        public async Task<ActionResult<VendorAvailabilityDto>> UpdateAvailability(Guid id, [FromBody]VendorAvailabilityDto vendorAvailabilityDto)
        {
            await _vendorRepository.UpdateAvailablityAsync(id, vendorAvailabilityDto);
            vendorAvailabilityDto.VendorId = id;

            return vendorAvailabilityDto;
        }

        // GET api/vendors/services/search
        [HttpGet]
        [Route("services/search")]
        public async Task<ActionResult<List<VendorServiceDto>>> SearchServices(string text)
        {
            var result = await _vendorRepository.SearchServices(text);

            return result;
        }

        // GET api/vendors/{id}/services
        [HttpGet]
        [Route("{id}/services")]
        public async Task<ActionResult<List<VendorServiceDto>>> GetServices(Guid id)
        {
            var result = await _vendorRepository.GetServicesAsync(id);

            return result;
        }

        // POST api/vendors/{id}/services
        [HttpPut]
        [Route("{id}/services")]
        public async Task<ActionResult<VendorServiceDto>> UpdateService(Guid id, VendorServiceDto vendorService)
        {
            if (id != vendorService.VendorId) return Unauthorized();

            await _vendorRepository.UpdateServiceAsync(vendorService);

            return vendorService;
        }

        // POST api/vendors/{id}/services
        [HttpPost]
        [Route("{id}/services")]
        public async Task<ActionResult<VendorServiceDto>> CreatNewService(Guid id,  [FromBody]VendorServiceDto vendorService)
        {
            await _vendorRepository.AddServiceAsync(id, vendorService);

            return vendorService;
        }

        // DELETE api/vendors/{id}/availability/{dayofweek}
        [HttpDelete]
        [Route("{id}/availability/{dayofweek}")]
        public async Task<ActionResult> RemoveAvailability(Guid id, DayOfWeek dayOfWeek)
        {
            await _vendorRepository.RemoveAvailabilityAsync(id, dayOfWeek);

            return Ok();
        }

        // DELETE api/vendors/{id}/services/{vendorServiceId}
        [HttpDelete]
        [Route("{id}/services/{vendorServiceId}")]
        public async Task<ActionResult> RemoveService(Guid id, int vendorServiceId)
        {
            await _vendorRepository.RemoveServiceAsync(id, vendorServiceId);

            return Ok();
        }
    }
}
