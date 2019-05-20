using System;

namespace ScheduleApp.Core.ScheduleAppEntities
{
    public class VendorAvailability
    {
        public int Id { get; set; }

        public Guid VendorId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
