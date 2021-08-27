using System;

namespace TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double tennisRocketPrice = double.Parse(Console.ReadLine());
            double quantityOfTennisRockets = double.Parse(Console.ReadLine());
            double quantityOfTrainers = double.Parse(Console.ReadLine());

            double totalRocketPrice = tennisRocketPrice * quantityOfTennisRockets;
            double trainersPrice = tennisRocketPrice * 1 / 6;

            double totalTrainersPrice = quantityOfTrainers * trainersPrice;
            double otherEquipment = (totalRocketPrice + totalTrainersPrice) * 0.2;

            double finalPrice = totalTrainersPrice + totalRocketPrice + otherEquipment;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(finalPrice * 1/8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(finalPrice * 7/8)}");

        }
    }
}
