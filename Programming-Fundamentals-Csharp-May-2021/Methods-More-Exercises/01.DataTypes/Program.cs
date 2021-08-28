using System;

namespace MethodsMoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Operation(command);
        }

        private static void Operation(string command)
        {
            string input = Console.ReadLine();

            if (command == "int")
            {
                Console.WriteLine(int.Parse(input) * 2);
            }
            else if (command == "real")
            {
                Console.WriteLine($"{double.Parse(input) * 1.5:F2}");
            }
            else
            {
                Console.WriteLine($"${input}$");
            }
        }
    }
}
