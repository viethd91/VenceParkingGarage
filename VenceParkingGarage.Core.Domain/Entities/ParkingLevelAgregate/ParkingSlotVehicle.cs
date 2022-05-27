using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class ParkingSlotVehicle : BaseEntity
    {
        public int SlotId { get; set; }
        public ParkedVehicleInfo ParkedVehicle { get; private set; }
        public bool CurrentlyParked { get; set; }

        public ParkingSlotVehicle(int slotId, ParkedVehicleInfo parkedVehicle)
        {
            SlotId = slotId;
            ParkedVehicle = parkedVehicle;
        }

        private ParkingSlotVehicle()
        {
            // required by EF
        }
    }
}
