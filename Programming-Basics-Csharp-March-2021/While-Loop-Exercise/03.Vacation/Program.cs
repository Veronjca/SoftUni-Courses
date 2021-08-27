using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double onHandMoney = double.Parse(Console.ReadLine());
            

            double totalDays = 0;
            double daysWhenSpend = 0;

            while (onHandMoney < moneyNeeded && daysWhenSpend < 5 )
            {
                string command = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());
                totalDays++;

                if (command == "spend")
                {
                    daysWhenSpend++;
                    onHandMoney -= sum;
                    if (onHandMoney < 0)
                    {
                        onHandMoney = 0;
                    }
                  
                }
                if (command == "save")
                {
                    daysWhenSpend = 0;
                    onHandMoney += sum;
                }
 
            }

            if (daysWhenSpend == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{totalDays}");
                
            }
            if (onHandMoney >= moneyNeeded)
            {
                Console.WriteLine($"You saved the money for {totalDays} days.");
               
            }
        }

    }
}
