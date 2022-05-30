using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class Vehicle : BaseEntity, IAggregateRoot
    {
        public VehicleType Type { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int RequiredParkingSpace { get; set; }

        //To make it simple we use Type here. But in production we should use table-per-hierarchy here to seperate Car and Motorbike entities
    }
}
