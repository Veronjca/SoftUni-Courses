using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
           int startNumber = int.Parse(Console.ReadLine());
           int finalNumber = int.Parse(Console.ReadLine());
           int magicalNumber = int.Parse(Console.ReadLine());

            int combinationsCounter = 0;
            int result = 0;
            

            for (int i = startNumber; i <= finalNumber; i++)
            {
                for (int j = startNumber; j <= finalNumber; j++)
                {
                    combinationsCounter++;

                    result = i + j;

                    if (result == magicalNumber)
                    {
                        
                     Console.WriteLine($"Combination N:{combinationsCounter} ({i} + {j} = {magicalNumber})");
                     return;
                      
                    }
                    
                }
            }

            Console.WriteLine($"{combinationsCounter} combinations - neither equals {magicalNumber}");
 
        }
    }
}
