using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class ParkingSlot
    {
        public int Number { get; set; }
        ParkingSlotType Type { get; set; }

        private readonly List<ParkingSlotVehicle> _parkingSlotVehicles = new List<ParkingSlotVehicle>();
        public IReadOnlyCollection<ParkingSlotVehicle> ParkingSlotVehicles => _parkingSlotVehicles.AsReadOnly();
        public bool IsFilled { get
            {
                return _parkingSlotVehicles.Any(x => x.CurrentlyParked);
            }
        }

        public void Park(int slotId, int vehicleId, string licensePlate)
        {
            var parkedSlotVehicle = new ParkingSlotVehicle(slotId, new ParkedVehicleInfo(vehicleId, licensePlate, DateTime.Now));
            _parkingSlotVehicles.Add(parkedSlotVehicle);
        }
    }
}
