using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class ParkedVehicleInfo
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public DateTime ParkedTime { get; set; }

        private ParkedVehicleInfo()
        {
        }

        public ParkedVehicleInfo(int vehicleId, string licensePlate, DateTime parkedTime)
        {
            VehicleId = vehicleId;
            LicensePlate = licensePlate;
            ParkedTime = parkedTime;
        }
    }
}
