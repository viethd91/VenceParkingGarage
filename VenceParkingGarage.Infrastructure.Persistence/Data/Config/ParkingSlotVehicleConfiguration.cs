using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VenceParkingGarage.Core.Domain.Entities;

namespace VenceParkingGarage.Infrastructure.Persistence
{
    public class ParkingSlotVehicleConfiguration : IEntityTypeConfiguration<ParkingSlotVehicle>
    {
        public void Configure(EntityTypeBuilder<ParkingSlotVehicle> builder)
        {
            builder.OwnsOne(o => o.ParkedVehicle, a =>
            {
                a.WithOwner();

                a.Property(a => a.LicensePlate)
                    .HasMaxLength(10)
                    .IsRequired();
            });
        }
    }
}
