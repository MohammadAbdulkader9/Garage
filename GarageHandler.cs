using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageHandler : IHandler
    {
        private Garage<IVehicle> garage;
        private IUI ui;

        public int GarageCount => garage.Count; // this property returns current number of vehicles in the garage

        public GarageHandler(int capacity, IUI ui)
        {
            garage = new Garage<IVehicle>(capacity, ui);
            this.ui = ui;
        }

        public void Add(IVehicle vehicle) // this method ensures that the required properties is passed.
        {
            garage.AddVehicle(vehicle);
        }

        public void Remove(string registrationNumber) // this method is used to pass the registration number for removing vehicle from the garage
        {
            garage.RemoveVehicle(registrationNumber);
        }

        public void Display()
        {
            foreach (var vehicle in garage) // this method is used to loop through the stored vehicles.
            {
                vehicle.DisplayInfo();
                //ui.Message($"Vehicle Type: {vehicle.GetType().Name} - Registration Number: {vehicle.RegistrationNumber} - Brand: {vehicle.Brand} - Color: {vehicle.Color}");
            }
        }

        public bool IsEmpty() // checks if the garage is empty
        {
            return garage.Count == 0;

        }

        public bool IsFull() // checks if the garage is full
        {
            return garage.Count >= garage.Capacity;
        }

        public IVehicle SearchByRegNumber(string regNumber) // this method is used to search by registration number.
        {
            var vehicle = garage.FirstOrDefault(v => v.RegistrationNumber.Equals(regNumber, StringComparison.Ordinal)); // FirstOrDefault is used to return first element that matchs.
            if (vehicle != null)
            {
                ui.Message(
                    $" - Vehicle found: {vehicle.GetType().Name} " +
                    $" - Registration Number: {vehicle.RegistrationNumber} " +
                    $" - Brand: {vehicle.Brand}" +
                    $" - Color: {vehicle.Color}");
            }
            else
            {
                ui.Message("Vehicle not found");
            }
            return vehicle!;
        }
    }
}
