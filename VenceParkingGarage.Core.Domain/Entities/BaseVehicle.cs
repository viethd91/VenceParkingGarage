using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public abstract class BaseVehicle : BaseEntity
    {
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int RequiredParkingSpace { get; set; }
    }
}
