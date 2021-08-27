using System;

namespace TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double workstationsCollumns = Math.Floor(((w * 100) / 120));
            double workstationsRow = Math.Floor(((h * 100) - 100) / 70);



            double totalWorkstations = (workstationsCollumns * workstationsRow) - 3;

            Console.WriteLine(totalWorkstations);

        }
    }
}
