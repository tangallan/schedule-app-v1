using Microsoft.EntityFrameworkCore;
using ScheduleApp.Core.ScheduleAppEntities;
using ScheduleApp.Data.EfCore.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Data.EfCore
{
    public class ScheduleAppContext : DbContext
    {
        protected ScheduleAppContext() { }

        public ScheduleAppContext(DbContextOptions<ScheduleAppContext> options) : base(options)
        {

        }

        public virtual DbSet<Vendor> Vendors { get; set; }

        public virtual DbSet<VendorService> VendorServices { get; set; }

        public virtual DbSet<VendorAvailability> VendorAvailabilities { get; set; }

        public virtual DbSet<CustomerAppointment> CustomerAppointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own confguration here
            modelBuilder.ApplyConfiguration(new VendorConfig());
            modelBuilder.ApplyConfiguration(new VendorAvailabilityConfig());
            modelBuilder.ApplyConfiguration(new VendorServiceConfig());
            modelBuilder.ApplyConfiguration(new CustomerAppointmentConfig());
        }
    }
}
