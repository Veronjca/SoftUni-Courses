using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
 
            double sum = 0;

            while (sum < number)
            {
               
                double input = double.Parse(Console.ReadLine());
                sum += input;
                if (sum >= number)
                {
                    Console.WriteLine(sum);
                }
               
            }

            

        }
    }
}
