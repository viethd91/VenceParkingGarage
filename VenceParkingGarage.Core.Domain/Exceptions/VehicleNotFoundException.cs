using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException() : base($"Vehicle not found.")
        {

        }
    }
}
