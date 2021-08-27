using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int lowGrades = int.Parse(Console.ReadLine());
            string examName = Console.ReadLine();
            int currentGrade = int.Parse(Console.ReadLine());

            int lowGradesAmount = 0;
            int totalGrades = 0;
            decimal averageGrade = 0;
            int totalProblems = 0;
            string lastProblem = "";

            while (examName != "Enough")
            {
               
                if (currentGrade <= 4)
                {
                    lowGradesAmount++;
                }
               
                totalGrades++;
                totalProblems++;
                
                if (lowGradesAmount == lowGrades)
                {
                    Console.WriteLine($"You need a break, {lowGradesAmount} poor grades.");
                    return;
                }

                averageGrade = averageGrade + currentGrade;
                lastProblem = examName;

                examName = Console.ReadLine();
                
                if (examName == "Enough")
                {
                    continue;
                }

                currentGrade = int.Parse(Console.ReadLine());
               
            }


            decimal averageScore = averageGrade / totalGrades;

            Console.WriteLine($"Average score: {averageScore:f2}");
            Console.WriteLine($"Number of problems: {totalProblems}");
            Console.WriteLine($"Last problem: {lastProblem}");
        }
    }
}
