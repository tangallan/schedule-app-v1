using ScheduleApp.Core.Enums;
using System;

namespace ScheduleApp.Core.Dtos
{
    public class CustomerAppointmentDto
    {
        public int Id { get; set; }

        public Guid CustomerId { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public AppointmentStatus CurrentStatus { get; set; }

        public string ConfirmationNumber { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public int VendorServiceId { get; set; }

        public string Notes { get; set; }

        public string VendorServiceType { get; set; }
    }
}
