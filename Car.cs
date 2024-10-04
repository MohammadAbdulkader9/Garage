using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Car : Vehicle
    {
        public string CarType { get; set; }
        public Car(string RegistrationNumber, string Brand, string Color, string CarType, IUI ui) 
            : base(RegistrationNumber, Brand, Color, ui)
        {
            this.CarType = CarType;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" - Car Type: {CarType}\n");  // Adds specific Car info
        }
    }
}
