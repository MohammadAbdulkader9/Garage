using Garage;

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

    public void Display() // this method calls the DisplayVehicles method in the Garage class.
    {
        garage.DisplayVehicles();
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
        var vehicle = garage.FirstOrDefault(v => v.RegistrationNumber.Equals(regNumber, StringComparison.Ordinal)); // FirstOrDefault is used to return first element that matches.

        if (vehicle != null)
        {
            ui.Message(
                $" - Vehicle found: {vehicle.GetType().Name}\n" +
                $" - Registration Number: {vehicle.RegistrationNumber}\n" +
                $" - Brand: {vehicle.Brand}\n" +
                $" - Color: {vehicle.Color}");

            // Check if the vehicle is of type Car, Bus, or Motorcycle, and display specific info
            if (vehicle is Car car)
            {
                ui.Message($" - Car Type: {car.CarType}");
            }
            else if (vehicle is Bus bus)
            {
                ui.Message($" - Bus Type: {bus.BusType}"); 
            }
            else if (vehicle is Motorcycle motorcycle)
            {
                ui.Message($" - Motorcycle Type: {motorcycle.MotorcycleType}"); 
            }
        }
        else
        {
            ui.Message("Vehicle not found");
        }

        return vehicle!;
    }

}
