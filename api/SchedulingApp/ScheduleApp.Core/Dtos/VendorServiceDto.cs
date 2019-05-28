using System;

namespace ScheduleApp.Core.Dtos
{
    public class VendorServiceDto
    {
        public int Id { get; set; }

        public Guid VendorId { get; set; }

        public string ServiceType { get; set; }

        public double TimeScaleTotal { get; set; }

        public string TimeScale { get; set; }

        public decimal Price { get; set; }

        //
        public VendorDto Vendor { get; set; }
    }
}
