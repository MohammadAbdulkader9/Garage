using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Brand {  get; set; }
        public string Color { get; set; }

        protected Vehicle(string RegistrationNumber, string Brand, string Color)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Brand = Brand;
            this.Color = Color;
            
        }
    }
}
