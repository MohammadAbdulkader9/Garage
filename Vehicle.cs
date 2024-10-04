using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public abstract class Vehicle : IVehicle
    {
        private IUI ui;

        public string RegistrationNumber { get; set; }
        public string Brand {  get; set; }
        public string Color { get; set; }

        protected Vehicle(string RegistrationNumber, string Brand, string Color, IUI ui) // general requirement for each vehicle and ui is used to display specific vehicle info.
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Brand = Brand;
            this.Color = Color;
            this.ui = ui;
        }

        public virtual void DisplayInfo() 
        {
            ui.Message(
                $" - Vehicle Type: {GetType().Name}\n" +
                $" - Registration Number: {RegistrationNumber}\n" +
                $" - Brand: {Brand} \n" +
                $" - Color: {Color}");

        }
    }
}
