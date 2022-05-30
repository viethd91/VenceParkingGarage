using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VenceParkingGarage.Core.Domain.Entities;

namespace VenceParkingGarage.Infrastructure.Persistence
{
    public class ParkingLevelConfiguration : IEntityTypeConfiguration<ParkingLevel>
    {
        public void Configure(EntityTypeBuilder<ParkingLevel> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(ParkingLevel.ParkingSlots));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(ci => ci.ParkingSlots).WithOne().HasForeignKey(x => x.ParkingLevelId);

            builder.HasData(new ParkingLevel() { Id = 1, Level = 1 }
                        , new ParkingLevel() { Id = 2, Level = 2 });
        }
    }
}
