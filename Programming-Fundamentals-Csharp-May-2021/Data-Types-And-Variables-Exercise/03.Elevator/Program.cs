using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfPeople = double.Parse(Console.ReadLine());
            double capacity = double.Parse(Console.ReadLine());

            double courses = numberOfPeople / capacity;

            Console.WriteLine($"{Math.Ceiling(courses)}");
        }
    }
}
