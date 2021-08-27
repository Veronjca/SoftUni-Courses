using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal jury = decimal.Parse(Console.ReadLine());

            string presentationName = Console.ReadLine();
            decimal averageGrade = 0;
            decimal presentationsCounter = 0;

            while (presentationName != "Finish")
            {

                decimal averageGradeForOnePresentation = 0;

                for (int i = 1; i <= jury; i++)
                {
                    decimal grade = decimal.Parse(Console.ReadLine());
                    averageGradeForOnePresentation += grade / jury;
                    
                    
                }

                presentationsCounter++;
                averageGrade += averageGradeForOnePresentation;

                Console.WriteLine($"{presentationName} - {averageGradeForOnePresentation:f2}.");

                presentationName = Console.ReadLine();
            }

            decimal totalAverageGrade = averageGrade / presentationsCounter;
            

            Console.WriteLine($"Student's final assessment is {totalAverageGrade:f2}.");
        }
    }
}
