using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Car> cars = new List<Car>();

            for (int i = 0; i < int.Parse(input); i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = commands[1];
                double amountOfKilometers = double.Parse(commands[2]);

                foreach (var item in cars)
                {
                    if (item.Model == carModel)
                    {
                        item.Drive(amountOfKilometers);
                    }
                }

            }

            cars.ForEach(car => Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}"));
        }
    }
}
