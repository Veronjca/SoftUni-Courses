using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Catalogue vehicleCatalogue = new Catalogue();
            vehicleCatalogue.Cars = new List<Car>();
            vehicleCatalogue.Trucks = new List<Truck>();

            while (input != "end")
            {
                string[] inputArgs = input.Split("/", StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[0] == "Truck")
                {
                    Truck truck = new Truck();


                        truck.Brand = inputArgs[1];
                    truck.Model = inputArgs[2];
                    truck.Weight = inputArgs[3];
                    

                    vehicleCatalogue.Trucks.Add(truck);
                }
                else
                {
                    Car car = new Car();

                    car.Brand = inputArgs[1];
                    car.Model = inputArgs[2];
                    car.HorsePower = inputArgs[3];
                    

                    vehicleCatalogue.Cars.Add(car);
                }

                input = Console.ReadLine();
            }

            PrintCatalogue(vehicleCatalogue);
        }

        private static void PrintCatalogue(Catalogue vehicleCatalogue)
        {
          // vehicleCatalogue.Cars.OrderBy(x => x.Brand);
          //vehicleCatalogue.Trucks.OrderBy(x => x.Brand);

            if (vehicleCatalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in vehicleCatalogue.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (vehicleCatalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in vehicleCatalogue.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
            

           
        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }

    class Catalogue
    {
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
