using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Motorcycle : Vehicle
    {
        public string MotorcycleType { get; set; }
        public Motorcycle(string RegistrationNumber, string Brand, string Color, string MotorcycleType) 
            : base(RegistrationNumber, Brand, Color)
        {
            this.MotorcycleType = MotorcycleType;
        }

    }
}
