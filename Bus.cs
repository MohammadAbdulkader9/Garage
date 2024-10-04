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
        public Bus(string RegistrationNumber, string Brand, string Color, string BusType, IUI ui)
            : base(RegistrationNumber, Brand, Color, ui)
        {
            this.BusType = BusType;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" - Bus Type: {BusType}\n");  // Adds specific Bus info
        }
    }
}
