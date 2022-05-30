using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain
{
    public class ParkingLevelNotFoundException : Exception
    {
        public ParkingLevelNotFoundException() : base($"Parking Level not found.")
        {

        }
    }
}
