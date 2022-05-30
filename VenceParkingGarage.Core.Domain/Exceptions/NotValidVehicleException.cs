using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain
{
    public class NotValidVehicleException : Exception
    {
        public NotValidVehicleException() : base($"Vehicle type is not valid.")
        {

        }
    }
}
