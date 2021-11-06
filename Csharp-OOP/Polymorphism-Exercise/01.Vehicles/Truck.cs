using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + 1.6;
        }

        public override double FuelQuantity { get; protected set; }
        public override double FuelConsumption { get; protected set; }

        public override string Drive(double distance)
        {
            if (this.FuelQuantity - distance * this.FuelConsumption >= 0)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                return $"Truck travelled {distance} km";
            }

            return "Truck needs refueling";
        }

        public override void Refuel(double liters)
        {
            double totalLiters = liters * 0.95;
            this.FuelQuantity += totalLiters;
        }
    }
}
