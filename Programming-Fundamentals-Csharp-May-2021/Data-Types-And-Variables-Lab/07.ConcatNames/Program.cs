using System;

namespace _07.ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondtName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine($"{firstName}{delimiter}{secondtName}");
        }
    }
}
