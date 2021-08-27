using System;

namespace HappyCatParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            
            double totalSum = 0;

 //           За всеки четен ден и нечетен час, паркингът таксува 2.50 лева.
 //Във всеки нечетен ден и четен час таксата е 1.25 лева, във всички останали случаи се заплаща 1 лев.
 //               Таксуването става на всеки изминал час от деня. 
            for (int i = 1; i <= days; i++)
            {
                double sum = 0;

                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        sum += 2.50;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        sum += 1.25;
                    }
                    else
                    {
                        sum += 1;
                    }
                }

                Console.WriteLine($"Day: {i} - {sum:f2} leva");
                totalSum += sum;
            }

            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}
