using System;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = ReadArrayFromConsole();
            string[] truckInfo = ReadArrayFromConsole();
            string[] busInfo = ReadArrayFromConsole();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

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
                        case "Bus":
                            Console.WriteLine(bus.Drive(distance));
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
                        case "Bus":
                            bus.Refuel(liters);
                            break;
                    }
                }
                else if (commands[0] == "DriveEmpty")
                {
                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}{Environment.NewLine}Truck: {truck.FuelQuantity:F2}{Environment.NewLine}Bus: {bus.FuelQuantity:F2}");

        }

        private static string[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
