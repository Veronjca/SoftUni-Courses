using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double pointsFromTheAcademy = double.Parse(Console.ReadLine());
            double jury = double.Parse(Console.ReadLine());

           

            for (int i = 0; i < jury; i++)
            {
                string juryName = Console.ReadLine();
                double pointsFromJury = double.Parse(Console.ReadLine());

               pointsFromTheAcademy += juryName.Length * (pointsFromJury / 2);

                if (pointsFromTheAcademy > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {pointsFromTheAcademy:f1}!");
                    return;
                }

            }

            Console.WriteLine($"Sorry, {actorName} you need {(1250.5 - pointsFromTheAcademy):F1} more!");
        }
    }
}
