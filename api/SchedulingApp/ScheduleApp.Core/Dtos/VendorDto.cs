using System;

namespace ScheduleApp.Core.Dtos
{
    public class VendorDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public VendorDto()
        {

        }
    }
}
