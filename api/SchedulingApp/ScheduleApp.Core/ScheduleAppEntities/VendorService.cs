using System;
using System.Collections.Generic;

namespace ScheduleApp.Core.ScheduleAppEntities
{
    public class VendorService
    {
        public int Id { get; set; }

        public Guid VendorId { get; set; }

        public string ServiceType { get; set; }

        public double TimeScaleTotal { get; set; }

        public string TimeScale { get; set; }

        public decimal Price { get; set; }

        public virtual Vendor Vendor { get; set; }

        public ICollection<CustomerAppointment> CustomerAppointments { get; set; }
    }
}
