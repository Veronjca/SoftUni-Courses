using System;

namespace MethodsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Sign(input);
        }

        static void Sign(int input)
        {
            if (input > 0)
            {
                Console.WriteLine($"The number {input} is positive.");
            }
            else if (input < 0)
            {
                Console.WriteLine($"The number {input} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {input} is zero.");
            }
        }
    }
}
