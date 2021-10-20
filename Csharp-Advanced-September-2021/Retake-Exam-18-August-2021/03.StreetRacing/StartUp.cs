using System;

namespace StreetRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Race race = new Race("RockPort Race", "Sprint", 1, 4, 150);
            Car car = new Car("BMW", "320ci", "NFS2005", 150, 1450);
            Console.WriteLine(car.ToString());
            race.Add(car);
            Console.WriteLine(race.Remove("NFS2005"));
            Car carOne = new Car("BMW", "320cd", "NFS2007", 150, 1350);
            Car carTwo = new Car("Audi", "A3", "NFS2004", 131, 1300);
            race.Add(carOne);
            race.Add(carTwo);
            Console.WriteLine(race.GetMostPowerfulCar());
            Console.WriteLine(race.Report());
        }
    }
}
