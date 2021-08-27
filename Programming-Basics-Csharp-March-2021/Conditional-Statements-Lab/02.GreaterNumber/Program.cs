using System;

namespace GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            if (number1 > number2)
            {
                Console.WriteLine(number1);
            }

           else 
            {
                Console.WriteLine(number2);
            }
        }
    }
}
