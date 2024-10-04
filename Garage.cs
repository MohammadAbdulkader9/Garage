using Garage;
using System.Collections;
using System.Collections.Generic;

public class Garage<T> : IEnumerable<T> where T : IVehicle
{
    private T[] vehicles; // array to define garage size
    private int capacity;  // set the garage size
    private int count = 0; // to track vehicle amounts
    private IUI ui;

    public Garage(int capacity, IUI ui)
    {
        this.capacity = capacity;
        vehicles = new T[capacity];
        this.ui = ui;
    }

    public int Count => count;
    public int Capacity => capacity;

    public bool AddVehicle(T vehicle) // This method is used to add vehicle and display a message
    {
        if (count >= capacity) // Check if the garage is full
        {
            ui.Message("The garage is full! Cannot add more vehicles.");
            return false; // Return false if the garage is full
        }

        vehicles[count++] = vehicle;
        ui.Message($"{vehicle.GetType().Name} added to the garage.");
        return true; // Return true if the vehicle is successfully added
    }

    public bool RemoveVehicle(string RegistrationNumber)
    {
        for (int c = 0; c < count; c++)
        {
            if (vehicles[c].RegistrationNumber.Equals(RegistrationNumber, StringComparison.Ordinal)) // To find and match regNumber.
            {
                ui.Message($"{vehicles[c].GetType().Name} removed from the garage.");
                vehicles[c] = vehicles[--count]; // Decrement count and shift vehicles
                return true; // Returns true if vehicle successfully removed 
            }
        }
        ui.Message("Vehicle not found in the garage!");
        return false;
    }

    public void DisplayVehicles() // Display all vehicles in the garage
    {
        if (count == 0)
        {
            ui.Message("No vehicles in the garage.");
            return;
        }

        foreach (var vehicle in this) // Using IEnumerable to iterate over the stored vehicles
        {
            vehicle.DisplayInfo();
        }
    }

    public IEnumerator<T> GetEnumerator() // Use a foreach loop to iterate over the stored vehicles
    {
        for (int c = 0; c < count; c++) // Iterate only over added vehicles
        {
            yield return vehicles[c];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
