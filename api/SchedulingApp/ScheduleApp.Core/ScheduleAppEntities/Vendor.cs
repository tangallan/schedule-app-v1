using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Core.ScheduleAppEntities
{
    public class Vendor
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public ICollection<VendorAvailability> VendorAvailabilities { get; set; }

        public ICollection<VendorService> VendorServices { get; set; }
    }
}
