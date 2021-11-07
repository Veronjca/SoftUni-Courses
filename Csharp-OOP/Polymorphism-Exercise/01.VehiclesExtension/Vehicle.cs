using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
           
        }
        public abstract double FuelQuantity { get;  protected set; }
        public abstract double TankCapacity { get; protected set; }
        public abstract double FuelConsumption { get; set; }
        public abstract string Drive(double distance);
        public abstract void Refuel(double liters);
    }
}
