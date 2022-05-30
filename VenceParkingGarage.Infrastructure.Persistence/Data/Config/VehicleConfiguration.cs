using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VenceParkingGarage.Core.Domain.Entities;

namespace VenceParkingGarage.Infrastructure.Persistence
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(a => a.LicensePlate)
                    .HasMaxLength(10)
                    .IsRequired();

            builder.HasData(new Vehicle() { Id = 1, Brand = "Toyota", Color = "Red", LicensePlate = "A-123", Type = Core.Domain.VehicleType.Car },
                new Vehicle() { Id = 2, Brand = "Honda", Color = "White", LicensePlate = "A-456", Type = Core.Domain.VehicleType.Motorbike });
        }
    }
}
