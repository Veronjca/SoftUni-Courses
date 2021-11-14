using System;

namespace SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
           double trunkCapacity = double.Parse(Console.ReadLine());
           string input = Console.ReadLine();

            int counter = 0;

            while (trunkCapacity > 0)
            {
                double suitcaseVolume = double.Parse(input);
                counter++;

                if (counter % 3 == 0)
                {
                    suitcaseVolume = suitcaseVolume * 1.1;
                }

                trunkCapacity -= suitcaseVolume;

                if (trunkCapacity < 0)
                {
                    counter--;
                    Console.WriteLine("No more space!");
                    break;
                }


                input = Console.ReadLine();


                if (input == "End")
                {
                    break;
                }
                    
               
            }

            if (input == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
           
                Console.WriteLine($"Statistic: {counter} suitcases loaded.");
            
        }
    }
}
