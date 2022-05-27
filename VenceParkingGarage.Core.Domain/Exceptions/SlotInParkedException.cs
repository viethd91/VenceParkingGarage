using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Exceptions
{
    public class SlotCurrentlyParkedException : Exception
    {
        public SlotCurrentlyParkedException(int slotId) : base($"Slot {slotId} is currently parked.")
        {

        }
    }
}
