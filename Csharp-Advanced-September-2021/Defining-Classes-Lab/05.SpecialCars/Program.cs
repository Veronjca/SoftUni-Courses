using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            List<Tire[]> tires = new List<Tire[]>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                tires.Add(new Tire[]
                {
                    new Tire(int.Parse(inputArgs[0]), double.Parse(inputArgs[1])),
                    new Tire(int.Parse(inputArgs[2]), double.Parse(inputArgs[3])),
                    new Tire(int.Parse(inputArgs[4]), double.Parse(inputArgs[5])),
                    new Tire(int.Parse(inputArgs[6]), double.Parse(inputArgs[7])),

                });
            }

            List<Engine> engines = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                engines.Add(new Engine(int.Parse(inputArgs[0]), double.Parse(inputArgs[1])));
            }

            List<Car> cars = new List<Car>();

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = inputArgs[0];
                string model = inputArgs[1];
                int year = int.Parse(inputArgs[2]);
                double fuelQuantity = double.Parse(inputArgs[3]);
                double fuelConsumption = double.Parse(inputArgs[4]);
                Engine currentEngine = engines[int.Parse(inputArgs[5])];
                Tire[] currentTires = tires[int.Parse(inputArgs[6])];

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, currentEngine, currentTires));

            }

            Func<Car, bool> isPressureEnough = car =>
            {
                double pressureSum = 0;
                for (int j = 0; j < car.Tires.Length; j++)
                {
                    pressureSum += car.Tires[j].Pressure;
                    if (pressureSum >= 9 && pressureSum <= 10)
                    {
                        return true;
                        break;
                    }
                }

                return false;
            };

            cars = cars.Where(car => car.Year >= 2017 && car.Engine.HorsePower > 330).Where(car => isPressureEnough(car)).ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}\nModel: { car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
