using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain
{
    public class ParkingLevelIsFullException : Exception
    {
        public ParkingLevelIsFullException() : base($"Parking Level is full.")
        {

        }
    }
}
