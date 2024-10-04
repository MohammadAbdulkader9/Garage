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
        public Motorcycle(string RegistrationNumber, string Brand, string Color, string MotorcycleType, IUI ui) 
            : base(RegistrationNumber, Brand, Color, ui)
        {
            this.MotorcycleType = MotorcycleType;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();  
            Console.WriteLine($" - Motorcycle Type: {MotorcycleType} \n");  // Adds specific Motorcycle info
        }
    }
}
