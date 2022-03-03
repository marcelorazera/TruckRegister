using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckRegister.Domain.Entities;

namespace TruckRegister.Repository.Configurations
{
    public class TruckConfigurations : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.Property(p => p.Id).HasColumnName("id");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Model).HasColumnName("ds_model");            
            builder.Property(p => p.FabricationYear).HasColumnName("cd_fabrication_year");
            builder.Property(p => p.ModelYear).HasColumnName("cd_model_year");
            builder.Property(p => p.Active).HasColumnName("st_active");
            builder.Property(p => p.Created).HasColumnName("dt_created");
            builder.Property(p => p.Changed).HasColumnName("dt_changed");            
        }
    }
}