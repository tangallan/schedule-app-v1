using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleApp.Core.Enums;
using ScheduleApp.Core.ScheduleAppEntities;
using System;

namespace ScheduleApp.Data.EfCore.Configurations
{
    public class CustomerAppointmentConfig : IEntityTypeConfiguration<CustomerAppointment>
    {
        public void Configure(EntityTypeBuilder<CustomerAppointment> builder)
        {
            builder.ToTable("CustomerAppointment");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired().UseSqlServerIdentityColumn();

            builder.Property(p => p.CustomerId).IsRequired();
            
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(511);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(128);
            builder.Property(p => p.ConfirmationNumber).IsRequired().HasMaxLength(511);

            builder.Property(i => i.CurrentStatus).HasConversion(v => (short)v, c => (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), c.ToString())).HasColumnType("smallint");

            builder.Property(p => p.Date).IsRequired().HasColumnType("date");
            builder.Property(p => p.Time).IsRequired().HasColumnType("time");

            builder.Property(p => p.Notes).HasMaxLength(511);

            builder.Property(p => p.VendorServiceId).IsRequired();

            builder
                .HasOne(h => h.VendorService)
                .WithMany(h => h.CustomerAppointments)
                .HasForeignKey(h => h.VendorServiceId);
        }
    }
}
