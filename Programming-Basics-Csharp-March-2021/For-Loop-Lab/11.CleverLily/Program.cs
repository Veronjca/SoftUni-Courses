using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            double toysAmount = 0;
            double giftedMoney = 0;
            double savedMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    giftedMoney = ((i * 10) / 2) - 1;
                    savedMoney += giftedMoney;   
                }
                else
                {
                    toysAmount++;
                }
            }

           
            double toysSold = toysAmount * toysPrice;
            double totalMoneySaved = toysSold + savedMoney;

            if (totalMoneySaved >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {(totalMoneySaved - washingMachinePrice):f2}");
            }
            else
            {
                Console.WriteLine($"No! {(washingMachinePrice - totalMoneySaved):f2}");
            }
        }
    }
}
