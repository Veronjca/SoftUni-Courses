using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double lightsabersCount = Math.Ceiling(studentsCount * 1.1);

            double beltsCount = studentsCount - (studentsCount / 6);

            double totalPrice = lightsabersCount * lightsabersPrice + beltsCount * beltsPrice + robesPrice * studentsCount;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - budget:f2}lv more.");
            }
        }
    }
}
