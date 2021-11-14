using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            

            double topStudents = 0;
            double averageStudents = 0;
            double lowStudents = 0;
            double failedStudents = 0;
            double averageGrade = 0;


            for (int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());
               
                if (grade >= 5)
                {
                    topStudents += 1;
                }
                else if (grade >= 4.00 && grade <= 4.99)
                {
                    averageStudents += 1;
                }
                else if (grade >= 3.00 && grade <= 3.99)
                {
                    lowStudents += 1;
                }
                else if (grade < 3.00)
                {
                    failedStudents += 1;
                }

                averageGrade += grade;


            }

            double totalAverageGrade = averageGrade /  students;
            double percentTopStudents = topStudents / students * 100;
            double percentAverageStudents = averageStudents / students * 100;
            double percentLowStudents = lowStudents / students * 100;
            double percentFailedStudents = failedStudents / students * 100;

            Console.WriteLine($"Top students: {percentTopStudents:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percentAverageStudents:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percentLowStudents:f2}%");
            Console.WriteLine($"Fail: {percentFailedStudents:f2}%");
            Console.WriteLine($"Average: {totalAverageGrade:f2}");

        }
    }
}
