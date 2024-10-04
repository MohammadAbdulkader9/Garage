using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
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

        public bool AddVehicle(T vehicle) // this method is used to add vehicle and diplay a message
        {
            vehicles[count++] = vehicle;
            ui.Message($"{vehicle.GetType().Name} added to the garage.");
            return true; // returns true if vehicle successfully added 
        }

        public bool RemoveVehicle(string RegistrationNumber)
        {
            for (int c = 0; c < count; c++)
            {
                if (vehicles[c].RegistrationNumber.Equals(RegistrationNumber, StringComparison.Ordinal)) // to find and match regNumber.
                {
                    ui.Message($"{vehicles[c].GetType().Name} removed from the garage.");
                    vehicles[c] = vehicles[--count];
                    return true;// returns true if vehicle successfully removed 
                }
            }
            ui.Message("Vehicle not found in the garage!");
            return false;
        }

        public IEnumerator<T> GetEnumerator() // use a foreach loop to iterate over the stored vehicles
        {
            for (int c = 0; c < count; c++)
            {
                yield return vehicles[c];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
