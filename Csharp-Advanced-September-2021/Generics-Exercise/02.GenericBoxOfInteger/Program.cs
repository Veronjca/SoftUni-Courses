using System;

namespace _02.GenericBoxOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                var cuurentBox = new Box<int>(number);
                Console.WriteLine(cuurentBox);
            }
        }
    }
}
