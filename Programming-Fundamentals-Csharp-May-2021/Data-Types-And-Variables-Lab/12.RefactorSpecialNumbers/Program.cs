using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= input; i++)
            {
                int sum = 0;
                int number = i;
                bool ifSpecial = false;

               
                while (number > 0)
                {
                   sum += number % 10;
                    number /= 10;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    ifSpecial = true;
                }
               
                Console.WriteLine("{0} -> {1}", i, ifSpecial);
                
            }

        }
    }
}
