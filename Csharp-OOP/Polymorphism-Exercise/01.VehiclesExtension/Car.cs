using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private double fuelQuantity;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.TankCapacity = tankCapacity;
           this.FuelQuantity = fuelQuantity;
           this.FuelConsumption = fuelConsumption + 0.9;
        }

        public override double FuelQuantity 
        { 
            get => this.fuelQuantity; 
            protected set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                this.fuelQuantity = value;
            }
        }
        public override double FuelConsumption { get; set; }
        public override double TankCapacity { get; protected set; }

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
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }
            this.FuelQuantity += liters;
        }
    }
}
