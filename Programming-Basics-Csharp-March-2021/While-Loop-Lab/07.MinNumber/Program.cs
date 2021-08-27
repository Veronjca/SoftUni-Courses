using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        { 
                string input = Console.ReadLine();


                double minNumber = double.MaxValue;

                while (input != "Stop")
                {
                    double currentNumber = double.Parse(input);

                    if (currentNumber < minNumber)
                    {
                        minNumber = currentNumber;

                    }

                    input = Console.ReadLine();
                }

                Console.WriteLine(minNumber);
            
        }
    }
}
 
