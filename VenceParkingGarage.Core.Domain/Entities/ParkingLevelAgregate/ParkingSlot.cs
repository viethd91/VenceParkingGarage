using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class ParkingSlot : BaseEntity
    {
        public int Number { get; set; }
        public VehicleType Type { get; set; }
        public int ParkingLevelId { get; set; }

        private readonly List<ParkingSlotVehicle> _parkingSlotVehicles = new List<ParkingSlotVehicle>();
        public IReadOnlyCollection<ParkingSlotVehicle> ParkingSlotVehicles => _parkingSlotVehicles.AsReadOnly();
        public bool IsFilled { get
            {
                return _parkingSlotVehicles.Any(x => x.CurrentlyParked);
            }
        }

        public void Park(int vehicleId, string licensePlate, VehicleType type)
        {
            if (type != Type)
                throw new NotValidVehicleException();
            if (_parkingSlotVehicles.Any(x => x.CurrentlyParked))
                throw new SlotCurrentlyParkedException(Id);

            var parkedSlotVehicle = new ParkingSlotVehicle(Id, new ParkedVehicleInfo(vehicleId, licensePlate, DateTime.Now));
            _parkingSlotVehicles.Add(parkedSlotVehicle);
        }
    }
}
