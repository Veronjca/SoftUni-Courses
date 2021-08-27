using System;

namespace GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();

            double averageGrade = 0;
            double ifExcluded = 0;

            for (int i = 0; i < 12; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                averageGrade = averageGrade + grade / 12;

                if(grade < 4.00)
                {
                    ifExcluded++;
                    if (ifExcluded == 2)
                    {
                        Console.WriteLine($"{studentName} has been excluded at {i} grade");
                        return;
                    }
                }
            }

            Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:f2}");
        }
    }
}
