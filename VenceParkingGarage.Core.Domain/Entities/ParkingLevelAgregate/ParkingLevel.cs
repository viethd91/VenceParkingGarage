using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class ParkingLevel:BaseEntity, IAggregateRoot
    {
        public int Level { get; set; }
        public int ParkingSpaces { get; set; }

        private readonly List<ParkingSlot> _parkingSlots = new List<ParkingSlot>();
        public IReadOnlyCollection<ParkingSlot> ParkingSlots => _parkingSlots.AsReadOnly();

    }
}
