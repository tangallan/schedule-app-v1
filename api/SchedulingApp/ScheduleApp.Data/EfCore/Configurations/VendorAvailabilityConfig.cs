using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleApp.Core.ScheduleAppEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Data.EfCore.Configurations
{
    public class VendorAvailabilityConfig : IEntityTypeConfiguration<VendorAvailability>
    {
        public void Configure(EntityTypeBuilder<VendorAvailability> builder)
        {
            builder.ToTable("VendorAvailability");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(p => p.VendorId).IsRequired();
            builder.Property(i => i.DayOfWeek).HasConversion(v => (short)v, c => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), c.ToString())).HasColumnType("smallint");

            builder.Property(p => p.FromTime).IsRequired().HasColumnType("time");
            builder.Property(p => p.ToTime).IsRequired().HasColumnType("time");

            builder
                .HasOne(h => h.Vendor)
                .WithMany(h => h.VendorAvailabilities)
                .HasForeignKey(h => h.VendorId);
        }
    }
}
