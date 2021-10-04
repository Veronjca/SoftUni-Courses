using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; } = 0;

        public void Drive(double amountOfKilometers)
        {
            bool isEnough = FuelAmount - FuelConsumptionPerKilometer * amountOfKilometers >= 0;

            if (isEnough)
            {
                FuelAmount -= FuelConsumptionPerKilometer * amountOfKilometers;
                TravelledDistance += amountOfKilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
