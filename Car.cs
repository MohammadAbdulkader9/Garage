﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Car : Vehicle
    {
        public string CarType { get; set; }
        public Car(string RegistrationNumber, string Brand, string Color, string CarType) 
            : base(RegistrationNumber, Brand, Color)
        {
            this.CarType = CarType;
        }
    }
}
