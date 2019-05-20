using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleApp.Core.ScheduleAppEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Data.EfCore.Configurations
{
    public class VendorServiceConfig : IEntityTypeConfiguration<VendorService>
    {
        public void Configure(EntityTypeBuilder<VendorService> builder)
        {
            builder.ToTable("VendorService");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired().UseSqlServerIdentityColumn();
            builder.Property(p => p.VendorId).IsRequired();
            builder.Property(p => p.ServiceType).IsRequired().HasMaxLength(511);

            builder.Property(p => p.TimeScaleTotal).IsRequired();
            builder.Property(p => p.TimeScale).IsRequired().HasMaxLength(15);

            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(10,2)");

            builder
                .HasOne(h => h.Vendor)
                .WithMany(h => h.VendorServices)
                .HasForeignKey(h => h.VendorId);
        }
    }
}
