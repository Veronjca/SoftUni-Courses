using System;

namespace _09.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = arguments[0];
                string country = arguments[1];
                int age = int.Parse(arguments[2]);
                IPerson first = new Citizen(name, country, age);
                IResident second = new Citizen(name, country, age);

                Console.WriteLine($"{first.GetName()}{Environment.NewLine}{second.GetName()}");
            }
        }
    }
}
