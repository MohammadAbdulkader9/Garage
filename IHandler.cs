using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public interface IHandler
    {
        void Add(IVehicle vehicle);
        void Remove(string registrationNumber);
        void Display();
    }
}
