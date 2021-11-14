using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            double groups = double.Parse(Console.ReadLine());

            double musala = 0;
            double montBlanc = 0;
            double kilimanjaro = 0;
            double K2 = 0;
            double everest = 0;
            double totalPeople = 0;
            //Група до 5 човека– Мусала
            //Група от 6 до 12 – Монблан
            //Група от 13 до 25 – Килиманджаро
            //Група от 26 до 40 – К2
            //Група от 41 или повече – Еверест

            for (int i = 0; i < groups; i++)
            {
                double peopleInOneGroup = double.Parse(Console.ReadLine());

                if (peopleInOneGroup <=5 )
                {
                    musala += peopleInOneGroup;
                }
                else if (peopleInOneGroup >= 6 && peopleInOneGroup <= 12)
                {
                    montBlanc += peopleInOneGroup;
                }
                else if (peopleInOneGroup >= 13 && peopleInOneGroup <= 25)
                {
                    kilimanjaro += peopleInOneGroup;
                }
                else if (peopleInOneGroup >=26 && peopleInOneGroup <=40)
                {
                    K2 += peopleInOneGroup;
                }
                else
                {
                    everest += peopleInOneGroup;
                }

                totalPeople += peopleInOneGroup;
            }

            double musalaPercent = (musala / totalPeople) * 100;
            double montBlancPercent = (montBlanc / totalPeople) * 100;
            double kilimanjaroPercent = (kilimanjaro / totalPeople) * 100;
            double K2Percent = (K2 / totalPeople) * 100;
            double everestPercent = (everest / totalPeople) * 100;

            Console.WriteLine($"{musalaPercent:f2}%");
            Console.WriteLine($"{montBlancPercent:f2}%");
            Console.WriteLine($"{kilimanjaroPercent:f2}%");
            Console.WriteLine($"{K2Percent:f2}%");
            Console.WriteLine($"{everestPercent:f2}%");
          

        }
    }
}
