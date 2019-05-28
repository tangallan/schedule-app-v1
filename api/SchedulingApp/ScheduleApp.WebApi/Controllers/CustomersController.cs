using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleApp.Core.Dtos;
using ScheduleApp.Core.Enums;
using ScheduleApp.Core.Interfaces.Repositories;

namespace ScheduleApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        // GET api/customers/newcustomer
        [HttpGet]
        [Route("newcustomer")]
        public ActionResult<Guid> GetNewCustomerId()
        {
            return Guid.NewGuid();
        }

        // GET api/customers/{id}/appointments
        [HttpGet]
        [Route("{id:guid}/appointments")]
        public async Task<ActionResult<List<CustomerAppointmentDto>>> GetCustomerAppointments(Guid id)
        {
            var result = await _customerRepository.GetAllAppointmentsAsync(id);

            return result;
        }

        // POST api/customers/{id}/appointments
        [HttpPost]
        [Route("{id:guid}/appointments")]
        public async Task<ActionResult<CustomerAppointmentDto>> CreateCustomerAppointments(Guid id, [FromBody]CustomerAppointmentDto customerAppointmentDto)
        {
            customerAppointmentDto.CustomerId = id;

            var result = await _customerRepository.CreateAppointmentAsync(customerAppointmentDto);

            return result;
        }

        // PUT api/customers/{id}/appointments/{status}/status
        [HttpPut]
        [Route("{id:int}/appointments/{status:int}/status")]
        public async Task<ActionResult<CustomerAppointmentDto>> UpateStatus(int id, int status)
        {
            if (!Enum.GetValues(typeof(AppointmentStatus)).Cast<int>().Contains(status)) throw new ArgumentException("Status is not defined.");

            var newStatus = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), status.ToString());

            var result = await _customerRepository.UpdateAppointmentStatusAsync(id, newStatus);

            return result;
        }
    }
}