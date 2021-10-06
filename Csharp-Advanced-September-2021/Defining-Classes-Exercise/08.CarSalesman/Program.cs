using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine current = new Engine(engineInfo[0], engineInfo[1]);

                try
                {
                    if (int.TryParse(engineInfo[2], out _))
                    {
                        current.Displacement = engineInfo[2];
                    }
                    else
                    {
                        current.Efficiency = engineInfo[2];
                    }

                    if (int.TryParse(engineInfo[3], out _))
                    {
                        current.Displacement = engineInfo[3];
                    }
                    else
                    {
                        current.Efficiency = engineInfo[3];
                    }
                }
                catch(Exception)
                {

                }

                engines.Add(current);

            }

            n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = engines[engines.FindIndex(x => x.Model == carInfo[1])];
                Car current = new Car(carInfo[0], engine);

                try
                {
                    if (int.TryParse(carInfo[2], out _))
                    {
                        current.Weight = carInfo[2];
                    }
                    else
                    {
                        current.Color = carInfo[2];
                    }

                    if (int.TryParse(carInfo[3], out _))
                    {
                        current.Weight = carInfo[3];
                    }
                    else
                    {
                        current.Color = carInfo[3];
                    }
                }
                catch (Exception)
                {

                   
                }
                cars.Add(current);
            }

            
                Console.WriteLine(string.Join(Environment.NewLine, cars));
            
        }
    }
}
