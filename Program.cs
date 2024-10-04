using System;

namespace Garage
{
    internal class Program
    {
        static IUI ui = new ConsoleUI(); // handle user interaction.
        static GarageHandler garageHandler = new GarageHandler(5, ui); // this object is used to set the size of the garage and UI handler

        static void Main(string[] args)
        {
            ui.Message("Garage Simulator");
            ui.Message("----------------");

            ui.Message(
                "1. To add vehicle to the garage\n" +
                "2. To remove vehicle to the garage\n" +
                "3. To display the vehicles in the garage\n" +
                "4. To search vehicle by registration number\n" +
                "0. To exit");

            bool programStatus = true;

            do
            {
                ui.Message($"Menu Input (Vehicles in garage: {garageHandler.GarageCount}): ");
                string userInput = ui.GetInput();
                switch (userInput)
                {
                    case "1":
                        AddV();
                        break;
                    case "2":
                        RemoveV();
                        break;
                    case "3":
                        DisplayV();
                        break;
                    case "4":
                        SearchV();
                        break;
                    case "0":
                        programStatus = false;
                        break;
                    default:
                        ui.Message("Wrong Input!");
                        break;
                }
            }
            while (programStatus);
        }

        private static void SearchV() // this method is used to search by Registration Number
        {
            if (garageHandler.IsEmpty())
            {
                ui.Message("The garage is empty");
                return;
            }
            ui.Message("Enter Registration Number to search for vehicle: ");
            string regNumber = ui.GetInput();
            garageHandler.SearchByRegNumber(regNumber);
        }

        private static void DisplayV() // check if the garage is empty.
        {
            if (garageHandler.IsEmpty())
            {
                ui.Message("The garage is empty");
                return;
            }
            garageHandler.Display();
        }

        private static void RemoveV() // this method is used to remove vehicle from the garage
        {
            if (garageHandler.IsEmpty())
            {
                ui.Message("The garage is empty");
                return;
            }
            ui.Message("Write Registration number to remove vehicle: ");
            string regNumber = ui.GetInput();
            garageHandler.Remove(regNumber);
        }

        private static void AddV() // this mwthod is used to see if the garage is full.
        {
            if (garageHandler.IsFull())
            {
                ui.Message("The garage is full.");
                return;
            }

            ui.Message(
                "---Choose a vehicle---\n" +
                "1. To add a Car to the garage\n" +
                "2. To add a Bus to the garage\n" +
                "3. To add a Motorcycle to the garage");

            ui.Message("Vehicle Type: ");
            string vType = ui.GetInput();

            switch (vType) // to choose the vehicle type
            {
                case "1":
                    AddVehicle("Car");
                    break;
                case "2":
                    AddVehicle("Bus");
                    break;
                case "3":
                    AddVehicle("Motorcycle");
                    break;
                default:
                    ui.Message("Wrong Input;");
                    break;
            }

            static void AddVehicle(string vehicleType)
            {
                ui.Message("Enter Registration Number: ");
                string regNumber = ui.GetInput();
                ui.Message($"Enter {vehicleType} brand: ");
                string brand = ui.GetInput();
                ui.Message($"Enter {vehicleType} Color: ");
                string color = ui.GetInput();

                switch (vehicleType) // based on vehicle type you can set each vehicle property.
                {
                    case "Car":
                        ui.Message("Enter Car Type (Bensin/Disel): ");
                        string carType = ui.GetInput();
                        garageHandler.Add(new Car(regNumber, brand, color, carType, ui));
                        break;
                    case "Bus":
                        ui.Message("Enter Bus Type (single/double decker): ");
                        string busType = ui.GetInput();
                        garageHandler.Add(new Bus(regNumber, brand, color, busType, ui));
                        break;
                    case "Motorcycle":
                        ui.Message("Enter Motorcycle Type (bike/scooter): ");
                        string mcType = ui.GetInput();
                        garageHandler.Add(new Motorcycle(regNumber, brand, color, mcType, ui));
                        break;
                }
            }
        }
    }
}
