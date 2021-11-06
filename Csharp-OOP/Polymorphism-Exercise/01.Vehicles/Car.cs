using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
           this.FuelQuantity = fuelQuantity;
           this.FuelConsumption = fuelConsumption + 0.9;
        }

        public override double FuelQuantity { get; protected set; }
        public override double FuelConsumption { get; protected set; }

        public override string Drive(double distance)
        {
            if (this.FuelQuantity - distance * this.FuelConsumption >= 0)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                return $"Car travelled {distance} km";
            }

            return "Car needs refueling";
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
