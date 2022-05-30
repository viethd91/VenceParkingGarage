using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class ParkingLevel : BaseEntity, IAggregateRoot
    {
        public int Level { get; set; }

        private readonly List<ParkingSlot> _parkingSlots = new List<ParkingSlot>();
        public IReadOnlyCollection<ParkingSlot> ParkingSlots => _parkingSlots.AsReadOnly();

        public void Park(int vehicleId, string licensePlate, VehicleType type)
        {
            var availableParkingSlot = _parkingSlots.FirstOrDefault(x => !x.IsFilled);
            if (availableParkingSlot == null)
                throw new ParkingLevelIsFullException();

            availableParkingSlot.Park(vehicleId, licensePlate, type);
        }
    }
}
