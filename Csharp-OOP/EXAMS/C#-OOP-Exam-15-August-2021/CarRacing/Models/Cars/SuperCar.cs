using CarRacing.Models.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models
{
    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, 80, 10)
        {
        }
    }
}
