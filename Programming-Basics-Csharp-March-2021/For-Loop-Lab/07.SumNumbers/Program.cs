using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberQuantity = int.Parse(Console.ReadLine());

            int result = 0;

            for (int i = 0; i < numberQuantity; i++)
            {
               int  number = int.Parse(Console.ReadLine());
               result += number;
              
            }
            Console.WriteLine(result);

        }
    }
}
