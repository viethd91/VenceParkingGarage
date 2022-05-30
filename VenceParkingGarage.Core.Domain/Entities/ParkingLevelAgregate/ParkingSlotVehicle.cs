using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class ParkingSlotVehicle : BaseEntity
    {
        public int ParkingSlotId { get; set; }
        public ParkedVehicleInfo ParkedVehicle { get; private set; }
        public bool CurrentlyParked { get; set; }

        public ParkingSlotVehicle(int slotId, ParkedVehicleInfo parkedVehicle)
        {
            ParkingSlotId = slotId;
            ParkedVehicle = parkedVehicle;
            CurrentlyParked = true;
        }

        private ParkingSlotVehicle()
        {
            // required by EF
        }
    }
}
