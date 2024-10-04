using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public interface IVehicle
    {
        string RegistrationNumber { get; }
        string Brand { get; }
        string Color { get; }

        void DisplayInfo();
    }
}
