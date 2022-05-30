using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class Car : Vehicle 
    {
        public string Class { get; set; }
    }
}
