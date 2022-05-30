using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VenceParkingGarage.Core.Domain.Entities;

namespace VenceParkingGarage.Infrastructure.Persistence
{
    public class ParkingSlotConfiguration : IEntityTypeConfiguration<ParkingSlot>
    {
        public void Configure(EntityTypeBuilder<ParkingSlot> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(ParkingSlot.ParkingSlotVehicles));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(ci => ci.ParkingSlotVehicles)
            .WithOne()
            .HasForeignKey(ci => ci.ParkingSlotId);

            builder.HasData(new ParkingSlot() { Id = 1, Number = 1, ParkingLevelId = 1, Type =  Core.Domain.VehicleType.Car },
                new ParkingSlot() { Id = 2, Number = 2, ParkingLevelId = 1, Type = Core.Domain.VehicleType.Motorbike });
        }
    }
}
