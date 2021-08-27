using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();


            double maxNumber = double.MinValue;

            while (input != "Stop")
            {
                double currentNumber = double.Parse(input);

                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(maxNumber);
        }
    }
}
