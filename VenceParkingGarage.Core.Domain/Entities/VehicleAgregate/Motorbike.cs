using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenceParkingGarage.Core.Domain.Entities
{
    public class Motorbike : Vehicle
    {
        public string Engine { get; set; }
    }
}
