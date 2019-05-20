using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleApp.Core.ScheduleAppEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApp.Data.EfCore.Configurations
{
    public class VendorConfig : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendor");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(511);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(511);
            builder.Property(p => p.CompanyName).IsRequired().HasMaxLength(511);

            builder.HasMany(p => p.VendorAvailabilities).WithOne(t => t.Vendor);
            builder.HasMany(p => p.VendorServices).WithOne(t => t.Vendor);
        }
    }
}
