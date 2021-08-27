using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Необходимо количество найлон (в кв.м.) 
            double nylon = double.Parse(Console.ReadLine());
            //Необходимо количество боя (в литри) 
            double paint = double.Parse(Console.ReadLine());
            //Количество разредител (в литри) 
            double paintThinner = double.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double totalPaintNeeded = paint + (paint * 0.1);

            double nylonPrice = (nylon + 2) * 1.50;
            double paintPrice = totalPaintNeeded * 14.50;
            double thinnerPrice = paintThinner * 5;

            double expenses = nylonPrice + paintPrice + thinnerPrice + 0.40;

            double workersSalary = (expenses * 0.3) * hours;
            double totalExpenses = expenses + workersSalary;

            Console.WriteLine($"Total expenses: {totalExpenses:f2} lv.");
        }
    }
}
