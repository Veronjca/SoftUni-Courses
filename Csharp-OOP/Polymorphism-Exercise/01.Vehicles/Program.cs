using System;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = ReadArrayFromConsole();
            string[] truckInfo = ReadArrayFromConsole();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = ReadArrayFromConsole();
                double distance = double.Parse(commands[2]), liters = double.Parse(commands[2]);
                
                if (commands[0] == "Drive")
                {
                    switch (commands[1])
                    {
                        case "Car":
                            Console.WriteLine(car.Drive(distance));
                            break;
                        case "Truck":
                            Console.WriteLine(truck.Drive(distance));
                            break;
                    }
                }
                else if (commands[0] == "Refuel")
                {
                    switch (commands[1])
                    {
                        case "Car":
                            car.Refuel(liters);
                            break;
                        case "Truck":
                            truck.Refuel(liters);
                            break;
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}{Environment.NewLine}Truck: {truck.FuelQuantity:F2}");

        }

        private static string[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
