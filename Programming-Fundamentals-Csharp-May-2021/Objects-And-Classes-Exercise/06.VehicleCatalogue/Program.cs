using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Catalogue> vehicleCatalogue = new List<Catalogue>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (inputArgs[0] == "car")
                {
                    inputArgs[0] = "Car";
                }
                else if (inputArgs[0] == "truck")
                {
                    inputArgs[0] = "Truck";
                }

                
                vehicleCatalogue.Add(new Catalogue(inputArgs[0], inputArgs[1], inputArgs[2], double.Parse(inputArgs[3])));

                input = Console.ReadLine();
            }

            string model = Console.ReadLine();

            while (model != "Close the Catalogue")
            {

                foreach (var vehicle in vehicleCatalogue)
                {
                    if (model == vehicle.Model)
                    {
                        Console.WriteLine($"Type: {vehicle.Type}");
                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
                    }
                }

                model = Console.ReadLine();
            }

            List<Catalogue> cars = new List<Catalogue>();
            List<Catalogue> trucks = new List<Catalogue>();

            foreach (var vehicle in vehicleCatalogue)
            {
                if (vehicle.Type == "Car")
                {
                    cars.Add(new Catalogue(vehicle.Type, vehicle.Model, vehicle.Color, vehicle.HorsePower));
                }
                else if (vehicle.Type == "Truck")
                {
                    trucks.Add(new Catalogue(vehicle.Type, vehicle.Model, vehicle.Color, vehicle.HorsePower));
                }
            }

            double averageHorsePowerCars = vehicleCatalogue.FindAll(c => c.Type == "Car").Select(c => c.HorsePower).Sum() / (double)vehicleCatalogue.Count(c => c.Type == "Car");
            double averageHorsePowerTrucks = vehicleCatalogue.FindAll(c => c.Type == "Truck").Select(c => c.HorsePower).Sum() / (double)vehicleCatalogue.Count(t => t.Type == "Truck");

            Console.WriteLine(Double.IsNaN(averageHorsePowerCars) ? "Cars have average horsepower of: 0.00." : $"Cars have average horsepower of: {averageHorsePowerCars:f2}.");
            Console.WriteLine(Double.IsNaN(averageHorsePowerTrucks) ? "Trucks have average horsepower of: 0.00." : $"Trucks have average horsepower of: {averageHorsePowerTrucks:f2}.");

            

        }

        class Catalogue
        {
            public Catalogue (string type, string model, string color, double horsePower)
            {
                Type = type;
                Model = model;
                Color = color;
                HorsePower = horsePower;
            }

            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public double  HorsePower { get; set; }
        }
    }
}
