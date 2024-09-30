using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Bus : Vehicle
    {
        public string BusType { get; set; }
        public Bus(string RegistrationNumber, string Brand, string Color, string BusType)
            : base(RegistrationNumber, Brand, Color)
        {
            this.BusType = BusType;
        }
    }
}
