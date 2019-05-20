using System;

namespace ScheduleApp.Core.Dtos
{
    public class VendorAvailabilityDto
    {
        public int Id { get; set; }

        public Guid VendorId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }
    }
}
