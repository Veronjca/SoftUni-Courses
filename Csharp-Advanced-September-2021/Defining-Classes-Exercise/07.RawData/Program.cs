using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Car> cars = new List<Car>();
            
            for (int i = 0; i < int.Parse(input); i++)
            {                
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                List<Tire> tires = new List<Tire>();
                tires.Add(new Tire(double.Parse(info[5]), int.Parse(info[6])));
                tires.Add(new Tire(double.Parse(info[7]), int.Parse(info[8])));
                tires.Add(new Tire(double.Parse(info[9]), int.Parse(info[10])));
                tires.Add(new Tire(double.Parse(info[11]), int.Parse(info[12])));

                cars.Add(new Car(model, engine, cargo, tires));
            }

            input = Console.ReadLine();

            if (input == "fragile")
            {
                cars.Where(car => car.Cargo.Type == "fragile").Where(car => car.Tires.Any(x => x.Pressure < 1)).ToList().ForEach(x => Console.WriteLine($"{x.Model}"));
                
            }
            else if (input == "flammable")
            {
                cars.Where(car => car.Cargo.Type == "flammable").Where(car => car.Engine.Power > 250).ToList().ForEach(x => Console.WriteLine($"{x.Model}"));
            }
        }
    }
}
